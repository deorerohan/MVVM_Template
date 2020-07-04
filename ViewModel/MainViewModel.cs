using System;
using Model;

namespace ViewModel
{
    /// <summary>
    /// This is view model module class. Derived from ViewModelBase for Property binding behavior.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private string someValue;
        
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

                OnPropertyChanged("SomeValue");
            }
        }

        public MainViewModel()
        {
            var model = new ModelData();
        }

        public void ChangeValues()
        {
            SomeValue = "Value from MainViewModel";
        }
    }
}
