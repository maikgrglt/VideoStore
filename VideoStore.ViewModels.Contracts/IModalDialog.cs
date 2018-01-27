namespace VideoStore.ViewModels.Contracts
{
    public interface IModalDialog : IDialog
    {
        ModalResult ModalResult { get; set; }
    }
}