namespace WhaleOptimizationAlgorithm;

public class WhaleOptimizationAlgorithmParameters
{
    public WhaleOptimizationAlgorithmParameters(int? populationSize = 30, int? dimensions = 5, int? maxIterations = 100, double? aMax = 2.0, double? b = 1.0, OptimizationFunction? optimizationFunction = OptimizationFunction.Sphere)
    {
        PopulationSize = populationSize ?? PopulationSize;
        Dimensions = dimensions ?? Dimensions;
        MaxIterations = maxIterations ?? MaxIterations;
        AMax = aMax ?? AMax;
        B = b ?? B;
        OptimizationFunction = optimizationFunction ?? OptimizationFunction;
    }

    // Parametry algorytmu
    public int PopulationSize { get; init; } = 30;   // Liczba wielorybów
    public int Dimensions { get; init; } = 5;        // Liczba wymiarów (np. 3D lub 10D)
    public int MaxIterations { get; init; } = 100;   // Maksymalna liczba iteracji
    public double AMax { get; init; } = 2.0;         // Maksymalny współczynnik zmiany pozycji
    public double B { get; init; } = 1.0;            // Współczynnik spirali
    public OptimizationFunction OptimizationFunction { get; init; } = OptimizationFunction.Sphere;            // Współczynnik spirali

}