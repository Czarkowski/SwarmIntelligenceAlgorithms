using Cocona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhaleOptimizationAlgorithm;

namespace ConsoleApp.Commands
{
    public class WhaleOptimizationAlgorithmCommand
    {
        public void Command([Option] int? populationSize, [Option] int? dimensions, [Option] int? maxIterations, [Option] double? aMax, [Option] double? b, [Option] double? minX, [Option] double? maxX, [Option] OptimizationFunction? optimizationFunction)
        {
            var whaleOptimizationAlgorithmParameters = new WhaleOptimizationAlgorithmParameters(populationSize, dimensions, maxIterations, aMax, b, minX, maxX, optimizationFunction);
            var whaleOptimizationAlgorithm = new WhaleOptimizationAlgorithmRunner(whaleOptimizationAlgorithmParameters);
            whaleOptimizationAlgorithm.Run();
        }
    }
}
