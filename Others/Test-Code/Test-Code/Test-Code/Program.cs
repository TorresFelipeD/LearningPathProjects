using System;
using System.Numerics;

namespace Test_Code
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string binario = "1111010101111"; // Cambia esto por tu número binario
            int countOperations = solution(binario);
            Console.WriteLine("El número decimal es: " + countOperations);

            string binaryString = new string('1', 400000); // Representación de "1" repetido 400,000 veces en binario
            BigInteger res = 0;

            // I'm totally skipping error handling here
            foreach (char c in binaryString)
            {
                res <<= 1;
                res += c == '1' ? 1 : 0;
            }

            Console.WriteLine("Valor representado como BigInteger:");
            Console.WriteLine(res.ToString());
        }

        public static int solution(string S)
        {
            int countOperations = 0;
            var decimalNumber = Convert.ToInt64(S, 2);

            while (decimalNumber>0)
            {
                if(decimalNumber % 2 == 0)
                {
                    decimalNumber/=2;
                    countOperations++;
                }
                else
                {
                    decimalNumber--;
                    countOperations++;
                }
            }

            return countOperations;
        }
    }
}
