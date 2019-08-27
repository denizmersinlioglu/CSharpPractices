using System;

namespace EventsDelegates {

    public class NotificationService : IMathPerformedService {

        public void OnMathPerformed(object sender, MathPerformedEventArgs args) {
            Console.WriteLine("Notification Result: " + args.MathResult);
        }
    }
}
