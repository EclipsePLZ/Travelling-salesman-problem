using System;

namespace Travelling_salesman_problem {
    class Program {
        static void Main(string[] args) {
            //Salesman salesman = new Salesman();
            //salesman.ReadFromFile("input.txt");
            //salesman.HeuristicAlgorithm();
            //Salesman sl = new Salesman();
            //sl.ReadFromFile("input.txt");
            //sl.BruteForceAlgorithm();
            //salesman.ApproximateAlgorithm();
            Tests tests = new Tests();
            tests.StartTesting(2, 14);
            //tests.CreateDataTest(13,13);
            //tests.StartTesting(2, 10);
        }
    }
}
