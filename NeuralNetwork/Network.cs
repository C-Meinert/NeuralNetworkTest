using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NeuralNetworkTest.Utilities;

namespace NeuralNetworkTest.NeuralNetwork
{
    ///<summary>
    /// 
    ///</summary>
    public class Network
    {
        ///<summary>
        /// List of Layers
        ///</summary>
        public List<Layer> Layers { get; set; }
        public double LearnRate { get; set; }

        ///<summary>
        /// Constructor
        ///</summary>
        public Network(double learnRate, List<int> layerComposition)
        {
            if (layerComposition.Count < 2)
                throw new ArgumentOutOfRangeException("Network must have at least two layers");

            LearnRate = learnRate;
            Layers = new List<Layer>();

            for (int l = 0; l < layerComposition.Count; l++)
            {
                Layer layer = new Layer(layerComposition[l]);

                for (int n = 0; n < layerComposition[l]; n++)
                {
                    layer.Neurons.Add(new Neuron());
                }

                foreach (var neuron in layer.Neurons)
                {
                    if (l == 0)
                    {
                        neuron.Bias = 0;
                    }
                    else
                    {
                        for (int d = 0; d < layerComposition[l - 1]; d++)
                        {
                            neuron.Dendrites.Add(new Dendrite());
                        }
                    }
                }

                Layers.Add(layer);
            }
        }

        ///<summary>
        /// Process data
        ///</summary>
        public List<double> Run(List<double> input)
        {
            if (input.Count != this.Layers[0].Neurons.Count)
                throw new ArgumentOutOfRangeException("Number of inputs must match the number of neurons on in the input layer");

            for (int l = 0; l < Layers.Count; l++)
            {
                Layer layer = Layers[l];

                for (int n = 0; n < layer.Neurons.Count; n++)
                {
                    Neuron neuron = layer.Neurons[n];

                    if (l == 0)
                    {
                        neuron.Value = input[n];
                    }
                    else
                    {
                        neuron.Value = 0;
                        for (int np = 0; np < this.Layers[l - 1].Neurons.Count; np++)
                        {
                            neuron.Value = neuron.Value + Layers[l - 1].Neurons[np].Value * neuron.Dendrites[np].Weight;
                        }

                        neuron.Value = SigmoidFunction.logistic(neuron.Value + neuron.Bias);
                    }
                }
            }

            Layer outputLayer = Layers[Layers.Count - 1];
            int numOfOutputs = outputLayer.Neurons.Count;
            List<double> output = new List<double>(numOfOutputs);

            foreach (Neuron neuron in outputLayer.Neurons)
            {
                output.Add(neuron.Value);
            }

            return output;
        }

        ///<summary>
        /// Used to "train" or calibrate the network
        ///</summary>
        public bool Train(List<double> input, List<double> output)
        {
            if ((input.Count != this.Layers[0].Neurons.Count) || (output.Count != this.Layers[this.Layers.Count - 1].Neurons.Count)) return false;

            Run(input);

            for (int i = 0; i < this.Layers[this.Layers.Count - 1].Neurons.Count; i++)
            {
                Neuron neuron = this.Layers[this.Layers.Count - 1].Neurons[i];

                neuron.Delta = neuron.Value * (1 - neuron.Value) * (output[i] - neuron.Value);

                for (int j = this.Layers.Count - 2; j > 2; j--)
                {
                    for (int k = 0; k < this.Layers[j].Neurons.Count; k++)
                    {
                        Neuron n = this.Layers[j].Neurons[k];

                        n.Delta = n.Value *
                                  (1 - n.Value) *
                                  this.Layers[j + 1].Neurons[i].Dendrites[k].Weight *
                                  this.Layers[j + 1].Neurons[i].Delta;
                    }
                }
            }

            for (int i = this.Layers.Count - 1; i > 1; i--)
            {
                for (int j = 0; j < this.Layers[i].Neurons.Count; j++)
                {
                    Neuron n = this.Layers[i].Neurons[j];
                    n.Bias = n.Bias + (this.LearnRate * n.Delta);

                    for (int k = 0; k < n.Dendrites.Count; k++)
                        n.Dendrites[k].Weight = n.Dendrites[k].Weight + (this.LearnRate * this.Layers[i - 1].Neurons[k].Value * n.Delta);
                }
            }

            return true;
        }

        ///<summary>
        /// Generates a string representation of the network
        ///</summary>
        public override string ToString()
        {
            StringBuilder networkView = new StringBuilder("~~~~~~Network View~~~~~~~\n");
            for (int l = 0; l < Layers.Count; l++)
            {
                Layer layer = Layers[l];
                if (l == 0)
                {
                    networkView.AppendLine("+-- Input Layer");
                }
                else if (l == (Layers.Count - 1))
                {
                    networkView.AppendLine("+-- Output Layer");
                }
                else
                {
                    networkView.AppendLine($"+-- Layer {l}");
                }

                networkView.AppendLine($"|   Neurons: {layer.Neurons.Count}");

                for (int n = 0; n < layer.Neurons.Count; n++)
                {
                    Neuron neuron = layer.Neurons[n];

                    networkView.AppendLine($"|--+-- Neuron {n}");
                    networkView.AppendLine($"|  |   Bias: {neuron.Bias}");
                    networkView.AppendLine($"|  |   Delta: {neuron.Delta}");
                    networkView.AppendLine($"|  |   Value: {neuron.Value}");
                    networkView.AppendLine($"|  |   Dendrites: {neuron.Dendrites.Count}");

                    for (int d = 0; d < neuron.Dendrites.Count; d++)
                    {
                        Dendrite dendrite = neuron.Dendrites[d];

                        networkView.AppendLine($"|  |--+-- Dendrite {d}");
                        networkView.AppendLine($"|  |  |   Weight: {dendrite.Weight}");
                    }
                }
            }

            return networkView.ToString();
        }
    }
}