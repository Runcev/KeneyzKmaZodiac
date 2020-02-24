using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace Keneyz_01
{
    internal class ConfirmViewModel : INotifyPropertyChanged
    {
        private readonly User _user = new User();

        private RelayCommand<object> _confirmCommand;

        public DateTime DateOfBirth
        {
            set
            {
                _user.DateOfBirth = value;
                OnPropertyChanged();
            }
        }

        public string Age
        {
            get => _user.DateOfBirth == default ? "" : $"Your age: {_user.Age}";

            set
            {
                _user.Age = int.Parse(value);
                OnPropertyChanged();
            }
        }

        public string Western
        {
            get => _user.DateOfBirth == default ? "" : $"Your western sign: {_user.Western}";
            set
            {
                _user.Western = value;
                OnPropertyChanged();
            }
        }

        public string Chinese
        {
            get => _user.DateOfBirth == default ? "" : $"Your chinese sign: {_user.Chinese}";
            set
            {
                _user.Chinese = value;
                OnPropertyChanged();
            }
        }

        private async void Process()
        {
            if (_user.DateOfBirth.Year < DateTime.Today.Year - 135 || _user.DateOfBirth > DateTime.Today)
            {
                MessageBox.Show("Wrong date.\n Try again");
                DateOfBirth = default;
            }
            else
            {
                if (_user.DateOfBirth.Month == DateTime.Today.Month && _user.DateOfBirth.Day == DateTime.Today.Day)
                {
                    MessageBox.Show("Happy Birthday");
                }

                Age = _user.AgeCount().ToString();
                Western = _user.WesternCount();
                Chinese = _user.ChineseCount();

            }

            OnPropertyChanged(nameof(Age));
            OnPropertyChanged(nameof(Western));
            OnPropertyChanged(nameof(Chinese));
        }

        public RelayCommand<object> ConfirmCommand
        {
            get
            {
                return _confirmCommand ?? (_confirmCommand = new RelayCommand<object>(o =>
                           Process(), o => CanExecuteCommand()));
            }
        }

        private bool CanExecuteCommand()
        {
           return  !string.IsNullOrWhiteSpace(_user.DateOfBirth.ToString());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}