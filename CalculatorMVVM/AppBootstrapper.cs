using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CalculatorMVVM.View;
using CalculatorMVVM.ViewModels;
using DevExpress.Mvvm;
using Prism.Mef;

namespace CalculatorMVVM
{
    public class AppBootstrapper : MefBootstrapper
    {
        public ContentControl CalculatorView { get; set; }
        
        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();

            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(this.GetType().Assembly));
        }

        protected override DependencyObject CreateShell()
        {
            CalculatorView = Container.GetExportedValue<CalculatorView>();
            Debug.Assert(CalculatorView.DataContext == null);
            return CalculatorView;
        }


        protected override void InitializeShell()
        {
            base.InitializeShell();
            CalculatorView.DataContext = this.Container.GetExportedValue<CalculatorViewModel>();
        }
    }
}
