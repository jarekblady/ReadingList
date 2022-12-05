﻿namespace ReadingList.API.DataTransferObjects
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public bool IsRead { get; set; }
        public bool IsPriority { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
