using System;

namespace EventsDelegates {

    public interface IMathPerformedService {
        void OnMathPerformed(object sender, MathPerformedEventArgs args);
    }
}
