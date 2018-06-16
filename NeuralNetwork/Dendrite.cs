using System;
using NeuralNetworkTest.Utilities;

namespace NeuralNetworkTest.NeuralNetwork
{
    public class Dendrite
    {
        public double Weight { get; set; }
        
        public Dendrite()
        {
            Weight = RandomNumberGen.CryptoRandomNumber();
        }
    }
}