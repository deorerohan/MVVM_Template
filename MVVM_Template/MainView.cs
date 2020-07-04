using System;
using System.ComponentModel;
using ViewModel;
using System.Collections.Generic;

namespace MVVM_Template
{
    /// <summary>
    /// Main view class representing View module in MVVM architecture.
    /// This class contains main loop for application
    /// </summary>
    class MainView
    {
        public List<string> UserUpdates = new List<string>();
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
            var uiService = new UIService(this);
            vm = new MainViewModel(uiService);
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

        private int GetUserInput()
        {
            var userInput = Console.ReadLine();
            int inputValue = -1;
            if(!int.TryParse(userInput, out inputValue))
            {
                Console.WriteLine("Invalid inputs exiting from application");
            }

            return inputValue;
        }

        private double GetUserInput_D()
        {
            var userInput = Console.ReadLine();
            double inputValue = -1;
            if(!double.TryParse(userInput, out inputValue))
            {
                Console.WriteLine("Invalid inputs exiting from application");
            }

            return inputValue;
        }

        /// <summary>
        /// Main loop of application
        /// </summary>
        public void RunApplication()
        {
            var originalForegroundColor = Console.ForegroundColor;
            Console.WriteLine("Hello User!");
            Console.WriteLine("Welcome to MVVM bank");
            Console.ReadKey();
            var loopStatus = true;
            while(loopStatus)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                foreach (var msg in UserUpdates)
                {
                    Console.WriteLine(msg);
                }

                UserUpdates.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Choose options:");
                Console.WriteLine("1. Add customer");
                Console.WriteLine("2. Deposit money to account");
                Console.WriteLine("3. Withdraw money from account");
                Console.WriteLine("4. Check account balance");
                Console.WriteLine("5. Exit");
                int inputValue = GetUserInput();

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
                        Console.WriteLine("Enter valid account number : ");
                        var accNo = GetUserInput();
                        Console.WriteLine("Enter amount to deposit : ");
                        var amount = GetUserInput_D();
                        vm.DepositMoney(Convert.ToUInt32(accNo), amount);
                    }
                    break;
                    case 3:
                    {
                        Console.WriteLine("Withdrawing money");
                        Console.WriteLine("Enter valid account number : ");
                        var accNo = GetUserInput();
                        Console.WriteLine("Enter amount to deposit : ");
                        var amount = GetUserInput_D();
                        vm.WithdrawMoney(Convert.ToUInt32(accNo), amount);
                    }
                    break;
                    case 4:
                    {
                        Console.WriteLine("Checking account balance");
                        Console.WriteLine("Enter valid account number : ");
                        var accNo = GetUserInput();
                        Console.WriteLine(string.Format("For account {0} balance is : {1}", accNo, vm.CheckBalance(Convert.ToUInt32(accNo))));
                        Console.ReadKey();
                    }
                    break;
                    default:
                        loopStatus = false;
                    break;
                }
            }
            
            Console.ForegroundColor = originalForegroundColor;
        }
    }
}