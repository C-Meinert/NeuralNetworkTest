using System;
using NeuralNetworkTest.Utilities;

namespace NeuralNetworkTest.NeuralNetwork
{
    ///<summary>
    /// Acts as a weighted path between neurons
    ///</summary>
    public class Dendrite
    {
        public double Weight { get; set; }

        ///<summary>
        /// Constructor
        ///</summary>
        public Dendrite()
        {
            Weight = RandomNumberGen.CryptoRandomNumber();
        }
    }
}