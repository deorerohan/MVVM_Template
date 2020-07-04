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
        List<Customer> CustomerList = new List<Customer>();
        List<Account> AccountList = new List<Account>();

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

        public void AddCustomer(string name)
        {
            var customer = CustomerList.FirstOrDefault(s => s.Name == name);
            if(customer == null)
            {
                customer = new Customer(name);
                CustomerList.Add(customer);
            }

            var acc = new Account(customer.CustomerID);
            AccountList.Add(acc);
        }
    }
}
