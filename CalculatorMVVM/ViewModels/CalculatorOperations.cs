using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;

namespace CalculatorMVVM.ViewModels
{
    public class CalculatorOperation : ViewModelBase
    {
        private readonly Func<double, double, double> _operation;
        public CalculatorOperation(string name, Func<double, double, double> operation)
        {
            _name = name;
            _operation = operation;
        }

        #region Properties

        private string _name;
        public string Name
        {
            get { return _name; }
        }
        #endregion

        public double Calc(double fp, double sp)
        {
            return _operation.Invoke(fp, sp);
        }
    }
}
