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

        public ShellViewModel(IDialogManager dialogManager)
        {
            this.dialogManager = dialogManager;
        }

        public async void ShowMetroDialog()
        {
            var result = await this.dialogManager.ShowDialog(new TestMahAppsDialogViewModel());
        }
    }
}
