using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;

namespace KMA.ProgrammingInCSharp2019.Practice5.Navigation.Models
{
    class ZodiacChinese
    {
        private readonly string _name;
        private readonly bool _female;
        public ZodiacChinese(string name, bool female)
        {
            _name = name;
            _female = female;
        }
        public string Name() { return _name; }
        public bool Female() { return _female; }
    }
    class ZodiacWest
    {
        private readonly string _name;
        private readonly int _dayBeg;
        public ZodiacWest(string name, int day)
        {
            _name = name;
            _dayBeg = day;
        }
        public string Name() { return _name; }
        public int DayBeg() { return _dayBeg; }
    }
    class Element
    {
        private readonly string _adjBase;
        public Element(string adjBase)
        {
            _adjBase = adjBase;
        }

        public string FemaleAdj() { return _adjBase + "а"; }
        public string MaleAdj() { return _adjBase + "ий"; }
    }
    static class ZodiacSignsInfo
    {
        private static ZodiacWest[] _sunSigns = {
            new ZodiacWest("Водолій", 20),
            new ZodiacWest("Риби", 19),
            new ZodiacWest("Овен", 21),
            new ZodiacWest("Тілець", 20),
            new ZodiacWest("Близнюки", 21),
            new ZodiacWest("Рак", 21),
            new ZodiacWest("Лев", 23),
            new ZodiacWest("Діва", 23),
            new ZodiacWest("Терези", 23),
            new ZodiacWest("Скорпіон", 23),
            new ZodiacWest("Стрілець", 22),
            new ZodiacWest("Козеріг", 22)
        };

        public static ZodiacWest[] SunSigns => _sunSigns;

        private static ZodiacChinese[] _chineseSigns = {
            
                new ZodiacChinese("Миша", true),
                new ZodiacChinese("Бик", false),
                new ZodiacChinese("Тигр", false),
                new ZodiacChinese("Кіт", false),
                new ZodiacChinese("Дракон", false),
                new ZodiacChinese("Змія", true),
                new ZodiacChinese("Кінь", false),
                new ZodiacChinese("Коза", true),
                new ZodiacChinese("Мавпа", true),
                new ZodiacChinese("Півень", false),
                new ZodiacChinese("Собака", false),
                new ZodiacChinese("Свиня", true)
        };

        public static ZodiacChinese[] ChineseSigns => _chineseSigns;

        private static Element[] _elements =
        {
            new Element("Металев"),
            new Element("Водян"),
            new Element("Дерев'ян"),
            new Element("Вогнян"),
            new Element("Землян")
        };

        public static Element[] Elements => _elements;
    }
    class Person
    {
        private readonly DateTime _birthday;
        private Element _element;
        private ZodiacWest _zodiac;
        private ZodiacChinese _zodiacChinese;
        public Person(string name, string surname, DateTime birthday, string email = "")
        {
            Name = name;
            Surname = surname;
            _birthday = birthday;
            Email = email;
            Age = CountAge();
            ValidateAge();
            ValidateName();
            ValidateEmail();
            ValidateSurname();
            if (IsBirthday)
                MessageBox.Show("З днем народження", "Congratulations");
            FindChineseSign();
            FindElement();
            FindSunSign();
        }
        public Person(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
            ValidateEmail();
            ValidateName();
            ValidateSurname();
        }
        private int Age { get; set; }

        public string Name { get; }

        public string Birthday => _birthday.ToString(CultureInfo.CurrentCulture);

        public string Surname { get; }

        public string Email { get; }

        private void ValidateAge()
        {
            if (Age > 135)
                throw new TooOldPersonException(Age);
            if(Age < 0)
                throw new TooYoungPersonException(Age);
        }

        private void ValidateName()
        {
            Regex reg = new Regex("^[A-Z][a-z]{2,15}$");
            if(!reg.IsMatch(Name))
                throw new InvalidNamePersonException(Name);
        }
        private void ValidateEmail()
        {
            if (!String.IsNullOrEmpty(Email) && !new EmailAddressAttribute().IsValid(Email))
            {
                throw new InvalidEmailPersonException(Email);
            }

        }
        private void ValidateSurname()
        {
            Regex reg = new Regex("^[A-Z][a-z]{2,18}$");
            if (!reg.IsMatch(Surname))
                throw new InvalidSurNamePersonException(Surname);
        }

        public bool IsBirthday
        {
            get
            {
                DateTime today = DateTime.Today;
                return (_birthday.Day == today.Day && _birthday.Month == today.Month);
            }
        }
        private int CountAge()
        {
            DateTime today = DateTime.Today;
            Age = today.Year - _birthday.Year;
            if (today.Month < _birthday.Month ||
                (today.Month == _birthday.Month && today.Day < _birthday.Day))
                Age--;
            return Age;
        }
        public bool IsAdult => Age >= 18;

        private void FindSunSign()
        {
            int zodiacInd = _birthday.Month - 1;
            if (_birthday.Day < ZodiacSignsInfo.SunSigns[zodiacInd].DayBeg())
                zodiacInd = (zodiacInd == 0) ? 11 : zodiacInd - 1;
            _zodiac = ZodiacSignsInfo.SunSigns[zodiacInd];
        }
        private void FindChineseSign()
        {
            int zodiacInd = (_birthday.Year + 8) % 12;
            _zodiacChinese = ZodiacSignsInfo.ChineseSigns[zodiacInd];
        }
        private void FindElement()
        {
            int elementInd = (_birthday.Year) % 10 / 2;
            _element = ZodiacSignsInfo.Elements[elementInd];
        }
        public string ChineseSign
        {
            get
            {
                var adjective = _zodiacChinese.Female() ? _element.FemaleAdj() : _element.MaleAdj();
                return adjective + " " + _zodiacChinese.Name();
            }
        }
        public string SunSign => _zodiac.Name();
    }
    [Serializable]
    class TooOldPersonException : Exception
    {
        public TooOldPersonException()
        {

        }

        public TooOldPersonException(int age)
            : base($"You must have died, {age} years impossible to live")
        {

        }

    }
    [Serializable]
    class TooYoungPersonException : Exception
    {
        public TooYoungPersonException()
        {

        }

        public TooYoungPersonException(int age)
            : base($"You haven`t born yet: {age} years")
        {

        }

    }
    [Serializable]
    class InvalidNamePersonException : Exception
    {
        public InvalidNamePersonException()
        {

        }

        public InvalidNamePersonException(string name)
            : base($"It can`t be your real name: {name}")
        {

        }

    }
    [Serializable]
    class InvalidSurNamePersonException : Exception
    {
        public InvalidSurNamePersonException()
        {

        }

        public InvalidSurNamePersonException(string name)
            : base($"It can`t be your real surname: {name}")
        {

        }

    }
    [Serializable]
    class InvalidEmailPersonException : Exception
    {
        public InvalidEmailPersonException()
        {

        }

        public InvalidEmailPersonException(string email)
            : base($"Invalid email address: {email}")
        {

        }

    }
}
