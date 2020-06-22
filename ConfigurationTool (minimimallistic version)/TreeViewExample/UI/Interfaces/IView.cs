namespace ConfigurationToolStructurePOC.UI.Interfaces
{
    public interface IView
    {
        void ShowMessage(string text);
        bool ConfirmMessage(string title, string text);
        void CloseWindow();
    }
}
