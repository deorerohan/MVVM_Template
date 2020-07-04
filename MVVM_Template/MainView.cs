using System;
using System.ComponentModel;
using ViewModel;

namespace MVVM_Template
{
    /// <summary>
    /// Main view class representing View module in MVVM architecture.
    /// This class contains main loop for application
    /// </summary>
    class MainView
    {
        MainViewModel vm;

        private string someValue = "Value from MainView";

        public string SomeValue
        {
            get
            {
                return someValue;
            }
            set
            {
                if (value != someValue)
                {
                    someValue = value;
                }
                
            }
        }

        public MainView()
        {
            vm = new MainViewModel();
            vm.PropertyChanged += PropertyChanged_Handler;
        }

        /// <summary>
        /// Function to handle property changes in ViewModel to reflect in View.
        /// This is code mimicing behavior of data binding available in WPF.
        /// </summary>
        public void PropertyChanged_Handler(object sender, PropertyChangedEventArgs e)
        {
            var property = this.GetType().GetProperty(e.PropertyName);
            var valueToSet = sender.GetType().GetProperty(e.PropertyName).GetValue(sender, null);
            
            if(property.PropertyType == valueToSet.GetType())
            {
                property.SetValue(this, valueToSet);
            }
        }

        /// <summary>
        /// Main loop of application
        /// </summary>
        public void RunApplication()
        {
            Console.WriteLine("Hello User!");
            Console.WriteLine("Welcome to MVVM bank");
            var loopStatus = true;
            while(loopStatus)
            {
                Console.Clear();
                Console.WriteLine("Choose options:");
                Console.WriteLine("1. Add customer");
                Console.WriteLine("2. Deposit money to account");
                Console.WriteLine("3. Withdraw money from account");
                Console.WriteLine("4. Check account balance");
                Console.WriteLine("5. Exit");
                var userInput = Console.ReadLine();
                int inputValue = -1;
                if(!int.TryParse(userInput, out inputValue))
                {
                    Console.WriteLine("Invalid inputs exiting from application");
                }

                switch (inputValue)
                {
                    case 1:
                    {
                        Console.WriteLine("Adding customer");
                        Console.WriteLine("Enter customer name : ");
                        vm.AddCustomer(Console.ReadLine());
                    }
                    break;
                    case 2:
                    {
                        Console.WriteLine("Depositing money");
                        vm.DepositMoney();
                    }
                    break;
                    case 3:
                    {
                        Console.WriteLine("Withdrawing money");
                        vm.WithdrawMoney();
                    }
                    break;
                    case 4:
                    {
                        Console.WriteLine("Checking account balance");
                        vm.CheckBalance();
                    }
                    break;
                    default:
                        loopStatus = false;
                    break;
                }
            }
        }
    }
}