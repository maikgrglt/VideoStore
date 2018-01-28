using VideoStore.ViewModels.Contracts;

namespace Provider.Contracts
{
    public interface IViewProvider
    {
        void ShowDialogModal(IModalDialog dialog);
        void ShowDialog(IDialog dialog);
        void ShowMessageBox(string message);
        void Close(IDialog dialog);
    }
}