using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelling_salesman_problem {
    class Tests {
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
