namespace e_books.Data.Models
{
    public class Puplisher
    {

        public class Publisher
        {
            public int Id { get; set; }
            public string Name { get; set; }

            //Navigation Properties
            public List<Book> Books;
        }
    }
}
