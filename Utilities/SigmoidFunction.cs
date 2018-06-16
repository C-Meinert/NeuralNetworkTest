using System;

namespace NeuralNetworkTest.Utilities
{
    ///<summary>
    /// Common sigmoid functions
    ///</summary>
    public class SigmoidFunction
    {
        ///<summary>
        /// Logistic Function
        ///</summary>
        public static double logistic(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }

        ///<summary>
        /// Hyperbolic Tangent function
        ///</summary>
        public static double hyperbolic(double x)
        {
            return Math.Tanh(x);
        }

        ///<summary>
        /// Arctangent function
        ///</summary>
        public static double arctangent(double x)
        {
            return Math.Atan(x);
        }

        ///<summary>
        /// Error Function
        ///</summary>
        public static double error(double x)
        {
            throw new NotImplementedException();
        }
    }
}