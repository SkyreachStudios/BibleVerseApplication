using BibleVerseApp.Models;
using BibleVerseApp.Utilities.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Unity;

namespace BibleVerseApp.Utilities.Business
{
    public class VerseService
    {
        [Dependency]
        public ILogger logger { get; set; }

        //creates the verse using the input fields from the form and inputs them to the database.
        public bool CreateVerse(VerseModel verse)
        {
            string connectionString = "Server =.; Database = BibleVerses; Trusted_Connection = True";
            string query = @"insert into dbo.Verses(Testament,Book,Chapter,VerseNum,VerseText) VALUES (@Testament,@Book,@Chapter,@Verse,@VerseText)";
            bool results = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Testament", verse.Testament);
                    command.Parameters.AddWithValue("@Book", verse.Book);
                    command.Parameters.AddWithValue("@Chapter", verse.Chapter);
                    command.Parameters.AddWithValue("@Verse", verse.Verse);
                    command.Parameters.AddWithValue("@VerseText", verse.VerseText);


                    command.Connection.Open();
                    int x = command.ExecuteNonQuery();
                    if (x < 0)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        logger.Info("Connection to DB successful. Added the following verse : Testaments: " + verse.Testament + " Book: " + verse.Book + " Chapter: " + verse.Chapter + " Verse Number: " + verse.Verse + " Verse Text: " + verse.VerseText);
                        logger.Info("Verse was added.");
                        results = true;
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message);
                }
                finally
                {
                    logger.Info("Closing DB connection");
                    connection.Close();
                }
            }
            
            return results;
        }

    }
    
}