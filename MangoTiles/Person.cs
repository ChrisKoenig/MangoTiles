using System;

namespace MangoTiles
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string DisplayBirthDate
        {
            get
            {
                return BirthDate.ToString("ddd, MMM d, yyyy");
            }
        }
    }
}