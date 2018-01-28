using SQLite;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace VideoStore.Models
{
    public class Video : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }
        [Indexed]
        public int CustomerId { get; set; }
        public double Length { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }
        public string CoverPath { get; set; }
        private bool _isAvailable;

        public bool IsAvailable
        {
            get { return _isAvailable; }
            set { _isAvailable = value; OnPropertyChanged(); }
        }

    }
}
