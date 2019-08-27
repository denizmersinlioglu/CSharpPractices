using System;

namespace EventsDelegates {

    public class LoggingService : IMathPerformedService {

        public void OnMathPerformed(object sender, MathPerformedEventArgs args) {
            Console.WriteLine("Logging Result: " + args.MathResult);
        }
    }
}
