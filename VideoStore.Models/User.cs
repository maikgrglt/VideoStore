
using SQLite;

namespace VideoStore.Models
{
    public class User 
    {
       [AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

    }
}
