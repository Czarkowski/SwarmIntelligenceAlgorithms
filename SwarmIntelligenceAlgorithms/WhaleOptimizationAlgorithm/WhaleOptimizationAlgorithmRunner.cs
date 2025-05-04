using System;

namespace WhaleOptimizationAlgorithm;


public class WhaleOptimizationAlgorithmRunner
{
    static Random rand = new Random();

    readonly OptFunc _optimizationFunction;
    readonly WhaleOptimizationAlgorithmParameters _parameters;

    public WhaleOptimizationAlgorithmRunner(WhaleOptimizationAlgorithmParameters parameters)
    {
        _parameters = parameters;

        _optimizationFunction = OptimizationFunctions.GetOptFunc(parameters.OptimizationFunction);
    }

    public void Run()
    {
        Main();
    }

    void Main()
    {
        double[][] whales = InitializePopulation();
        double[] bestWhale = GetBestWhale(whales);

        for (int iter = 0; iter < _parameters.MaxIterations; iter++)
        {
            double a = _parameters.AMax * (1 - (double)iter / _parameters.MaxIterations); // Malejący współczynnik

            for (int i = 0; i < _parameters.PopulationSize; i++)
            {
                double p = rand.NextDouble(); // Losowa wartość do wyboru strategii

                if (p < 0.5)
                {
                    // Mechanizm przyciągania do najlepszego rozwiązania
                    double A = 2 * a * rand.NextDouble() - a;
                    double C = 2 * rand.NextDouble();
                    for (int j = 0; j < _parameters.Dimensions; j++)
                    {
                        double D = Math.Abs(C * bestWhale[j] - whales[i][j]);
                        whales[i][j] = bestWhale[j] - A * D;
                        whales[i][j] = Clamp(whales[i][j]);
                    }
                }
                else
                {
                    // Ruch spiralny wokół najlepszego rozwiązania
                    double l = (rand.NextDouble() * 2) - 1;
                    for (int j = 0; j < _parameters.Dimensions; j++)
                    {
                        double D = Math.Abs(bestWhale[j] - whales[i][j]);
                        whales[i][j] = bestWhale[j] + D * Math.Exp(_parameters.B * l) * Math.Cos(2 * Math.PI * l);
                        whales[i][j] = Clamp(whales[i][j]);
                    }
                }
            }

            bestWhale = GetBestWhale(whales);
            Console.WriteLine($"Iteracja {iter + 1}: [{string.Join(";", bestWhale)}] Najlepsze rozwiązanie = {_optimizationFunction(bestWhale)}");
        }

        Console.WriteLine("Optymalizacja zakończona.");
    }

    // Inicjalizacja losowej populacji
    double[][] InitializePopulation()
    {
        double[][] population = new double[_parameters.PopulationSize][];
        for (int i = 0; i < _parameters.PopulationSize; i++)
        {
            population[i] = new double[_parameters.Dimensions];
            for (int j = 0; j < _parameters.Dimensions; j++)
                population[i][j] = _parameters.MinX + (_parameters.MaxX - _parameters.MinX) * rand.NextDouble();
        }
        return population;
    }

    // Znalezienie najlepszego rozwiązania w populacji
    double[] GetBestWhale(double[][] whales)
    {
        double[] best = null;
        double bestFitness = double.MaxValue;
        foreach (var whale in whales)
        {
            double fitness = _optimizationFunction(whale);
            if (fitness < bestFitness)
            {
                bestFitness = fitness;
                best = (double[])whale.Clone();
            }
        }
        return best;
    }

    // Ograniczenie wartości do zakresu [minX, maxX]
    double Clamp(double value)
    {
        return Math.Max(_parameters.MinX, Math.Min(_parameters.MaxX, value));
    }
}
