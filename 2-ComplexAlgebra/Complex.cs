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
        public double Imm { get; }

        public Complex (double real, double imm){
            Real = real;
            Imm = imm;
        }

        public double Modulus() => Math.Sqrt(Math.Pow(Real,2)+Math.Pow(Imm,2));

        public void Complement()
        {
            //TODO
        }

        public Complex Add(Complex a, Complex b) => new Complex (a.Real+b.Real, a.Imm+b.Imm);

        public Complex Sub(Complex a, Complex b) => new Complex (a.Real-b.Real, a.Imm-b.Imm);
        //valuta se usare la Complement, almeno che quella non mi inverte solo la parte immaginaria

        // TODO generate Equals(object obj)
        public bool Equals(Complex obj) =>
            obj.Real.Equals(Name) && obj.Seed.Equals(Seed) && obj.Ordinal == Ordinal;
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
        

        // TODO generate GetHashCode()
        public override int GetHashCode(){
            return HashCode.Combine(Name, Seed, Ordinal);
        }

    }
}