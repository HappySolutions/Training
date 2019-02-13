using SQLite;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SweetsDokkana.Models
{
    public class Order : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Id { get; set; }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value)
                    return;
                _name = value;

                OnPropertyChanged();
            }
        }

        

        private string _address;

        public string Address
        {
            get { return _address; }
            set
            {
                if (_address == value)
                    return;
                _address = value;

                OnPropertyChanged();
            }
        }

        private string _city;

        public string City
        {
            get { return _city; }
            set
            {
                if (_city == value)
                    return;
                _city = value;

                OnPropertyChanged();
            }
        }

        private string _phone;

        public string Phone
        {
            get { return _phone; }
            set
            {
                if (_phone == value)
                    return;
                _phone = value;

                OnPropertyChanged();
            }
        }

        private string _payment;

        public string Payment
        {
            get { return _payment; }
            set
            {
                if (_payment == value)
                    return;
                _payment = value;

                OnPropertyChanged();
            }
        }

        private string _orderPrice;

        public string OrderPrice
        {
            get { return _orderPrice; }
            set
            {
                if (_orderPrice == value)
                    return;
                _orderPrice = value;

                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
