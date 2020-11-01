using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BibleVerseApp.Models
{
    public class VerseModel
    {
        //empty constructor
        public VerseModel()
        {

        }
        //constructor
        public VerseModel(string testament, string book, int chapter, int verse, string verseText)
        {
            Testament = testament;
            Book = book;
            Chapter = chapter;
            Verse = verse;
            VerseText = verseText;
        }
        [Required]
        public string Testament { get; set; }
        [Required]
        public string Book { get; set; }
        [Required]
        public int Chapter { get; set; }
        [Required]
        public int Verse { get; set; }
        [Required]
        public string VerseText { get; set; }

        public int SearchStatus { get; set; }

        //enumerations for drop down lists
        public enum TestamentType
        {
            New, Old
        }
        public enum BookType
        {
            Acts, Amos, FirstChronicles, SecondChronicles, Colossians, FirstCorinthians, SecondCorinthians, Daniel, Deuteronomy,
            Ecclesiastes, Ephesians, Esther, Exodus, Ezekiel, Ezra, Galatians, Genesis, Habakkuk, Haggai, Hebrews,
            Hosea, Isaiah, James, Jeremiah, Job, Joel, John, FirstJohn, SecondJohn, ThirdJohn, Jonah, Joshua,
            Jude, Judges, FirstKings, SecondKings, Lamentations, Leviticus, Luke, Malachi, Mark, Matthew, Micah, Nahum, Nehemiah,
            Numbers, Obadiah, FirstPeter, SecondPeter, Philemon, Philippians, Proverbs, Psalms, Revelation, Romans, Ruth,
            FirstSamuel, SecondSamuel, SongOfSolomon, FirstThessalonians, SecondThessalonians, FirstTimothy,
            SecondTimothy, Titus, Zechariah, Zephaniah
        }
    }
}