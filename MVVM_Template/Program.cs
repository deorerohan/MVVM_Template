namespace MVVM_Template
{
    class Program
    {
        /// <summary>
        /// Main entry point for application.
        /// This function is starting main loop for application.
        /// </summary>
        static void Main(string[] args)
        {
            var view = new MainView();
            view.RunApplication();
        }
    }
}
