using System;

namespace LabaDop
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Hello World!");
                Fraction a = new Fraction(1, 2);
                Fraction b = new Fraction(3, 4);
                Console.WriteLine("1");
                
                Console.WriteLine(a + b);
                Console.WriteLine(a - b);
                Console.WriteLine(a.Equals(b));
                Console.WriteLine(a * b);
                Console.WriteLine(a / b);
                Console.WriteLine(a > b);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e);
                
            }
            
        }
    }
}
