using System;
using System.Collections.Generic;

namespace NeuralNetworkTest.NeuralNetwork
{
    public class Layer
    {
        public List<Neuron> Nodes {get; set;}

        public Layer()
        {
            Nodes = new List<Neuron>();
        }
    }
}