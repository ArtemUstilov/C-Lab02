using System.Windows.Controls;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Models;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Tools.Navigation;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.ViewModels;

namespace KMA.ProgrammingInCSharp2019.Practice5.Navigation.Views
{
    public partial class PersonView : UserControl, INavigatable
    {
        internal PersonView(Person person)
        {
            InitializeComponent();
            DataContext = new PersonViewModel(person);
        }
    }
}
