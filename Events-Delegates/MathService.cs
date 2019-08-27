using System;

namespace EventsDelegates {

    public class MathService {

        public delegate double ResultHandler(double first, double second);
        public delegate void OutboundHandler(double result);

        public ResultHandler MathDelegate;
        public event OutboundHandler OutboundEvent;

        public MathService() {
            MathDelegate = AddNumbers;
            MathDelegate += MultiplyNumbers;
        }

        private double AddNumbers(double first, double second) {
            var res = first + second;
            OutboundEvent(res);
            return res;
        }

        private double MultiplyNumbers(double first, double second) {
            var res = first * second;
            OutboundEvent(res);
            return res;
        }
    }


    public class SystemEventMathService {

        // public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e);
        public event EventHandler<MathPerformedEventArgs> MathPerformed;

        public double AddNumbers(double first, double second) {
            var res = first + second;
            MathPerformed(this, new MathPerformedEventArgs(res));
            return res;
        }

        public double MultiplyNumbers(double first, double second) {
            var res = first * second;
            MathPerformed(this, new MathPerformedEventArgs(res));
            return res;
        }
    }
}