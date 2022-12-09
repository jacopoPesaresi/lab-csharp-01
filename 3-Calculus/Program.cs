using System;
using ComplexAlgebra;

namespace Calculus
{
    /// <summary>
    /// Test method for the aforementioned Calculator class
    /// </summary>
    ///
    /// This test simulates a calculator which is initially blank, and is then manipulated as follows:
    /// - insert 1 -> 1 is shown
    /// - press + -> nothing is shown (but operation '+' is memorised)
    /// - insert i -> i is shown (while operation '+' is memorised)
    /// - press - -> nothing is shown (but operation '-' is memorised, as well as intermediate result 1+i)
    /// - insert 2 -> 2 is shown (while operation '-' and intermediate result 1+i are memorised)
    /// - press = -> -1 + i is shown
    /// - reset -> nothing is shown
    /// 
    /// TODO: uncomment the commented code, if any
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calculator();
            //
            Console.WriteLine(calc.ToString()); // null, null
            //
            calc.Value = new Complex(1, 0); // 1
            //
            Console.WriteLine(calc.ToString()); // 1, null
            //
            calc.Operation = Calculator.OperationPlus;
            //
            Console.WriteLine(calc.ToString()); // null, +
            //
            calc.Value = new Complex(0, 1); // i
            //
            Console.WriteLine(calc.ToString()); // i, +
            //
            calc.Operation = Calculator.OperationMinus;
            //
            Console.WriteLine(calc.ToString()); // null, -
            //
            calc.Value = new Complex(2, 0);
            //
            Console.WriteLine(calc.ToString()); // 2, -
            //
            calc.ComputeResult();
            //
            Console.WriteLine(calc.ToString()); // -1 + i, null
            //
            Console.WriteLine(calc.Value); // -1 + i
            //
            calc.Reset();
            //
            Console.WriteLine(calc.ToString()); // null, null
        }
    }
}