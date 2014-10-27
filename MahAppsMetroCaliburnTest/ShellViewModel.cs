using Caliburn.Micro;
using MahAppsMetroCaliburnTest.ViewModels.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MahAppsMetroCaliburnTest
{
    public class ShellViewModel : Screen, IShell
    {
        private IDialogManager dialogManager;
        private IWindowManager windowManager;

        public ShellViewModel(IDialogManager dialogManager, IWindowManager windowManager)
        {
            this.dialogManager = dialogManager;
            this.windowManager = windowManager;
        }

        public async void ShowMetroDialog()
        {
            var result = await this.dialogManager.ShowDialog(new TestMahAppsDialogViewModel());
        }

        public void ShowPopupWithSimpleDialog()
        {
            this.windowManager.ShowDialog(new TestMahAppsDialogViewModel());
        }

        public void ShowPopupUserControl()
        {
            this.windowManager.ShowDialog(new UserControlDialogViewModel());
        }
    }
}
