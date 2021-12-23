using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelling_salesman_problem {
    class Tests {
        public void StartTesting(int start, int n) {
            StartApprox(start, n);
            StartBruteForce(start, n);
            //StartHeuristic(start, n);
        }

        private void StartBruteForce(int start, int n) {
            int[,] matrix;
            int numTests = 10000;
            using (StreamWriter sw = new StreamWriter("BruteForceResult.txt", false)) {

            }
            for (int i = start; i <= n; i++) {
                Console.WriteLine(i);

                if (i == 10) {
                    numTests /= 10;
                }
                if (i == 12) {
                    numTests = 100;
                }
                if (i > 12) {
                    numTests = 30;
                }
                if (i == 14) {
                    numTests = 7;
                }
                string result = "";
                result += "Результат для алгоритма полного перебора при V = " + i;
                double totalTime = 0.0;
                double countRightAnswers = 0.0;
                double otkl = 0.0;

                using (StreamReader sr = new StreamReader("matrix" + i + ".txt")) {
                    for (int j = 0; j < numTests; j++) {
                        Salesman salesman = new Salesman();
                        string line = sr.ReadLine();
                        matrix = new int[i, i];
                        string[] splitLine = line.Split(" ");
                        int numV = Convert.ToInt32(splitLine[0]);
                        int profit = Convert.ToInt32(splitLine[1]);
                        for (int k = 0; k < i; k++) {
                            line = sr.ReadLine();
                            string[] spLine = line.Split(" ");
                            for (int h = 0; h < i; h++) {
                                matrix[k, h] = Convert.ToInt32(spLine[h]);
                            }
                        }
                        line = sr.ReadLine();
                        splitLine = line.Split(" ");
                        List<int> rightAnswer = new List<int>();
                        int rightProfit = 0;
                        for (int k = 0; k < splitLine.Length; k++) {
                            rightAnswer.Add(Convert.ToInt32(splitLine[k]));
                        }
                        line = sr.ReadLine();
                        rightProfit = Convert.ToInt32(line);
                        line = sr.ReadLine();
                        Stopwatch time = new Stopwatch();
                        salesman.ReadFromMatrix(matrix, numV, profit);
                        time.Start();
                        salesman.BruteForceAlgorithm();
                        time.Stop();
                        totalTime += time.Elapsed.TotalMilliseconds;
                        if (rightProfit == salesman.GetMaxProfit()) {
                            countRightAnswers++;
                        }
                        else {
                            if (rightProfit == 0) {
                                otkl += Math.Abs(salesman.GetMaxProfit());
                            }
                            else {
                                otkl += Convert.ToDouble(Math.Abs(salesman.GetMaxProfit() - rightProfit)) / Convert.ToDouble(rightProfit);
                            }
                        }
                    }
                }
                result += ", время работы алгоритма: " + totalTime / numTests + "мс. Процент правильных ответов: " + countRightAnswers / numTests * 100 + "%. Ср. относ. откл.: " + otkl / numTests;
                using (StreamWriter sw = new StreamWriter("BruteForceResult.txt", true)) {
                    sw.WriteLine(result);
                }
            }
        }

        private void StartApprox(int start, int n) {
            int[,] matrix;
            int numTests = 10000;
            using(StreamWriter sw=new StreamWriter("ApproxResult.txt", false)) {

            }
            for (int i = start; i <= n; i++) {
                Console.WriteLine(i);

                if (i == 10) {
                    numTests /= 10;
                }
                if (i == 12) {
                    numTests = 100;
                }
                if (i > 12) {
                    numTests = 30;
                }
                if (i == 14) {
                    numTests = 7;
                }
                string result = "";
                result += "Результат для приближенного алгоритма при V = " + i;
                double totalTime = 0.0;
                double countRightAnswers = 0.0;
                double otkl = 0.0;

                using (StreamReader sr = new StreamReader("matrix" + i + ".txt")) {
                    for (int j = 0; j < numTests; j++) {
                        Salesman salesman = new Salesman();
                        string line = sr.ReadLine();
                        matrix = new int[i, i];
                        string[] splitLine = line.Split(" ");
                        int numV = Convert.ToInt32(splitLine[0]);
                        int profit = Convert.ToInt32(splitLine[1]);
                        for(int k = 0; k < i; k++) {
                            line = sr.ReadLine();
                            string[] spLine = line.Split(" ");
                            for(int h = 0; h < i; h++) {
                                matrix[k, h] = Convert.ToInt32(spLine[h]);
                            }
                        }
                        line = sr.ReadLine();
                        splitLine = line.Split(" ");
                        List<int> rightAnswer = new List<int>();
                        int rightProfit = 0;
                        for(int k = 0; k < splitLine.Length; k++) {
                            rightAnswer.Add(Convert.ToInt32(splitLine[k]));
                        }
                        line = sr.ReadLine();
                        rightProfit = Convert.ToInt32(line);
                        line = sr.ReadLine();
                        Stopwatch time = new Stopwatch();
                        salesman.ReadFromMatrix(matrix, numV, profit);
                        time.Start();
                        salesman.ApproximateAlgorithm();
                        time.Stop();
                        totalTime += time.Elapsed.TotalMilliseconds;
                        if (rightProfit == salesman.GetMaxProfit()) {
                            countRightAnswers++;
                        }
                        else {
                            if (rightProfit == 0) {
                                otkl += Math.Abs(salesman.GetMaxProfit());
                            }
                            else {
                                otkl += Convert.ToDouble(Math.Abs(salesman.GetMaxProfit() - rightProfit)) / Convert.ToDouble(rightProfit);
                            }
                        }
                    }
                }
                result += ", время работы алгоритма: " + totalTime / numTests + "мс. Процент правильных ответов: " + countRightAnswers / numTests * 100 + "%. Ср. относ. откл.: " + otkl / numTests;
                using(StreamWriter sw=new StreamWriter("ApproxResult.txt", true)) {
                    sw.WriteLine(result);
                }
            }
            
        }

        private void StartHeuristic(int start, int n) {
            int[,] matrix;
            int numTests = 10000;
            using (StreamWriter sw = new StreamWriter("HeuristicResult.txt", false)) {

            }
            for (int i = start; i <= n; i++) {
                Console.WriteLine(i);

                if (i == 10) {
                    numTests /= 10;
                }
                if (i == 12) {
                    numTests = 100;
                }
                if (i > 12) {
                    numTests = 30;
                }
                if (i == 14) {
                    numTests = 7;
                }
                string result = "";
                result += "Результат для муравьиного алгоритма при V = " + i;
                double totalTime = 0.0;
                double countRightAnswers = 0.0;
                double otkl = 0.0;

                using (StreamReader sr = new StreamReader("matrix" + i + ".txt")) {
                    for (int j = 0; j < numTests; j++) {
                        Salesman salesman = new Salesman();
                        string line = sr.ReadLine();
                        matrix = new int[i, i];
                        string[] splitLine = line.Split(" ");
                        int numV = Convert.ToInt32(splitLine[0]);
                        int profit = Convert.ToInt32(splitLine[1]);
                        for (int k = 0; k < i; k++) {
                            line = sr.ReadLine();
                            string[] spLine = line.Split(" ");
                            for (int h = 0; h < i; h++) {
                                matrix[k, h] = Convert.ToInt32(spLine[h]);
                            }
                        }
                        line = sr.ReadLine();
                        splitLine = line.Split(" ");
                        List<int> rightAnswer = new List<int>();
                        int rightProfit = 0;
                        for (int k = 0; k < splitLine.Length; k++) {
                            rightAnswer.Add(Convert.ToInt32(splitLine[k]));
                        }
                        line = sr.ReadLine();
                        rightProfit = Convert.ToInt32(line);
                        line = sr.ReadLine();
                        Stopwatch time = new Stopwatch();
                        salesman.ReadFromMatrix(matrix, numV, profit);
                        time.Start();
                        salesman.HeuristicAlgorithm();
                        time.Stop();
                        totalTime += time.Elapsed.TotalMilliseconds;
                        if (rightProfit == salesman.GetMaxProfit()) {
                            countRightAnswers++;
                        }
                        else {
                            Console.WriteLine(j);
                            if (rightProfit == 0) {
                                otkl += Math.Abs(salesman.GetMaxProfit());
                            }
                            else {
                                otkl += Convert.ToDouble(Math.Abs(salesman.GetMaxProfit() - rightProfit)) / Convert.ToDouble(rightProfit);
                            }
                        }
                    }
                }
                result += ", время работы алгоритма: " + totalTime / numTests + "мс. Процент правильных ответов: " + countRightAnswers / numTests * 100 + "%. Ср. относ. откл.: " + otkl / numTests;
                using (StreamWriter sw = new StreamWriter("HeuristicResult.txt", true)) {
                    sw.WriteLine(result);
                }
            }

        }
        public void CreateDataTest(int start,int n) {
            int[,] matrix;
            int numTests = 10000;
            int s=0;
            for(int i = start; i <= n; i++) {
                Console.WriteLine(i);
                if (i == 10) {
                    numTests /= 10;
                }
                if (i == 12) {
                    numTests = 100;
                }
                if (i > 12) {
                    numTests = 10;
                }
                using (StreamWriter sw = new StreamWriter("matrix" + i + ".txt", false)) {
                    for (int j = 0; j < numTests; j++) {
                        if (i > 9) {
                            Console.WriteLine(j);
                        }
                        Salesman salesman = new Salesman();
                        matrix = new int[i, i];
                        CreateRandomData(ref matrix, ref s, i);
                        string line = "";
                        line += i;
                        line += " " + s;
                        sw.WriteLine(line);
                        for(int t = 0; t < i; t++) {
                            line = "";
                            for(int y = 0; y < i; y++) {
                                line += matrix[t, y] + " ";
                            }
                            line.Remove(line.Length - 1);
                            sw.WriteLine(line);
                        }
                        salesman.ReadFromMatrix(matrix, i, s);
                        string[] result = new string[2];
                        salesman.BruteForceAlgorithm();
                        result = salesman.GetResult();
                        sw.WriteLine(result[0]);
                        sw.WriteLine(result[1]);
                        sw.WriteLine();
                    }
                }

            }
        }

        public void CreateDataTestWithoutCheck(int start, int n) {
            int[,] matrix;
            int numTests = 10000;
            int s = 0;
            for (int i = start; i <= n; i++) {
                Console.WriteLine(i);
                //if (i == 10) {
                //    numTests /= 10;
                //}
                //if (i == 12) {
                //    numTests = 100;
                //}
                //if (i > 12) {
                //    numTests = 10;
                //}
                using (StreamWriter sw = new StreamWriter("matrix" + i + ".txt", false)) {
                    for (int j = 0; j < numTests; j++) {
                        //if (i > 9) {
                        //    Console.WriteLine(j);
                        //}
                        //Salesman salesman = new Salesman();
                        matrix = new int[i, i];
                        CreateRandomData(ref matrix, ref s, i);
                        string line = "";
                        line += i;
                        line += " " + s;
                        sw.WriteLine(line);
                        for (int t = 0; t < i; t++) {
                            line = "";
                            for (int y = 0; y < i; y++) {
                                line += matrix[t, y] + " ";
                            }
                            line.Remove(line.Length - 1);
                            sw.WriteLine(line);
                        }
                        //salesman.ReadFromMatrix(matrix, i, s);
                        //string[] result = new string[2];
                        //salesman.BruteForceAlgorithm();
                        //result = salesman.GetResult();
                        //sw.WriteLine(result[0]);
                        //sw.WriteLine(result[1]);
                        sw.WriteLine();
                    }
                }

            }
        }

        private void CreateRandomData(ref int[,]matrix, ref int s,int n) {
            Random rnd = new Random();
            s = rnd.Next(10, 21);
            for(int i = 0; i < n; i++) {
                for(int j = 0; j < n; j++) {
                    if (i == j) {
                        matrix[i, j] = 0;
                    }
                    else {
                        matrix[i, j] = rnd.Next(0, 16);
                    }
                }
            }
        }
    }
}
