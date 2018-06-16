using System;
using System.Security.Cryptography;

namespace NeuralNetworkTest.Utilities
{
    ///<summary>
    /// Functions for making random numbers
    ///</summary>
    public class RandomNumberGen
    {
        ///<summary>
        /// Uses cryptopgraphy classes to make a better random number
        ///</summary>
        public static double CryptoRandomNumber()
        {
            double randValue;
            using (RNGCryptoServiceProvider rngesus = new RNGCryptoServiceProvider())
            {
                Random r = new Random(rngesus.GetHashCode());
                randValue = r.NextDouble();
            }

            return randValue;
        }

        ///<summary>
        /// Pseudo random numbder
        ///</summary>
        public static double PseudoRandomNumber()
        {
            Random r = new Random();
            return r.NextDouble();
        }
    }
}