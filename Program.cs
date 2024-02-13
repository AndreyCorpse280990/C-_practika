using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{

    static int NOD(int a, int b)

    {
        a = Math.Abs(a);

        b = Math.Abs(b);

        while (a != 0 && b != 0)
        {
            if (a > b)
            {
                a %= b;
            }
            else
            {
                b %= a;
            }
        }
        return a + b;
    }

    static int NOK(int a, int b)
    {
        return a + b / NOD(a, b);
    }

    static void TEST()
    {
        Console.Write("Enter a: ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter b: ");
        int b = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"NOD= {NOD(a, b)}");
        Console.WriteLine($"NOK= {NOK(a, b)}");

        int nod = 0, nok = 0;

        NodNok(a, b, ref nod, ref nok);
        Console.WriteLine($"NOD = {nod}");
        Console.WriteLine($"NOK = {nok}");
    }


    static void NodNok(int a, int b, ref int nod, ref int nok)
    {
        nod = NOD(a, b);
        nok = NOK(a, b);
    }
    static void Main(string[] args)

    {

        TEST();

    }


}


