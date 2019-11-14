using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public struct CalcWithFibonacciParallel : IJobParallelFor
{
    private int divisor;
    public NativeArray<int> fibonacciSerie;

    public CalcWithFibonacciParallel(int a_divisor, ref NativeArray<int> arr)
    {
        divisor = a_divisor; fibonacciSerie = arr;
    }
    public void Execute(int index)
    {
        fibonacciSerie[index] = fibonacciSerie[index] / divisor;
    }
}
