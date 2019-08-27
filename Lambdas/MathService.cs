using System;
using System.Timers;

namespace Lambdas {

    public class MathService {

        public delegate void MathPerformedHandler(double result);
        public delegate double CalculationHandler(double value1, double value2);

        public event EventHandler<MathPerformedEventArgs> MathPerformed;
        public event MathPerformedHandler MathPerformedCustom;


        public Action<double> MathPerform;
        //public Func<double, double, double> Calculation; -> Last one is return type

        public void MultiplyNumbers(double first, double second) {
            MathPerformed(this, new MathPerformedEventArgs { Result = first * second});
        }

        public void MultiplyNumbersCustom(double first, double second) {
            MathPerformedCustom(first + second);
        }

        public void CalculateNumbers(double first, double second, CalculationHandler calculationHandler) {
            MathPerformedCustom(calculationHandler(first, second));
        }

        public void CalculateActionNumbers(double first, double second, Func<double, double, double> calculation) {
            MathPerform(calculation(first, second));
        }
    }
}
