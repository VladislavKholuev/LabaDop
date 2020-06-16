using System;
using System.Numerics;
using System.Reflection;


namespace LabaDop
{
    public class ComplexNum:IComparable,IComparable<ComplexNum>,IEquatable<ComplexNum>
    {
        private Fraction Re { get; set; }
        private Fraction Im { get; set; }
        public ComplexNum(Fraction re, Fraction im): this()
        {
            Re = re;
            Im = im;
        }
        public ComplexNum()
        {
            Re = new Fraction(0);
            Im = new Fraction(0);
        }

        public static ComplexNum Add(ComplexNum com1, ComplexNum com2)
        {
            return new ComplexNum(com1.Re+com2.Re,com1.Im+com2.Im);
        }

        public static ComplexNum operator +(ComplexNum com1, ComplexNum com2)
        {
            return Add(com1, com2);
        }

        public static ComplexNum Sub(ComplexNum com1, ComplexNum com2)
        {
            return new ComplexNum(com1.Re-com2.Re, com1.Im-com2.Im);
        }

        public static ComplexNum operator -(ComplexNum com1, ComplexNum com2)
        {
            return Sub(com1,com2);
        }

        public static ComplexNum Mul(ComplexNum com1, ComplexNum com2)
        {
            return new ComplexNum(com1.Re * com2.Re - com1.Im * com2.Im, com1.Re * com2.Im + com2.Re * com1.Im);
        }

        public static ComplexNum operator *(ComplexNum com1, ComplexNum com2)
        {
            return Mul(com1,com2);
        }

        public static ComplexNum Div(ComplexNum com1, ComplexNum com2)
        {
            if(com2.Re.Equals(0))
                throw new DivideByZeroException("В знаменателе не может быть нуля");
            return new ComplexNum()
          {
              Re = (com1.Re*com2.Re+com1.Im*com2.Im)/(com2.Re*com2.Re + com2.Im*com2.Im),
              Im = (com1.Im*com2.Re + com2.Im*com1.Re)/(com2.Re * com2.Re + com2.Im * com2.Im)
          };
        }
        public static ComplexNum operator /(ComplexNum com1, ComplexNum com2)
        {
            return Div(com1,com2);
        }

        public static Fraction Module(ComplexNum com)
        {
            return new Fraction((com.Re*com.Re)+(com.Im*com.Im)).GetSqrtFraction();
        }

        public int CompareTo(object? obj)
        {
            if (obj == null)
                throw new ArgumentNullException("null com");
            if (Equals(obj))
            {
                return 0;
            }
            ComplexNum num = obj as ComplexNum;
            if (Module(this) > Module(num))
                return 1;
            return -1;
        }

        public int CompareTo(ComplexNum other)
        {
            if (Equals(other))
                return 0;
            if (Module(this) > Module(other))
                return 1;
            return -1;
        }

        public static bool operator >(ComplexNum a, ComplexNum b)
        {
            return a.CompareTo(b) > 0;
        }
        
        public static bool operator <(ComplexNum a, ComplexNum b)
        {
            return a.CompareTo(b) < 0;
        }
        
        public static bool operator >=(ComplexNum a, ComplexNum b)
        {
            return a.CompareTo(b) >= 0;
        }
        public static bool operator <=(ComplexNum a, ComplexNum b)
        {
            return a.CompareTo(b) <= 0;
        }

        public bool Equals(ComplexNum other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(Re, other.Re) && Equals(Im, other.Im);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ComplexNum) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Re, Im);
        }

        public override string ToString()
        {
            return "[" + Re + "+i" + Im + "]";
        }
    }
}