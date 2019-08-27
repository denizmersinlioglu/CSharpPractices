using System;

namespace EventsDelegates {
    public class MathPerformedEventArgs : EventArgs {

        public double MathResult { get; set; }

        public MathPerformedEventArgs(double result) {
            this.MathResult = result;
        }
    }
}
