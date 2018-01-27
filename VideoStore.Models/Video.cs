using SQLite;

namespace VideoStore.Models
{
    public class Video
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }
        [Indexed]
        public int CustomerId { get; set; }
        public double Length { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }
        public string CoverPath { get; set; }
    }
}
