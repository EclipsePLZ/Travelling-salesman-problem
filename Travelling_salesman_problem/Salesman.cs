using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travelling_salesman_problem {
    class Salesman {
        private int[,] citiesMatrix;
        private int n;
        private int s;
        private List<int> bestWay = new List<int>();
        private int maxProfit = 0;

        public void ReadFromFile(string path) {
            using (StreamReader sr=new StreamReader(path)) {
                string line = "";
                line = sr.ReadLine();
                string[] splitLine = line.Split(" ");
                n = Convert.ToInt32(splitLine[0]);
                s = Convert.ToInt32(splitLine[1]);
                citiesMatrix = new int[n, n];
                for(int i = 0; i < n; i++) {
                    line = sr.ReadLine();
                    splitLine = line.Split(" ");
                    for(int j = 0; j < n; j++) {
                        citiesMatrix[i, j] = Convert.ToInt32(splitLine[j]);
                    }
                }
            }
        }

        public void ReadFromMatrix(int[,] matrix,int k,int cost) {
            n = k;
            s = cost;
            citiesMatrix = new int[n, n];
            for(int i = 0; i < n; i++) {
                for(int j = 0; j < n; j++) {
                    citiesMatrix[i, j] = matrix[i, j];
                }
            }
        }

        public string[] GetResult() {
            string[] result = new string[2];
            result[0] = "1 ";
            for(int i = 0; i < bestWay.Count; i++) {
                result[0] += Convert.ToString(bestWay[i] + 1) + " ";
            }
            result[0]+="1";
            result[1] = Convert.ToString(maxProfit);
            return result;
        }

        public void BruteForceAlgorithm() {
            bool[] s = new bool[n];

            for(int i = 0; i < n; i++) {
                s[i] = false;
            }
            s[0] = true;
            while (!s[n - 1]) {
                CheckBest(s);
                int j = 0;
                while (s[j]) {
                    s[j] = false;
                    j++;
                }
                s[j] = true;
                
            }
            ShowResult();
        }

        private void CheckBest(bool[] s) {
            List<int> cities = new List<int>();
            for(int i = 0; i < s.Length-1; i++) {
                if (s[i]) {
                    cities.Add(i+1);
                }
            }

            int[] v = new int[cities.Count + 2];
            int[] pos = new int[cities.Count];
            int[] d = new int[cities.Count];
            for(int i = 0; i < cities.Count; i++) {
                v[i + 1] = i;
                pos[i] = i + 1;
                d[i] = -1;
            }
            v[0] = n + 1;
            v[cities.Count + 1] = n + 1;

            while (true) {
                int tempProfit = FindProfit(cities);
                if (tempProfit > maxProfit) {
                    maxProfit = tempProfit;
                    bestWay = new List<int>();
                    bestWay.Add(0);
                    bestWay.AddRange(cities);
                    bestWay.Add(0);
                }
                int x = cities.Count - 1;
                while (v[pos[x] + d[x]] > x && x > 0) {
                    d[x] *= -1;
                    x--;
                }
                if (x == 0) {
                    break;
                }
                int y = v[pos[x] + d[x]];
                Swap(ref v, pos[x], pos[x] + d[x]);
                Swap(ref cities, v[pos[x]], v[pos[x] + d[x]]);
                Swap(ref pos, x, y);
            }
        }

        private int FindProfit(List<int>cities) {
            int profit = 0;
            int start = 0;
            for(int i = 0; i < cities.Count; i++) {
                if (citiesMatrix[start, cities[i]] != 0) {
                    profit += s - citiesMatrix[start, cities[i]];
                    start = cities[i];
                }
                else {
                    return 0;
                }
            }
            if (citiesMatrix[start, 0] != 0) {
                profit += s - citiesMatrix[start, 0];
                return profit;
            }
            return 0;
        }

        private void Swap(ref List<int> cities,int pos1,int pos2) {
            int temp = cities[pos1];
            cities[pos1] = cities[pos2];
            cities[pos2] = temp;
        }

        private void Swap(ref int[] arr, int pos1, int pos2) {
            int temp = arr[pos1];
            arr[pos1] = arr[pos2];
            arr[pos2] = temp;
        }

        private void ShowResult() {
            Console.Write("Лучший путь: " );
            for (int i = 0; i < bestWay.Count; i++) {
                Console.Write(bestWay[i] + 1 + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Прибыль: " + maxProfit);
        }

        public void ApproximateAlgorithm() {
            int startV = 0;
            int finishV = 0;
            bestWay.Add(0);
            //int[,] tempMatrix = new int[n, n];
            //CloneMatrix(ref tempMatrix,citiesMatrix);
            while (true) {
                int minCost = int.MaxValue;
                for (int i = 1; i < n; i++) {
                    if (citiesMatrix[startV, i]!=0&&citiesMatrix[startV, i] < minCost&&!bestWay.Contains(i)) {
                        minCost = citiesMatrix[startV, i];
                        finishV = i;
                    }
                }
                if (minCost == int.MaxValue) {
                    TryToEnd();
                    break;
                }
                else {
                    bestWay.Add(finishV);
                    maxProfit += s - minCost;
                    startV = finishV;
                }
            }
            ShowResult();

        }

        private void TryToEnd() {
            for(int i = bestWay[bestWay.Count - 1]; i > 0; i--) {
                if (citiesMatrix[i, 0] != 0) {
                    bestWay.Add(0);
                    maxProfit += s - citiesMatrix[i, 0];
                    return;
                }
                else {
                    bestWay.RemoveAt(i);
                    maxProfit -= s - citiesMatrix[i, 0];
                }
            }
        }

        private void CloneMatrix(ref int[,] toMatrix, int[,] fromMatrix) {
            for(int i = 0; i < n; i++) {
                for(int j = 0; j < n; j++) {
                    toMatrix[i, j] = fromMatrix[i, j];
                }
            }
        }

        public void HeuristicAlgorithm() {

        }
    }
}
