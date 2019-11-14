using Unity.Collections;
using Unity.Jobs;

public struct CalcWithFibonacciJob : IJob
{
    private int divisor;
    public NativeArray<int> fibonacciSerie;
    public CalcWithFibonacciJob(int div, ref NativeArray<int> arr)
    {
        divisor = div;
        fibonacciSerie = arr;
    }
    private void FibonacciDivisor(int divisor)
    {
        for (int i = 0; i < fibonacciSerie.Length; ++i)
        {
            fibonacciSerie[i] = fibonacciSerie[i] / divisor;
        }
    }
    public void Execute()
    {
        FibonacciDivisor(divisor);
    }
}