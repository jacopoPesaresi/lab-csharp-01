using System;
using System.Linq;
using ComplexAlgebra;

namespace Arrays
{
    class Program
    {
        /// <summary>
        /// Given an array of <see cref="Complex"/> numbers, this method returns the one number with highest modulus,
        /// or <c>null</c>, in case of empty array
        /// </summary>
        /// <param name="array">an array of <see cref="Complex"/> numbers</param>
        /// <returns>the <see cref="Complex"/> number with highest modulus in <paramref name="array"/>,
        /// or <c>null</c> in case <paramref name="array"/> is empty</returns>
        /// <exception cref="NullReferenceException">if <paramref name="array"/> is <c>null</c></exception>
        ///
        /// TODO: implement this method
        /// <seealso cref="Examples.Max"/>
        public static Complex MaxModulus(Complex[] array)
        {
            Complex max = new Complex(0,0);
            for (int i = 0; i < array.Length; i++)
            {
                if(max.Modulus < array[i].Modulus)
                {
                    max = array[i];
                }
            }
            return max;
            //return null; // TODO: remove this line
        }

        /// <summary>
        /// Creates a <a href="https://en.wikipedia.org/wiki/Object_copying">shallow copy</a> of the given array of
        /// <see cref="Complex"/> numbers.
        /// </summary>
        /// <param name="array">an array of <see cref="Complex"/> numbers</param>
        /// <returns>the shallow copy of <paramref name="array"/></returns>
        /// <exception cref="NullReferenceException">if <paramref name="array"/> is <c>null</c></exception>
        ///
        /// TODO: implement this method
        public static Complex[] Clone(Complex[] array)
        {
            Complex[] tmp = new Complex[array.Length];
            for (int i =0; i<array.Length;i++)
            {
                tmp[i] = new Complex(array[i].Real, array[i].Imaginary);
            }
            return tmp; // TODO: remove this line
        }

        /// <summary>
        /// Creates a <a href="https://en.wikipedia.org/wiki/Object_copying">shallow copy</a> of the given array of
        /// <see cref="Complex"/> numbers, ordered by phase (from the lowest one to the highest one)
        /// </summary>
        /// <param name="array">an array of <see cref="Complex"/> numbers</param>
        /// <returns>the shallow copy of <paramref name="array"/></returns>
        /// <exception cref="NullReferenceException">if <paramref name="array"/> is <c>null</c></exception>
        ///
        /// TODO: implement this method
        /// TODO: (consider reusing the Clone method)
        /// <seealso cref="Examples.BubbleSort"/>
        public static Complex[] SortByPhase(Complex[] array)
        {
            Complex temp;
            Complex[] tmp = Program.Clone(array);
            for (int i = 0; i < tmp.Length; i++)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (tmp[j + 1].Phase < tmp[j].Phase)
                    {
                        temp = new Complex(tmp[j].Real, tmp[j].Imaginary);
                        tmp[j] = new Complex(tmp[j + 1].Real, tmp[j + 1].Imaginary);
                        tmp[j + 1] = new Complex(temp.Real, temp.Imaginary);
                    }
                }
            }
            return tmp; // TODO: remove this line
        }
        
        /// <summary>
        /// Creates a representation of the provided array of <see cref="Complex"/> as a string.
        /// Items of <paramref name="array"/> are represented via their <see cref="Complex.ToString"/> method.
        /// They are separated by a semicolon and enclosed within square brackets.
        /// </summary>
        /// <param name="array">an array of <see cref="Complex"/> numbers</param>
        /// <returns>a string</returns>
        /// <exception cref="NullReferenceException">if <paramref name="array"/> is <c>null</c></exception>
        /// 
        /// TODO: implement this method
        public static string ArrayToString(Complex[] array)
        {
            string tmp = "[ ";
            for(int i =0; i<array.Length-1;i++){
                tmp += array[i].ToString() + "; ";
            }
            tmp += array[array.Length-1].ToString() + "]";
            return tmp; // TODO: remove this line
        }
        
        /// <summary>
        /// Test method for the aforementioned array algorithms
        /// </summary>
        /// 
        /// TODO: uncomment the commented code, if any
        static void Main(string[] args)
        {
            Complex[] numbers = new[] {
                new Complex(0, 0),
                new Complex(1, 1),
                new Complex(0, 1), 
                new Complex(-2, 2),
                new Complex(-3, 0),
                new Complex(-2, -2),
                new Complex(0, -4),
                new Complex(1, -1),
                new Complex(1, 0)
            }; 
            
            Complex[] orderedByPhase = new[] {
                new Complex(-2, -2),
                new Complex(0, -4),
                new Complex(1, -1),
                new Complex(0, 0),
                new Complex(1, 0),
                new Complex(1, 1),
                new Complex(0, 1),
                new Complex(-2, 2),
                new Complex(-3, 0)
            };
            
            var cloned = numbers;
            
            ArraysAreEqual(cloned, numbers);
            ArraysAreEqual(SortByPhase(numbers), orderedByPhase);
            ArraysAreEqual(numbers, cloned);
            CheckComplexNumber(MaxModulus(numbers), new Complex(0, -4));
            CheckComplexNumber(MaxModulus(orderedByPhase), new Complex(0, -4));
            CheckComplexNumber(MaxModulus(cloned), new Complex(0, -4));
        }

        /// <summary>
        /// Checks whether the <paramref name="actual"/> array of <see cref="Complex"/> numbers is item-wise equal to
        /// the <paramref name="expected"/> one.
        /// </summary>
        /// <remarks>
        /// Items are compared via their <see cref="Complex.Equals(object)"/> method.
        /// </remarks>
        /// <param name="actual">the array of <see cref="Complex"/> numbers under test</param>
        /// <param name="expected">the expected array of <see cref="Complex"/> numbers</param>
        static void ArraysAreEqual(Complex[] actual, Complex[] expected)
        {
            var message = $"Error: expected: {ArrayToString(expected)}, actual: {ArrayToString(actual)}";
            if (expected.Length != actual.Length)
            {
                Console.WriteLine(message);
                return;
            }
            for (int i = 0; i < actual.Length; i++)
            {
                if (!actual[i].Equals(expected[i]))
                {
                    Console.WriteLine(message);
                    return;
                }
            }
            Console.WriteLine($"Array {ArrayToString(actual)} is ok");
        }
        
        /// <summary>
        /// Checks whether the <paramref name="actual"/> <see cref="Complex"/> number is equal to the
        /// <paramref name="expected"/> one (via the <see cref="Complex.Equals(object)"/> method).
        /// </summary>
        /// <param name="actual">the <see cref="Complex"/> number under test</param>
        /// <param name="expected">the <see cref="Complex"/> number <paramref name="actual"/> should be equal to</param>
        static void CheckComplexNumber(Complex actual, Complex expected)
        {
            if (!actual.Equals(expected))
            {
                Console.WriteLine($"Error: ({actual.ToString()}) has not the same hash code of ({expected.ToString()})");
                return;
            }
            Console.WriteLine($"({actual.ToString()}) is ok");
        }
    }
}