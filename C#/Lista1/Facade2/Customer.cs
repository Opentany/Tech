namespace Facade2
{
    public class Customer
    {
        private readonly string _name;

        // Constructor
        public Customer(string name)
        {
            this._name = name;
        }

        // Gets the name
        public string Name
        {
            get { return _name; }
        }
    }
}