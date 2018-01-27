using SQLite;

namespace VideoStore.Models
{
    public class Video
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        public double Price { get; set; }

        public string Title { get; set; }

        public int Length { get; set; }

        public string Picture { get; set; }
    }
}