// <copyright file="DialogManager.cs" company="LS Instruments">
//     Copyright (c) 2014 LS Instruments. All rights reserved.
// </copyright>
namespace MahAppsMetroCaliburnTest
{
    using Caliburn.Micro;
    using MahApps.Metro.Controls;
    using MahApps.Metro.Controls.Dialogs;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;

    public class DialogManager : IDialogManager
    {
        public async Task<TResult> ShowDialog<TResult>(DialogViewModel<TResult> dialogViewModel)
        {
            var view = ViewLocator.LocateForModel(dialogViewModel, null, null);

            var dialog = view as BaseMetroDialog;
            if (dialog == null)
            {
                throw new ArgumentException(String.Format("The view linked to the dialog view model {0} should inherit from BaseMetroDialog.", dialogViewModel.GetType()));
            }

            ViewModelBinder.Bind(dialogViewModel, dialog, null);

            var window = GetMainWindow();
            await window.ShowMetroDialogAsync(dialog);
            var result = await dialogViewModel.Task;
            await window.HideMetroDialogAsync(dialog);

            return result;
        }


        private MetroWindow GetMainWindow()
        {
            MetroWindow metroWindow = null;
            foreach (Window window in Application.Current.Windows)
            {
                if (window.IsVisible && window is MetroWindow)
                {
                    metroWindow = (MetroWindow)window;
                    break;
                }
            }

            if (metroWindow == null)
            {
                throw new InvalidOperationException(string.Format("The main view ({0}) does not inherit from MetroWindow and cannot display messages.", Application.Current.MainWindow.GetType()));
            }

            return metroWindow;
        }
    }
}