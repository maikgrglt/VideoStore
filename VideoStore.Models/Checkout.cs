using SQLite;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace VideoStore.Models
{
    public class Checkout : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }
        private double _money;

        public double Money
        {
            get { return _money; }
            set { _money = value; OnPropertyChanged(); }
        }

    }
}
