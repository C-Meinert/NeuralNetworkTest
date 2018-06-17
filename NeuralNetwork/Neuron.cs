using System;
using System.Collections.Generic;
using NeuralNetworkTest.Utilities;

namespace NeuralNetworkTest.NeuralNetwork
{
    ///<summary>
    /// 
    ///</summary>
    public class Neuron
    {
        public List<Dendrite> Dendrites { get; set; }
        public double Bias { get; set; }
        public double Delta { get; set; }
        public double Value { get; set; }

        ///<summary>
        /// 
        ///</summary>
        public Neuron()
        {
            Bias = RandomNumberGen.PseudoRandomNumber(Environment.TickCount);

            Dendrites = new List<Dendrite>();
        }
    }
}