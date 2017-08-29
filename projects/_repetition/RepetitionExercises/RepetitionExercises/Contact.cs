using System;

namespace RepetitionExercises {
    public class Contact {
        private string _name;
        private int _yearOfBirth;
        private string _email;
        private bool _isFamilyMember;

        public Contact(string name, int yearOfBirth, bool isFamilyMember) {
            _name = name;
            _yearOfBirth = yearOfBirth;
            _isFamilyMember = isFamilyMember;
            _email = "ukendt@ukendt.dk";
        }

        public string Name {
            get { return _name; }
        }

        public int YearOfBirth {
            get { return _yearOfBirth; }
        }

        public bool IsFamilyMember {
            get { return _isFamilyMember; }
        }

        public string Email {
            get { return _email; }
            set { _email = value; }
        }

        public void PrintSummary() {
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("Year of birth: {0}", YearOfBirth);
            Console.WriteLine("Email: {0}", Email);
            Console.WriteLine("Contact is " + (!IsFamilyMember ? "not " : "") + "a family member.");
        }
    }
}