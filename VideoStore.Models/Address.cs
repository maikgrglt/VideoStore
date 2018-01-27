
using SQLite;

namespace VideoStore.Models
{
    public class Address
    {
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string Zip { get; set; }

        public string HouseNumber { get; set; }
    }
}