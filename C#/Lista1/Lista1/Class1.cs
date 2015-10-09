using System;

namespace Lista1
{
    public class Number
    {
        private readonly int _ourNumber;
        private string _numberBased;

        
        public Number(int number)
        {
            _ourNumber = number;
        }

        public string ToBase(int Base)
        {
            if (Base >= 2 && Base <= 16)
            {
               _numberBased = Convert.ToString(_ourNumber, Base); 
            }
            else
            {
                throw new ArgumentException("Base must be between 2 and 16");
            }
            return _numberBased;
        }

        public bool SomethingMustBeFalse()
        {
            return false;
        }

    }
}
