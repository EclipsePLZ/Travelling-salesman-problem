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
    }
}
