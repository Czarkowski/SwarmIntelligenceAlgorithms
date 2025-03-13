global using OptFunc = System.Func<double[], double>;

namespace WhaleOptimizationAlgorithm;
public enum OptimizationFunction
{
    Sphere,
    Rastrigin,
    Rosenbrock,
    Ackley,
    Griewank,
    Schwefel,
    Zakharov
}

static class OptimizationFunctions
{
    public static OptFunc GetOptFunc(OptimizationFunction optimizationFunction)
    {
        return optimizationFunction switch
        {
            OptimizationFunction.Sphere => Sphere,
            OptimizationFunction.Rastrigin => Rastrigin,
            OptimizationFunction.Rosenbrock => Rosenbrock,
            OptimizationFunction.Ackley => Ackley,
            OptimizationFunction.Griewank => Griewank,
            OptimizationFunction.Schwefel => Schwefel,
            OptimizationFunction.Zakharov => Zakharov,
            _ => throw new NotImplementedException(),
        };
    }
    // Sphere function: f(x) = sum(x_i^2) -> Min: f(0,0,...,0) = 0
    public static OptFunc Sphere = x =>
    {
        double sum = 0;
        foreach (var xi in x)
            sum += xi * xi;
        return sum;
    };

    // Rastrigin function: f(x) = 10n + sum(x_i^2 - 10*cos(2πx_i)) -> Min: f(0,0,...,0) = 0
    public static OptFunc Rastrigin = x =>
    {
        double sum = 0;
        int n = x.Length;
        foreach (var xi in x)
            sum += (xi * xi - 10 * Math.Cos(2 * Math.PI * xi));
        return 10 * n + sum;
    };

    // Rosenbrock function: f(x) = sum(100(x_i+1 - x_i^2)^2 + (1 - x_i)^2) -> Min: f(1,1,...,1) = 0
    public static OptFunc Rosenbrock = x =>
    {
        double sum = 0;
        for (int i = 0; i < x.Length - 1; i++)
            sum += 100 * Math.Pow(x[i + 1] - x[i] * x[i], 2) + Math.Pow(1 - x[i], 2);
        return sum;
    };

    // Ackley function: f(x) = -20exp(-0.2 sqrt(1/n sum x_i^2)) - exp(1/n sum cos(2πx_i)) + 20 + e
    public static OptFunc Ackley = x =>
    {
        int n = x.Length;
        double sum1 = 0, sum2 = 0;
        foreach (var xi in x)
        {
            sum1 += xi * xi;
            sum2 += Math.Cos(2 * Math.PI * xi);
        }
        return -20 * Math.Exp(-0.2 * Math.Sqrt(sum1 / n)) - Math.Exp(sum2 / n) + 20 + Math.Exp(1);
    };

    // Griewank function: f(x) = sum(x_i^2 / 4000) - prod(cos(x_i / sqrt(i))) + 1
    public static OptFunc Griewank = x =>
    {
        double sum = 0, product = 1;
        for (int i = 0; i < x.Length; i++)
        {
            sum += x[i] * x[i] / 4000;
            product *= Math.Cos(x[i] / Math.Sqrt(i + 1));
        }
        return sum - product + 1;
    };

    // Schwefel function: f(x) = 418.9829n - sum(x_i * sin(sqrt(abs(x_i))))
    public static OptFunc Schwefel = x =>
    {
        double sum = 0;
        int n = x.Length;
        foreach (var xi in x)
            sum += xi * Math.Sin(Math.Sqrt(Math.Abs(xi)));
        return 418.9829 * n - sum;
    };

    // Zakharov function: f(x) = sum(x_i^2) + (sum(0.5 * i * x_i))^2 + (sum(0.5 * i * x_i))^4
    public static OptFunc Zakharov = x =>
    {
        double sum1 = 0, sum2 = 0;
        for (int i = 0; i < x.Length; i++)
        {
            sum1 += x[i] * x[i];
            sum2 += 0.5 * (i + 1) * x[i];
        }
        return sum1 + Math.Pow(sum2, 2) + Math.Pow(sum2, 4);
    };
}

