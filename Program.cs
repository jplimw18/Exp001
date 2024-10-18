using System;

namespace Desafio001 {
    class Program {
        static void Main(string[] args) {
            int[] nums = { 1, 2, 3, 4 }; // --> output: "1 2"\n"2 3"\n"3 4"
                                         //nums = new int[] { 5, -2, 12, 3 }; // --> output: "5 3"
                                         //nums = new int[] { 1, 2, 9 }; // --> output: "1 2"
                                         //nums = new int[] { -1, -5, 1 }; // --> output: "-1 1"
                                         //nums = new int[] { 0, 19, 13 }; // --> output: "19 13"

            Pares(nums);
        }

        static void Pares(int[] nums) {
            List<Tuple<int, int, int>> arr = new List<Tuple<int, int, int>>();
            int menor = 0, posX = 0, posY = 0;

            for (int i = 0, k = 0; i < nums.Length; i++, k++) {
                for (int j = i + 1; j < nums.Length; j++) {
                    if (j - 1 == i) {
                        menor = Math.Abs(nums[i] - nums[j]);
                        posX = i;
                        posY = j;
                    }
                    else {
                        if (menor > Math.Abs(nums[i] - nums[j])) {
                            menor = Math.Abs(nums[i] - nums[j]);
                            posX = i;
                            posY = j;
                        }
                    }
                }

                if (!arr.Contains(new Tuple<int, int, int>(menor, posX, posY))) {
                    if (k == 0) {
                        arr.Add(new Tuple<int, int, int>(menor, posX, posY));
                    }
                    else if (arr.Last().Item1 > menor) {
                        arr.Remove(arr.Last());
                        arr.Add(new Tuple<int, int, int>(menor, posX, posY));
                    }
                    else if (arr.Last().Item1 == menor) {
                        arr.Add(new Tuple<int, int, int>(menor, posX, posY));
                    }
                }
            }

            foreach (Tuple<int, int, int> par in arr) {
                Console.WriteLine($"({nums[par.Item2]}, {nums[par.Item3]})");
            }
        }

    }
}