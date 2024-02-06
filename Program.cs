using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class Program
{
    static void Main(string[] args)
    {
        int[] array = { 1, 2, -5, 3, 4, 5, 0, 9, 0, 1, 10, 3, -5, -3, -9, 10, 0, 7, 8 };

        for (int i = 0; i < array.Length; i++)
        {
            int num = array[i];
            int count = 0;

            bool coincidence = false;
            for (int j = 0; j < i; j++)
            {
                if (array[j] == num)
                {
                    coincidence = true;
                    break;
                }
            }

            if (!coincidence)
            {
                for (int k = 0; k < array.Length; k++)
                {
                    if (array[k] == num)
                    {
                        count++;
                    }
                }
                Console.WriteLine($" {num}  - {count} ");
            }
        }
    }
}
