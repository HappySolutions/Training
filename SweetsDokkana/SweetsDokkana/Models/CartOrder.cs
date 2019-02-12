using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace SweetsDokkana.Models
{
    public class CartOrder : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Id { get; set; }

        private string _prodName;

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

        private string _prodDescreption;

        public string ProdDescreption
        {
            get { return _prodDescreption; }
            set
            {
                if (_prodDescreption == value)
                    return;
                _prodDescreption = value;

                OnPropertyChanged();
            }
        }

        private double _prodPrice;

        public double ProdPrice
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

        double selectedQuantity;
        public double SelectedQuantity
        {
            get
            {
                return selectedQuantity;
            }
            set
            {
                if (selectedQuantity == value)
                    return;
                selectedQuantity = value;

                OnPropertyChanged();
            }
        }

        double sumPrice;
        public double SumPrice
        {
            get
            {
                return sumPrice;
            }
            set
            {
                if (sumPrice == value)
                    return;
                sumPrice = value;

                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
