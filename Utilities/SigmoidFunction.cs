using System;

namespace NeuralNetworkTest.Utilities
{
    ///<summary>
    /// Common sigmoid functions
    ///</summary>
    public class SigmoidFunction
    {
        ///<summary>
        /// Binary Logistic Function
        ///</summary>
        public static double logistic(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        ///<summary>
        /// Binary Hyperbolic Tangent function
        ///</summary>
        public static double hyperbolic(double x)
        {
            return Math.Tanh(x);
        }

        ///<summary>
        /// Binary Arctangent function
        ///</summary>
        public static double arctangent(double x)
        {
            return Math.Atan(x);
        }

        ///<summary>
        /// Bipolar function
        ///</summary>
        public static double bipolar(double x)
        {
            return ((1 - Math.Exp(x) / 1 + Math.Exp(x)));
        }
    }
}