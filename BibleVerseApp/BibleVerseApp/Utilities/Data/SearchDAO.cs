using BibleVerseApp.Models;
using BibleVerseApp.Utilities.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Unity;

namespace BibleVerseApp.Services.Data
{
    public class SearchDAO
    {
        
        
        //method for finding the verse to identify if it exists in the database
        public bool findByVerse(VerseModel verse)
        {

        bool foundVerse = false;
            string conncectionString = "Data Source=DESKTOP-BEPLE8D;Initial Catalog=BibleVerses;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string query = @"Select * from dbo.Verses WHERE dbo.Verses.Testament =" +"'"+ verse.Testament+"'" +  "AND dbo.Verses.Book = "+"'"+ verse.Book + "'"+ "AND dbo.Verses.Chapter =" +"'"+ verse.Chapter + "'"+ "AND dbo.Verses.VerseNum ="+ "'"+verse.Verse+ "'";
           
            using (SqlConnection connection = new SqlConnection(conncectionString))
            {
                try
                {

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string foo = reader.GetString(1);
                            if (reader.GetString(1).Equals(verse.Testament) && reader.GetString(2).Equals(verse.Book) && reader.GetInt32(3).Equals(verse.Chapter) && reader.GetInt32(4).Equals(verse.Verse))
                            {
                                
                                foundVerse = true;
                            }
                        }
                    }


                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    
                    connection.Close();
                }
            }

            return foundVerse;
        }
        //method which locates the given verse credentials and sets the model to the values from the database
        public VerseModel setToFoundVerse(VerseModel verse)
        {
            VerseModel foundVerse = new VerseModel();
            string conncectionString = "Data Source=DESKTOP-BEPLE8D;Initial Catalog=BibleVerses;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string query = @"Select * from dbo.Verses WHERE dbo.Verses.Testament =" + "'" + verse.Testament + "'" + "AND dbo.Verses.Book = " + "'" + verse.Book + "'" + "AND dbo.Verses.Chapter =" + "'" + verse.Chapter + "'" + "AND dbo.Verses.VerseNum =" + "'" + verse.Verse + "'";

            using (SqlConnection connection = new SqlConnection(conncectionString))
            {
                try
                {

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string foo = reader.GetString(1);
                            if (reader.GetString(1).Equals(verse.Testament) && reader.GetString(2).Equals(verse.Book) && reader.GetInt32(3).Equals(verse.Chapter) && reader.GetInt32(4).Equals(verse.Verse))
                            {
                                
                                foundVerse.Testament = reader.GetString(1);
                                foundVerse.Book = reader.GetString(2);
                                foundVerse.Chapter = reader.GetInt32(3);
                                foundVerse.Verse = reader.GetInt32(4);
                                foundVerse.VerseText = reader.GetString(5);
                                foundVerse.SearchStatus = 1;


                            }
                        }
                    }


                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                  
                    connection.Close();
                }
            }

            return foundVerse ;
        }


    }
}