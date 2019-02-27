using System.Windows;
using KMA.ProgrammingInCSharp2019.Practice3.LoginControlMVVM.Properties;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Models;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Tools;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Tools.Managers;

namespace KMA.ProgrammingInCSharp2019.Practice5.Navigation.ViewModels
{
    internal class MainWindowViewModel : BaseViewModel, ILoaderOwner
    {
        #region Fields
        private Visibility _loaderVisibility = Visibility.Hidden;
        private bool _isControlEnabled = true;

        #endregion

        #region Properties
        public Visibility LoaderVisibility
        {
            get => _loaderVisibility;
            set
            {
                _loaderVisibility = value;
                OnPropertyChanged();
            }
        }
        public Person Person { get; set; }

        public bool IsControlEnabled
        {
            get => _isControlEnabled;
            set
            {
                _isControlEnabled = value;
                OnPropertyChanged();
            }
        } 
        #endregion

        internal MainWindowViewModel()
        {
            LoaderManeger.Instance.Initialize(this);
        }
    }
}
