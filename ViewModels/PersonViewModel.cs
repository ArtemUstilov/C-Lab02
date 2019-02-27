using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Models;
using KMA.ProgrammingInCSharp2019.Practice5.Navigation.Tools;


namespace KMA.ProgrammingInCSharp2019.Practice5.Navigation.ViewModels
{
    internal class PersonViewModel:BaseViewModel
    {
        public PersonViewModel(Person person)
        {
            Person = person;
        }
        #region Fields
        #region Commands
        #endregion
        #endregion

        #region Properties

        public Person Person { get; set; }

        public string Name => Person.Name;
        public string SurName => Person.Surname;
        public string Email => Person.Email;
        public string Birthday => Person.Birthday;
        public string IsAdult => Person.IsAdult ? "Дорослий" : "Дитина";
        public string SunSign => Person.SunSign;
        public string ChineseSign => Person.ChineseSign;
        public string IsBirthday => Person.IsBirthday ? "З Днем народженння" : "Не сьогодні";
        #endregion
    }
}
