using System;
using System.Dynamic;
using System.Numerics;

namespace LabaDop
{
    public class Fraction:IComparable
    {
        
        //public static double EPS = 0.000001;
        private BigInteger numerator { get; set; }
        private BigInteger denominator { get; set; }

        public Fraction()
        {
            numerator = 0;
            denominator = 1;
        }

        public Fraction(BigInteger a)
        {
            numerator = a;
            denominator = 1;
        }

        public Fraction(BigInteger num, BigInteger denom)
        {
            if (denom.IsZero)
            {
                throw new DivideByZeroException("denominator is 0");
            }
            numerator = BigInteger.Abs(num);
            denominator = BigInteger.Abs(denom);
            if (num * denom < 0)
            {
                numerator *= -1;
            }
        }

        public static Fraction Add(Fraction frac1, Fraction frac2)
        {
            Fraction newFraction = new Fraction
            {
                numerator = frac1.numerator * frac2.denominator + frac2.numerator * frac1.denominator,
                denominator = frac1.denominator * frac2.denominator
            };
            newFraction.Reduce();
            return newFraction;
        }

        public static Fraction operator +(Fraction frac1, Fraction frac2)
        {
            return Add(frac1, frac2);
        }

        public static Fraction Sub(Fraction frac1, Fraction frac2)
        {
            Fraction newFraction = new Fraction
            {
                numerator = frac1.numerator * frac2.denominator - frac2.numerator * frac1.denominator,
                denominator = frac1.denominator * frac2.denominator
            };
            newFraction.Reduce();
            return newFraction;
        }

        public static Fraction operator -(Fraction frac1, Fraction frac2)
        {
            return Sub(frac1, frac2);
        }

        public static Fraction Mul(Fraction frac1, Fraction frac2)
        {
            Fraction newFraction = new Fraction
            {
                numerator = frac1.numerator * frac2.numerator, denominator = frac1.denominator * frac2.denominator
            };

            newFraction.Reduce();
            return newFraction;
        }

        public static Fraction operator *(Fraction frac1, Fraction frac2)
        {
            return Mul(frac1, frac2);
        }

        public static Fraction Div(Fraction frac1, Fraction frac2)
        {
            Fraction newFraction = new Fraction();
            newFraction.denominator = BigInteger.Multiply(frac1.denominator, frac2.numerator);
            if (newFraction.denominator < 0)
                newFraction.denominator *= -1;
            if(frac1.denominator * frac2.numerator < 0)
                newFraction.numerator = -1*frac1.numerator * frac2.denominator;
            else
                newFraction.numerator = frac1.numerator * frac2.denominator;
            if (newFraction.denominator.IsZero)
            {
                throw new DivideByZeroException("В знаменателе не может быть нуля");
            }
            
            newFraction.Reduce();
            return newFraction;
        }

        public static Fraction operator /(Fraction frac1, Fraction frac2)
        {
            return Div(frac1, frac2);
        }

        private static BigInteger GetGreatestCommonDivisor(BigInteger a, BigInteger b)
        {
            while (b != 0)
            {
                BigInteger temp = b;
                b = a % b;
                a = temp;
            }

            if (a < 0)
                a *= -1;
            
            return a;
        }

        public Fraction Reduce()
        {
            Fraction result = this;
            BigInteger greatestCommonDivisor = GetGreatestCommonDivisor(numerator, denominator);
            result.numerator /= greatestCommonDivisor;
            result.denominator /= greatestCommonDivisor;
            return result;
        }

        public override string ToString()
        {
            return "["+numerator + "/" + denominator+"]";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj is Fraction)
                return Equals(obj as Fraction);
            
            return false;
        }

        public bool Equals(Fraction fraction)
        {
            Fraction a = Reduce();
            Fraction b = fraction.Reduce();
            return (a.numerator - b.numerator).IsZero  && (a.denominator - b.denominator).IsZero;
        }

        public int CompareTo(object frac)
        {
            Fraction f = frac as Fraction;
            if(f == null) throw new ArgumentNullException("cant compare");
            if (Equals(f))
            {
                return 0;
            }
            Fraction a = Reduce();
            Fraction b = f.Reduce();
            if (a.numerator  * b.denominator > b.numerator * a.denominator)
            {
                return 1;
            }
            return -1;
        }
        public static bool operator >(Fraction a, Fraction b)
        {
            return a.CompareTo(b) > 0;
        }
        public static bool operator >(Fraction a, int b)
        {
            return a > new Fraction(b);
        }
        public static bool operator >(int a, Fraction b)
        {
            return new Fraction(a) > b;
        }
        public static bool operator <(Fraction a, Fraction b)
        {
            return a.CompareTo(b) < 0;
        }
        public static bool operator <(Fraction a, int b)
        {
            return a < new Fraction(b);
        }
        public static bool operator <(int a, Fraction b)
        {
            return new Fraction(a) < b;
        }
        public static bool operator >=(Fraction a, Fraction b)
        {
            return a.CompareTo(b) >= 0;
        }
        public static bool operator >=(Fraction a, int b)
        {
            return a >= new Fraction(b);
        }
        public static bool operator >=(int a, Fraction b)
        {
            return new Fraction(a) >= b;
        }
        public static bool operator <=(Fraction a, Fraction b)
        {
            return a.CompareTo(b) <= 0;
        }
        public static bool operator <=(Fraction a, int b)
        {
            return a <= new Fraction(b);
        }
        public static bool operator <=(int a, Fraction b)
        {
            return new Fraction(a) <= b;
        }
    }
}