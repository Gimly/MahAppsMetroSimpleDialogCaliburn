using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahAppsMetroCaliburnTest
{
    public abstract class DialogViewModel<TResult> : PropertyChangedBase
    {
        private readonly TaskCompletionSource<TResult> taskCompletionSource;

        protected DialogViewModel()
            : base()
        {
            this.taskCompletionSource = new TaskCompletionSource<TResult>();
        }

        protected void Close(TResult result)
        {
            this.taskCompletionSource.SetResult(result);
        }

        internal Task<TResult> Task
        {
            get
            {
                return this.taskCompletionSource.Task;
            }
        }
    }
}
