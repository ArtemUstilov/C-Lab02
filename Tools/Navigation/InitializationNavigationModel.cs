using System;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Models;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Views;
using MainView = KMA.ProgrammingInCSharp2019.Practice5.Navigation.Views.MainView;
using SignUpView = KMA.ProgrammingInCSharp2019.Practice5.Navigation.Views.PersonView;

namespace KMA.ProgrammingInCSharp2019.Practice5.Navigation.Tools.Navigation
{
    internal class InitializationNavigationModel : BaseNavigationModel
    {
        public InitializationNavigationModel(IContentOwner contentOwner) : base(contentOwner)
        {
            
        }
   
        protected override void InitializeView(ViewType viewType, Person person)
        {
            switch (viewType)
            {
                case ViewType.PersonInfo:
                    ViewsDictionary.Add(viewType,new PersonView(person));
                    break;
                case ViewType.Form:
                    ViewsDictionary.Add(viewType, new FormView());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}
