using System.Collections.Generic;

namespace MarketAssistant.Models.Data
{

    public class Author
    {
        public Author()
        {
            FirstName = "";
            LastName = "";
            Books = new List<Book>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Book> Books { get; set; }
    }

}