using SQLite;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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

        public Address Address { get; set; }
    }
}
