using System;

namespace Travelling_salesman_problem {
    class Program {
        static void Main(string[] args) {
            //Salesman salesman = new Salesman();
            //salesman.ReadFromFile("input.txt");
            //salesman.ApproximateAlgorithm();
            Tests tests = new Tests();
            //tests.CreateDataTest(13,13);
            tests.StartTesting(2, 10);
        }
    }
}
