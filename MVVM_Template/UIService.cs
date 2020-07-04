using ViewModel;

namespace MVVM_Template
{
    class UIService : IUiService
    {
        MainView View
        {
            get; set;
        }

        public UIService(MainView view)
        {
            View = view;
        }

        public void ShowUserMessage(string msg)
        {
            View.UserUpdates.Add(msg);
        }
    }
}