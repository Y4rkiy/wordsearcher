using System;

namespace wordsearcher
{
    class Program
    {
        public static bool SearchNearest(int pos1, int pos2, char[,] arr, char chr, string word, int k, string res, int bound)
        {
            k++;
            res += $"[{pos1},{pos2}]";
            if (k == word.Length)
            {
                Console.WriteLine(res);
                return true;
            }
            res += "->";
            if ((pos2 < bound) && (word[k] == arr[pos1, pos2 + 1]))
            {
                Console.WriteLine(arr[pos1, pos2 + 1]);
                SearchNearest(pos1, pos2 + 1, arr, chr, word, k, res, bound);
            }
            if ((pos1 < bound) && (word[k] == arr[pos1 + 1, pos2]))
            {

                Console.WriteLine(arr[pos1 + 1, pos2]);
                SearchNearest(pos1 + 1, pos2, arr, chr, word, k, res, bound);
            }
            if ((pos2 > 0) && (word[k] == arr[pos1, pos2 - 1]))
            {
                Console.WriteLine(arr[pos1, pos2 - 1]);

                SearchNearest(pos1, pos2 - 1, arr, chr, word, k, res, bound);
            }
            if ((pos1 > 0) && (word[k] == arr[pos1 - 1, pos2]))
            {
                Console.WriteLine(arr[pos1, pos2 - 1]);

                SearchNearest(pos1 - 1, pos2, arr, chr, word, k, res, bound);
            }
            return false;
        }

        public static void ArrayChecker(int sqrtsize, char[,] matrix, string word)
        {
            int k;
            string result = "";
            for (int i = 0; i < sqrtsize; i++)
            {
                for (int j = 0; j < sqrtsize; j++)
                {
                    if (matrix[i, j] == word[0])
                    {
                        k = 0;
                        if (SearchNearest(i, j, matrix, word[0], word, k, result, sqrtsize - 1))
                        {
                            return;
                        }
                    }
                }
            }
            return;
        }

        static void Main(string[] args)
        {
            string input1 = Console.ReadLine().ToLower();
            string input2 = Console.ReadLine().ToLower();
            int size = input1.Length;
            int sqrtsize = (int)Math.Sqrt(size);
            char[,] matrix = new char[sqrtsize, sqrtsize];
            int z = 0;
            for (int i = 0; i < sqrtsize; i++)
            {
                for (int j = 0; j < sqrtsize; j++)
                {
                    matrix[i, j] = input1[z++];
                }
            }

            ArrayChecker(sqrtsize, matrix, input2);

        }
    }
}
