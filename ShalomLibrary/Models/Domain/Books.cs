﻿namespace ShalomLibrary.Models.Domain
{
    public class Books
    {
        public Guid Id { get; set; }
        public required string BookTitle { get; set; }
        public required string Author { get; set; }
        public required string Genre { get; set; }
        public string? Description { get; set; }
        public int YearPublished { get; set; }
        public int CopiesAvailable { get; set; }
        public long Price { get; set; }
    }
}
