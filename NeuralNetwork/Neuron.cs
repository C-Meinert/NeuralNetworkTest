using System;
using System.Collections.Generic;

namespace NeuralNetworkTest.NeuralNetwork
{
    public class Neuron
    {
        public List<Dendrite> Dendrites {get; set;}

        public Neuron()
        {
            Dendrites = new List<Dendrite>();
        }
    }
}