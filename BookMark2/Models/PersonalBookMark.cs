using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMark2.Models
{
    public class PersonalBookMark
    {
        public int Id { get; set; } // Primary Key for Personal Book Mark Table
        public string Title { get; set; } // the Title of the reading material
        public string BookType  { get; set; } // What type of reading materials is it? e.g.(Light Novel, Manga, Cartoons, Learning) 
        public string BookGenre  { get; set; } // The Genre of the reading material
        public string BookSubject  { get; set; } // What subject does the reading material cover
        public int CurrentChapters { get; set; } // what chapter is the reader currently at
        public int CurrentPage { get; set; } // what page is the reader currently at
    }
}
