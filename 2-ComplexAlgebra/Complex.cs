using System.Numerics;
using System;
namespace ComplexAlgebra
{
    /// <summary>
    /// A type for representing Complex numbers.
    /// </summary>
    ///
    /// TODO: Model Complex numbers in an object-oriented way and implement this class.
    /// TODO: In other words, you must provide a means for:
    /// TODO: * instantiating complex numbers
    /// TODO: * accessing a complex number's real, and imaginary parts
    /// TODO: * accessing a complex number's modulus, and phase
    /// TODO: * complementing a complex number
    /// TODO: * summing up or subtracting two complex numbers
    /// TODO: * representing a complex number as a string or the form Re +/- iIm
    /// TODO:     - e.g. via the ToString() method
    /// TODO: * checking whether two complex numbers are equal or not
    /// TODO:     - e.g. via the Equals(object) method
    public class Complex
    {
        public double Real { get; }
        public double Imaginary { get; }
        public double Modulus 
        { 
            get => Math.Sqrt(Math.Pow(Real,2) + Math.Pow(Imaginary,2));
        }
        public double Phase 
        { 
            get => Math.Atan2(Imaginary,Real);
        }

        public Complex (double real, double imm){
            Real = real;
            Imaginary = imm;
        }

        public Complex Complement() => new Complex(Real, Imaginary*-1);

        public Complex Plus(Complex a) => new Complex (a.Real+Real, a.Imaginary+Imaginary);

        public Complex Minus(Complex a) => new Complex (Real-a.Real, Imaginary-a.Imaginary);
        //valuta se usare la Complement, almeno che quella non mi inverte solo la parte Imaginaryaginaria

        public override string ToString() 
        {
            if (Real.Equals(0) && Imaginary.Equals(0))
            {
                return "0";
            } 
            else if (Real.Equals(0))
            {
                //return (Math.Abs(Imaginary).Equals(1) ? "i" : $"{Imaginary}i");
                return (Imaginary.Equals(1) ? "i" : $"{Imaginary}i");
            }
            else if (Imaginary.Equals(0))
            {
                return $"{Real}";
            }
            else
            {
                return  $"{Real} " 
            + ((Imaginary > 0) ? "+ " : "- ") 
            + ((Imaginary > 0) ? $"{Imaginary}i" : $"{-1*Imaginary}i");
            }
        }
            //=> 
            //$"{Real}"+$"{Imaginary}"+"i";
            /*
            //((Real > 0) ? "+" : "") 
            $"{Real} " 
            + ((Imaginary > 0) ? "+ " : (Imaginary == 0) ? " " : "- ") 
            + ((Imaginary > 0) ? $"{Imaginary}" : (Imaginary == 0) ? "" : $"{-1*Imaginary}")
            + ((Imaginary != 0) ? "i" : "");
            //+ (Real != 0 ? "" : $"{Imaginary}");
            */
        // TODO generate Equals(object obj)
        public override bool Equals(Object obj) {

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
                        
            Complex comp = obj as Complex;
            if (comp != null)
            {
                return comp.Real.CompareTo(Real)==0 && comp.Imaginary.CompareTo(Imaginary)==0;
            }
            return false;

        }
        //    obj.Real.Equals(Name) && obj.Seed.Equals(Seed) && obj.Ordinal == Ordinal;
        /*
        {
            if (obj istanceof Complex)
            {
                obj = (Complex)obj;
                return obj.Real
            }
            else return false;
        }
        */
        public override int GetHashCode(){
            return HashCode.Combine(Real, Imaginary);
        }

    }
}