using SQLite;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SweetsDokkana.Models
{
    [Table("Orders")]
    public class Order : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement, Column("OrderId")]
        public int Id { get; set; }

        private string _name;

        [MaxLength(225)]
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

        private string _address1;

        [MaxLength(225)]
        public string Address1
        {
            get { return _address1; }
            set
            {
                if (_address1 == value)
                    return;
                _address1 = value;

                OnPropertyChanged();
            }
        }

        private string _address2;

        public string Address2
        {
            get { return _address2; }
            set
            {
                if (_address2 == value)
                    return;
                _address2 = value;

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
