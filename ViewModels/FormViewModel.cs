using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel.DataAnnotations;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Models;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Tools;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Tools.Managers;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Tools.Navigation;

namespace KMA.ProgrammingInCSharp2019.Practice5.Navigation.ViewModels
{
    internal class FormViewModel : BaseViewModel
    {
        #region Fields

        private Person _person;
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birth = new DateTime(1900, 1, 1);

        #region Commands

        private RelayCommand<object> _proceedCommand;

        #endregion

        #endregion

        #region Properties

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public DateTime Date
        {
            get => _birth;
            set
            {
                _birth = value;
                OnPropertyChanged();
            }
        }

        #region Commands

        public RelayCommand<object> ProceedCommand
        {
            get
            {
                return _proceedCommand ?? (_proceedCommand = new RelayCommand<object>(Result,
                           o => CanExecuteCommand()));
            }
        }

        #endregion

        #endregion

        private async void Result(object obj)
        {
            Thread.Sleep(100);
            var approve = await Task.Run(() =>
                {
                    try
                    {
                        _person = new Person(_name, _surname, _birth, _email);
                        return true;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Error");
                        return false;
                    }
                }
            );
            if (approve)
                NavigationManager.Instance.Navigate(ViewType.PersonInfo, _person);
        }

        public bool CanExecuteCommand()
        {
            return !string.IsNullOrWhiteSpace(_name) &&
                   !string.IsNullOrWhiteSpace(_surname) &&
                   !string.IsNullOrWhiteSpace(_email) &&
                   !_birth.Equals(new DateTime(1900, 1, 1));
        }
    }
}