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

        public string Age => _user.DateOfBirth == default ? "" : $"Your age: {_user.Age}";

        public string Western => _user.DateOfBirth == default ? "" : $"Your western sign: {_user.Western}";

        public string Chinese => _user.DateOfBirth == default ? "" : $"Your chinese sign: {_user.Chinese}";

        private void Process()
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
            }

            OnPropertyChanged(nameof(Age));
            OnPropertyChanged(nameof(Western));
            OnPropertyChanged(nameof(Chinese));
        }

        public RelayCommand<object> ConfirmCommand => _confirmCommand ?? (_confirmCommand = new RelayCommand<object>(o =>
                           Process(), o => CanExecuteCommand()));

        private bool CanExecuteCommand() => !string.IsNullOrWhiteSpace(_user.DateOfBirth.ToString());

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}