namespace e_books.Data.ViewModels
{
    public class PublisherVM
    {
        public string Name { get; set; }
    }

    public class PublisherWithBooksAndAuthorsVM
    {
        public string Name { get; set; }

        public List<BookAuthorVM> BookAuthors { get; set; }
    }

    public class BookAuthorVM
    {
        public string BookName { get; set; }
        public List<string> BookAuthors { get; set; }
    }

    public class PublisherWithBooksVM
    {
        public string Name { get; set; }
        public List<string> BookTitles { get; set; }
    }
}
