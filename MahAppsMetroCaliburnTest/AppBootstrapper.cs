// <copyright file="AppBootstrapper.cs" company="LS Instruments">
//     Copyright (c) 2014 LS Instruments. All rights reserved.
// </copyright>
namespace MahAppsMetroCaliburnTest
{
    using Caliburn.Micro;
    using SimpleInjector;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public class AppBootstrapper : BootstrapperBase
    {
        public static readonly Container Container = new Container();

        /// <summary>
        /// Initializes a new instance of the <see cref="AppBootstrapper"/> class.
        /// </summary>
        public AppBootstrapper()
        {
            this.Initialize();
        }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            this.DisplayRootViewFor<IShell>();
        }

        protected override void Configure()
        {
            Container.Register<IWindowManager, WindowManager>();
            Container.RegisterSingle<IEventAggregator, EventAggregator>();

            Container.RegisterSingle<IShell, ShellViewModel>();

            Container.Register<IDialogManager, DialogManager>();

            Container.Verify();
        }

        protected override object GetInstance(Type service, string key)
        {
            if (service == null)
            {
                var typeName = Assembly.GetExecutingAssembly().DefinedTypes.Where(x => x.Name.Contains(key)).Select(x => x.AssemblyQualifiedName).Single();

                service = Type.GetType(typeName);
            }

            if (service != null && !string.IsNullOrEmpty(key))
            {
                var typeName = Assembly.GetExecutingAssembly().DefinedTypes.Where(x => x.IsSubclassOf(service) && x.Name.Contains(key)).Select(x => x.AssemblyQualifiedName).Single();

                service = Type.GetType(typeName);
            }

            return Container.GetInstance(service);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return Container.GetAllInstances(service);
        }
    }
}
