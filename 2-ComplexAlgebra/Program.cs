using System;

namespace ComplexAlgebra
{
    class Program
    {
        /// <summary>
        /// Test method for the Complex class
        /// </summary>
        /// 
        /// TODO: uncomment the commented code, if any
        static void Main(string[] args)
        {
            var zero = new Complex(0, 0);
            var one = new Complex(1, 0);
            var i = new Complex(0, 1);
            var onePlusI = one.Plus(i);
            var iPlusOne = i.Plus(one);
            var oneMinusI = one.Plus(i).Complement();
            var minusI = oneMinusI.Minus(one);
            
            Console.WriteLine(zero.Real); // 0
            Console.WriteLine(zero.Imaginary); // 0
            Console.WriteLine(zero.Modulus); // 0
            Console.WriteLine(zero.Phase); // 0
            Console.WriteLine(zero.ToString()); // 0
            
            Console.WriteLine("---");
            
            Console.WriteLine(one.Real); // 1
            Console.WriteLine(one.Imaginary); // 0
            Console.WriteLine(one.Modulus); // 1
            Console.WriteLine(one.Phase); // 0
            Console.WriteLine(one.ToString()); // 1
            
            Console.WriteLine("---");
            
            Console.WriteLine(i.Real); // 0
            Console.WriteLine(i.Imaginary); // 1
            Console.WriteLine(i.Modulus); // 1
            Console.WriteLine(i.Phase); // 1,5707963267948966 (Math.PI / 2)
            Console.WriteLine(i.ToString()); // i
            
            Console.WriteLine("---");
            
            Console.WriteLine(onePlusI.Real); // 1
            Console.WriteLine(onePlusI.Imaginary); // 1
            Console.WriteLine(onePlusI.Modulus); // 1,4142135623730951 (Math.Sqrt(2))
            Console.WriteLine(onePlusI.Phase); // 0,7853981633974483 (Math.PI / 4)
            Console.WriteLine(onePlusI.ToString()); // 1 + i
            Console.WriteLine(onePlusI.Equals(iPlusOne)); // true
            
            Console.WriteLine("---");
            
            Console.WriteLine(iPlusOne.Real); // 1
            Console.WriteLine(iPlusOne.Imaginary); // 1
            Console.WriteLine(iPlusOne.Modulus); // 1,4142135623730951 (Math.Sqrt(2))
            Console.WriteLine(iPlusOne.Phase); // 0,7853981633974483 (Math.PI / 4)
            Console.WriteLine(iPlusOne.ToString()); // 1 + i
            Console.WriteLine(iPlusOne.Equals(onePlusI)); // true
            
            Console.WriteLine("---");
            
            Console.WriteLine(oneMinusI.Real);  // 1
            Console.WriteLine(oneMinusI.Imaginary);  // -1
            Console.WriteLine(oneMinusI.Modulus);  // 1,4142135623730951 (Math.Sqrt(2))
            Console.WriteLine(oneMinusI.Phase);  // -0,7853981633974483 (-Math.PI / 4)
            Console.WriteLine(oneMinusI.ToString());  // 1 - i
            
            Console.WriteLine("---");
            
            Console.WriteLine(minusI.Real);  // 0
            Console.WriteLine(minusI.Imaginary);  // -1
            Console.WriteLine(minusI.Modulus);  // 1
            Console.WriteLine(minusI.Phase);  // -1,5707963267948966 (Math.PI / 2)
            Console.WriteLine(minusI.ToString());  // -i
        }
    }
}