using System;
using System.Collections.Generic;
using System.Text;

namespace RefactoringLab8
{
    class Students
    {
        private string name;
        private string surname;
        private string hometown;
        private string faveFood;
        private string faveColor;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public string Hometown
        {
            get { return hometown; }
            set { hometown = value; }
        }
        public string FaveFood
        {
            get { return faveFood; }
            set { faveFood = value; }
        }
        public string FaveColor
        {
            get { return faveColor; }
            set { faveColor = value; }
        }

        public Students(string Name, string Surname, string HomeTown, string FaveFood, string FaveColor)
        {
            name = Name;
            surname = Surname;
            hometown = HomeTown;
            faveFood = FaveFood;
            faveColor = FaveColor;
        }
    }
}
