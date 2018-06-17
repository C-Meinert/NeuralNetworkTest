using System;
using System.Collections.Generic;

namespace NeuralNetworkTest.NeuralNetwork
{
    ///<summary>
    /// The layer acts as a container for neurons
    ///</summary>
    public class Layer
    {
        public List<Neuron> Neurons { get; set; }

        ///<summary>
        /// Constructor
        ///</summary>
        public Layer(int numNeurons)
        {
            Neurons = new List<Neuron>(numNeurons);
        }
    }
}