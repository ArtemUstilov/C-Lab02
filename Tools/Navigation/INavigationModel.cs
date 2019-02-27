using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Models;

namespace KMA.ProgrammingInCSharp2019.Practice5.Navigation.Tools.Navigation
{
    internal enum ViewType
    {
        PersonInfo,
        Form
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType, Person person);
    }
}
