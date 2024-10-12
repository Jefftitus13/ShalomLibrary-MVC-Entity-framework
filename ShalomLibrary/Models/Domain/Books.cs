namespace ShalomLibrary.Models.Domain
{
    public class Books
    {
        public Guid Id { get; set; }
        public string? BookTitle { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
        public string? Description { get; set; }
        public int YearPublished { get; set; }
        public int CopiesAvailable { get; set; }
        public long Price { get; set; }
    }
}
