using System;
using System.Dynamic;

namespace LabaDop
{
    public class Fraction
    {
        public static double EPS = 0.000001;
        private double numerator { get; set; }
        private double denominator { get; set; }

        public Fraction()
        {
            numerator = 0;
            denominator = 1;
        }

        public Fraction(int a)
        {
            numerator = a;
            denominator = 1;
        }

        public Fraction(double num, double denom)
        {
            if (Math.Abs(denom) < EPS)
            {
                throw new DivideByZeroException("denominator is 0");
            }
            numerator = Math.Abs(num);
            denominator = Math.Abs(denom);
            if (num * denom < 0)
            {
                numerator *= 1;
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
            Fraction newFraction = new Fraction {denominator = Math.Abs(frac1.denominator * frac2.numerator)};

            if(frac1.denominator * frac2.numerator < 0)
                newFraction.numerator = -1*frac1.numerator * frac2.denominator;
            else
                newFraction.numerator = frac1.numerator * frac2.denominator;
            if (Math.Abs(newFraction.denominator) < EPS)
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

        private static double GetGreatestCommonDivisor(double a, double b)
        {
            while (b != 0)
            {
                double temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public Fraction Reduce()
        {
            Fraction result = this;
            double greatestCommonDivisor = Math.Abs(GetGreatestCommonDivisor(numerator, denominator));
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
            return Math.Abs(a.numerator - b.numerator) < EPS && Math.Abs(a.denominator - b.denominator) < EPS;
        }
        private int CompareTo(Fraction frac)
        {
            if (Equals(frac))
            {
                return 0;
            }
            Fraction a = Reduce();
            Fraction b = frac.Reduce();
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