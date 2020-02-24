using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace Keneyz_01
{
    class User
    {
        private DateTime _dateOfBirth;
        private int _age;
        private string _western;
        private string _chinese;

        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set => _dateOfBirth = value;
        }

        public int Age
        {
            get => _age;
            set => _age = value;
        }

        public string Western
        {
            get => _western; 
            set => _western = value;
        }

        public string Chinese
        {
            get => _chinese;
            set => _chinese = value;
        }

        public int AgeCount()
        {
            DateTime dateNow = DateTime.Now;
            int year = dateNow.Year - _dateOfBirth.Year;
            if (dateNow.Month < _dateOfBirth.Month || (dateNow.Month == _dateOfBirth.Month && dateNow.Day < _dateOfBirth.Day))
            {
                year--;
            }

            Age = year;

            return Age;
        }

        public string WesternCount()
        {
            string result = "";

            string[] zodiacName =
            {
                "Capricorn", "Aquarius", "Pisces", "Aries", "Taurus", "Gemini",
                "Cancer", "Leo", "Virgo", "Libra", "Scoprio","Sagittarius"
            };

            int[] zodiacDate =
            {
                21, 20, 20, 20, 20, 20,
                21, 22, 23, 23, 23, 23
            };

            if (_dateOfBirth.Day < zodiacDate[_dateOfBirth.Month - 1])
            {
                result = zodiacName[_dateOfBirth.Month - 1];
            }
            else
            {
                if (_dateOfBirth.Month == 12)
                {
                    _dateOfBirth.AddMonths(-12);
                }
                result = zodiacName[0];
            }

            return result;
        }

        public string ChineseCount()
        {
            string[] chineseName =
            {
                "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake",
                "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig"
            };

            int index = Math.Abs(_dateOfBirth.Year - 1900) % 12;

            return chineseName[index];
        }
    }
} 