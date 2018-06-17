using System;
using System.Collections.Generic;
using NeuralNetworkTest.NeuralNetwork;

namespace NeuralNetworkTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Network network = new Network(0.7, new List<int>{2,4,8,16,8,4,2});

            List<double> input = new List<double>{0,1};
            List<double> expectedOutput = new List<double> {0,0};

            Console.WriteLine(network);

            int counter = 0;
            while(counter < 1000000) {
                network.Train(input, expectedOutput);
                counter ++;
            }

            Console.WriteLine(network);

            List<double> results = network.Run(input);

            foreach(double result in results) {
                Console.WriteLine(result);
            }
        }
    }
}
