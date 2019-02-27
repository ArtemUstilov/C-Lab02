using System.Windows.Controls;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Tools.Navigation;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.ViewModels;

namespace KMA.ProgrammingInCSharp2019.Practice5.Navigation.Views
{
    public partial class FormView : UserControl,INavigatable
    {
        internal FormView()
        {
            InitializeComponent();
            DataContext = new FormViewModel();
        }
    }
}
