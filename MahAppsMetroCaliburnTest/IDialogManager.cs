using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahAppsMetroCaliburnTest
{
    public interface IDialogManager
    {
        Task<TResult> ShowDialog<TResult>(DialogViewModel<TResult> dialogViewModel);
    }
}
