using System.ComponentModel;
using System.Runtime.CompilerServices;
using SQLite;

namespace VideoStore.Models
{
    public class Customer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
        [AutoIncrement, PrimaryKey]
        public int Id { get; set; }

        private double _debts;

        public double Debts
        {
            get { return _debts; }
            set { _debts = value; OnPropertyChanged();}
        }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        [Indexed]
        public int AddressId { get; set; }

    }
}
