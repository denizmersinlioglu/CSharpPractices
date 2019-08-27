using System;
using System.Collections.Generic;
using EventsDelegates;
using Lambdas;
using Linq;

class Program {

    static void Main(string[] args) {
        PerfomEventDelegates();

        Console.WriteLine();

        PerformLambdas();

        Console.WriteLine();

        LinqProgram.QueryAnimalData();
        LinqProgram.QueryIntArray();
        LinqProgram.QueryStringArray();

        Console.WriteLine();

    }


    #region Events-Delegates
    static void PerfomEventDelegates() {
        var mathService = new EventsDelegates.MathService();
        mathService.OutboundEvent += OnOutboundEvent;
        mathService.MathDelegate(4.5, 455.5);

        var systemEventMathService = new SystemEventMathService();
        systemEventMathService.MathPerformed += OnOutboundSystemTypeEvent;

        new List<IMathPerformedService> {
            new LoggingService(), new NotificationService()}
        .ForEach(serv => systemEventMathService.MathPerformed += serv.OnMathPerformed);

        systemEventMathService.AddNumbers(4.44, 767.55);
        systemEventMathService.MultiplyNumbers(422.33, 5.45);
    }

    private static void OnOutboundEvent(double res) {
        Console.WriteLine("Outbound result: " + res);
    }

    private static void OnOutboundSystemTypeEvent(object sender, EventsDelegates.MathPerformedEventArgs args) {
        Console.WriteLine("Outbound result from system type: " + args.MathResult);
    }
    #endregion


    #region Lambdas
    static void PerformLambdas() {
        var mathService = new Lambdas.MathService();
        // Below to is identical, syntax sugar.
        mathService.MathPerformed += delegate (object sender, Lambdas.MathPerformedEventArgs e) {
            Console.WriteLine("Event no lambda: " + e.Result);
        };

        mathService.MathPerformed += (sender, e) =>
            Console.WriteLine("Event with lambda: " + e.Result);


        mathService.MathPerformedCustom += res =>
            Console.WriteLine("Custom event with lambda: " + res);

        mathService.MathPerform += res =>
            Console.WriteLine("Custom event with lambda Action<T>, Func<T>: " + res);


        mathService.MultiplyNumbers(1, 1);
        mathService.MultiplyNumbersCustom(1, 2);

        mathService.CalculateNumbers(1, 3, (a, b) => a * b);
        mathService.CalculateNumbers(1, 25, (a, b) => a * b);
        mathService.CalculateActionNumbers(1, 4, (a, b) => a * b);
        mathService.CalculateActionNumbers(1, 26, (a, b) => a * b);

    }

    #endregion
}
