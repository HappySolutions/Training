using SQLite;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace SweetsDokkana.Models
{
    [Table("Orders")]
    public class CartOrder : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement, Column("OrderId")]
        public int Id { get; set; }

        private string _prodName;

        [MaxLength(225)]
        public string ProdName
        {
            get { return _prodName; }
            set
            {
                if (_prodName == value)
                    return;
                _prodName = value;

                OnPropertyChanged();
            }
        }

        private string _prodImage;

        [MaxLength(225)]
        public string ProdImage
        {
            get { return _prodImage; }
            set
            {
                if (_prodImage == value)
                    return;
                _prodImage = value;

                OnPropertyChanged();
            }
        }

        private float _prodPrice;

        public float ProdPrice
        {
            get { return _prodPrice; }
            set
            {
                if (_prodPrice == value)
                    return;
                _prodPrice = value;

                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
