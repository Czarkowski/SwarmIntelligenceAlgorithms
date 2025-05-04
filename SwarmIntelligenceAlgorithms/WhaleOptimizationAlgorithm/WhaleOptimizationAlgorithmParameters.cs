namespace WhaleOptimizationAlgorithm;

public class WhaleOptimizationAlgorithmParameters
{
    public WhaleOptimizationAlgorithmParameters(int? populationSize = 30, int? dimensions = 3, int? maxIterations = 100, double? aMax = 2.0, double? b = 1.0, double? minX = -10.0, double? maxX = 10.0, OptimizationFunction? optimizationFunction = OptimizationFunction.Sphere)
    {
        PopulationSize = populationSize ?? PopulationSize;
        Dimensions = dimensions ?? Dimensions;
        MaxIterations = maxIterations ?? MaxIterations;
        AMax = aMax ?? AMax;
        B = b ?? B;
        OptimizationFunction = optimizationFunction ?? OptimizationFunction;
        MinX = minX ?? MinX;
        MaxX = maxX ?? MaxX;
    }

    // Parametry algorytmu
    public int PopulationSize { get; init; }   // Liczba wielorybów
    public int Dimensions { get; init; }     // Liczba wymiarów (np. 3D lub 10D)
    public int MaxIterations { get; init; }  // Maksymalna liczba iteracji
    public double AMax { get; init; }        // Maksymalny współczynnik zmiany pozycji
    public double B { get; init; }        // Współczynnik spirali
    public double MinX { get; init; }      
    public double MaxX { get; init; }   
    public OptimizationFunction OptimizationFunction { get; init; } = OptimizationFunction.Sphere;      

}