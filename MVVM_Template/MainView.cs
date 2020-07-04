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

            vm.ChangeValues();
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
            Console.WriteLine("Hello World!");
            Console.WriteLine(SomeValue);
        }
    }
}