using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BookStore.Models
{
    public class Book : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        private string _bookName;

        [MaxLength(255)]
        public string BookName
        {
            get { return _bookName; }
            set
            {
                if (_bookName == value)
                    return;

                _bookName = value;

                OnPropertyChanged();
            }
        }

        private string _auther;

        [MaxLength(255)]
        public string Auther
        {
            get { return _auther; }
            set
            {
                if (_auther == value)
                    return;

                _auther = value;

                OnPropertyChanged();
            }
        }
        
        [MaxLength(255)]
        public string ISBN { get; set; }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
