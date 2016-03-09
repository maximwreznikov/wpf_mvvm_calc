using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;

namespace CalculatorMVVM.ViewModels
{
    [Export]
    public class CalculatorViewModel : ViewModelBase
    {
        public CalculatorViewModel()
        {
            var operations = new List<CalculatorOperation>
            {
                new CalculatorOperation("Плюс", (a, b) => a + b),
                new CalculatorOperation("Минус", (a, b) => a - b),
                new CalculatorOperation("Умножить", (a, b) => a * b),
                new CalculatorOperation("Поделить", (a, b) => a / b)
            };
            Operations = operations;
            CurrentOperation = Operations.First();

            TestCommand = new DelegateCommand(() =>
            {
                FirstParameter = 7;
                SecondParameter = 6;
                CurrentOperation = Operations.Single((o) => o.Name.Equals("Умножить"));
            });
        }

        private void Update()
        {
            Result = _currentOperation.Calc(FirstParameter, SecondParameter);
        }

        #region Property

        private double _firstParameter;
        public double FirstParameter 
        { 
            get { return _firstParameter; }
            set 
            { 
                SetProperty(ref _firstParameter, value, () => FirstParameter);
                Update();
            }
        }

        private double _secondParameter;
        public double SecondParameter
        {
            get { return _secondParameter; }
            set { SetProperty(ref _secondParameter, value, () => SecondParameter); Update(); }
        }

        private double _result;
        public double Result 
        { 
            get { return _result; }
            private set { SetProperty(ref _result, value, () => Result); } 
        }

        private CalculatorOperation _currentOperation;
        public CalculatorOperation CurrentOperation
        {
            get{ return _currentOperation; }
            set { SetProperty(ref _currentOperation, value, () => CurrentOperation); Update(); }
        }

        private List<CalculatorOperation> _operations;
        public List<CalculatorOperation> Operations
        {
            get { return _operations; }
            set { SetProperty(ref _operations, value, () => Operations); }
        }

        #endregion

        #region Commands 
        public DelegateCommand TestCommand { get; private set; }
        #endregion
    }
}
