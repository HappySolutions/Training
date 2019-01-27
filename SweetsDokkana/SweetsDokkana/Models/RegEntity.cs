using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace SweetsDokkana.Models
{
    [Table("RegEntity")]
    public class RegEntity : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement, Column("UserID")]
        public int ID { get; set; }

        private string _userName;

        [MaxLength(225)]
        public string UserName
        {
            get { return _userName; }
            set
            {
                if (_userName == value)
                    return;
                _userName = value;

                OnPropertyChanged();
            }
        }

        private string _password;

        [MaxLength(225)]
        public string Password
        {
            get { return _password; }
            set
            {
                if (_password == value)
                    return;
                _password = value;

                OnPropertyChanged();
            }
        }

        private string _email;

        [MaxLength(225)]
        public string Email
        {
            get { return _email; }
            set
            {
                if (_email == value)
                    return;
                _email = value;

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

        private string _address;

        [MaxLength(225)]
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

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
