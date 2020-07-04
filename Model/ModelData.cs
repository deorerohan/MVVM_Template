using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    /// <summary>
    /// Model class from MVVM architecture.
    /// </summary>
    public class ModelData
    {

        public delegate void ShowUserMessage(string msg);

        public event ShowUserMessage ShowUserMessage_Event;

        List<Customer> CustomerList = new List<Customer>();
        List<Account> AccountList = new List<Account>();

        /// <summary>
        /// Constructor is made private so that no one else can create instance of this class
        /// So there is only single static instance of class.
        /// Hence called Singleton design pattern.
        /// This is very useful incase of main data or settings classes.
        /// </summary>
        private ModelData()
        {

        }
        
        private static ModelData instance;

        /// <summary>
        /// Simplest form of Singleton is implemented here
        /// </summary>
        public static ModelData Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new ModelData();
                }

                return instance;
            }
        }

        void Raise_ShowUserMessage_Event(string msg)
        {
            if(ShowUserMessage_Event != null)
            {
                ShowUserMessage_Event(msg);
            }
        }

        public void AddCustomer(string name)
        {
            var customer = CustomerList.FirstOrDefault(s => s.Name == name);
            if(customer == null)
            {
                customer = new Customer(name);
                CustomerList.Add(customer);
                Raise_ShowUserMessage_Event(string.Format("Customer {0} {1} added!", name, customer.CustomerID));
            }

            var acc = new Account(customer.CustomerID);
            AccountList.Add(acc);

            Raise_ShowUserMessage_Event(string.Format("Account {0} added for {1}!", acc.AccountID, name));
        }
    }
}
