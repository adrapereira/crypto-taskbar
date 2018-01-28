using System;
using System.ComponentModel;
using System.Globalization;

namespace CryptoTaskbar {
    class Crypto : INotifyPropertyChanged {
        public String code, fiat;
        public Boolean watchOnly = true;
        public float quantity = 1;
        private float _lastPrice;

        public String Value {
            get {
                var _value = _lastPrice;
                if (!watchOnly) {
                    _value = quantity * _lastPrice;
                }
                return String.Format("{0}: {1}€", code, _value);
            }
            set {
                _lastPrice = float.Parse(value, CultureInfo.InvariantCulture);
                OnPropertyChanged("Value");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string property) {
            if (PropertyChanged != null) {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
