using System;
using Model;

namespace ViewModel
{
    /// <summary>
    /// This is view model module class. Derived from ViewModelBase for Property binding behavior.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        IUiService UiService;

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

        public MainViewModel(IUiService service)
        {
            var model = ModelData.Instance;
            model.ShowUserMessage_Event += ShowUserMessage;
            UiService = service;
        }

        void ShowUserMessage(string msg)
        {
            UiService.ShowUserMessage(msg);
        }

        public void ChangeValues()
        {
            SomeValue = "Value from MainViewModel";
        }

        public void AddCustomer(string name)
        {
            ModelData.Instance.AddCustomer(name);
        }

        public void DepositMoney(uint accID, double amount)
        {
            ModelData.Instance.DepositMoney(accID, amount);
        }

        public void WithdrawMoney(uint accID, double amount)
        {
            ModelData.Instance.WithdrawMoney(accID, amount);
        }

        public double CheckBalance(uint accountID)
        {
            return ModelData.Instance.CheckBalance(accountID);
        }
    }
}
