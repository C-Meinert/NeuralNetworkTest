using System;
using System.Collections.Generic;

namespace NeuralNetworkTest.NeuralNetwork
{
    public class Network
    {
        public List<Layer> Layers {get; set;}

        public Network()
        {
            Layers = new List<Layer>();
        }
    }
}