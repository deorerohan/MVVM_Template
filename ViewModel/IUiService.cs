namespace ViewModel
{
    /// <summary>
    /// Interface defining UI services reqired by view model to inform updated to view.
    /// </summary>
    public interface IUiService
    {
        void ShowUserMessage(string msg);
    }
}