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
        public void Command([Option] int? populationSize, [Option] int? dimensions, [Option] int? maxIterations, [Option] int? aMax, [Option] int? b, [Option] OptimizationFunction? optimizationFunction)
        {
            var whaleOptimizationAlgorithmParameters = new WhaleOptimizationAlgorithmParameters(populationSize, dimensions, maxIterations, aMax, b, optimizationFunction);
            var whaleOptimizationAlgorithm = new WhaleOptimizationAlgorithmRunner(whaleOptimizationAlgorithmParameters);
            whaleOptimizationAlgorithm.Run();
        }
    }
}
