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
                ComplexNum com = new ComplexNum(new Fraction(), new Fraction());
                ComplexNum com1 = new ComplexNum(a,a);
                ComplexNum com2 = new ComplexNum(b,b);
                Console.WriteLine(com1/com);
                Console.WriteLine(com1);
                Console.WriteLine(com1+com2);
                Console.WriteLine(com1-com2);
                Console.WriteLine(com1*com2);
                Console.WriteLine(com1/com2);
                Console.WriteLine(com1>com2);
                Console.WriteLine(com1.Equals(com1));
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e);
                
            }
            
        }
    }
}
