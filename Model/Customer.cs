namespace Model
{
    class Customer
    {
        static uint CurrentID = 0;

        public uint CustomerID
        {
            get; private set;
        }

        public string Name 
        {
            get; set;
        }

        public Customer(string name)
        {
            CustomerID = CurrentID++;
            Name = name;
        }
    }

}