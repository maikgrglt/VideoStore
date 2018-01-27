using System;
using System.Collections.Generic;
using System.Windows;
using Provider.Contracts;
using VideoStore.ViewModels.Contracts;
using VideoStore.Views;

namespace Provider
{
    public class ViewProvider : IViewProvider
    {
        private readonly List<Window> _windows;


        public ViewProvider()
        {
            _windows = new List<Window>();
        }

        public void ShowDialogModal(IModalDialog dialog)
        {
            if (dialog == null)
                return;

            var placeHolderWindow = new PlaceHolderDialog();
            placeHolderWindow.DataContext = dialog;

            _windows.Add(placeHolderWindow);
            placeHolderWindow.ShowDialog();
        }

        public void ShowDialog(IDialog dialog)
        {
            if (dialog == null)
                return;

            var placeHolderWindow = new PlaceHolderDialog();
            placeHolderWindow.DataContext = dialog;

            _windows.Add(placeHolderWindow);
            placeHolderWindow.Closed += PlaceHolderWindowOnClosed;
            placeHolderWindow.Show();
        }

        private void PlaceHolderWindowOnClosed(object sender, EventArgs eventArgs)
        {
            Window window = (Window) sender;
            _windows.Remove(window);
            window.Closed -= PlaceHolderWindowOnClosed;
        }

        public void Close(IDialog dialog)
        {
            if (dialog == null)
                return;

            foreach (var window in _windows)
            {
                if (window.DataContext == dialog)
                {
                    window.Close();
                    _windows.Remove(window);
                    break;
                }
            }
        }
    }
}
