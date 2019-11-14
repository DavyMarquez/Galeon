using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public class JobControllerFib : MonoBehaviour
{
    private NativeArray<int> result;
    private JobHandle handle;
    private JobHandle secondHandle;
    private bool init = false;
    private int num = 1000;
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            LaunchJobParallel();
        }
        if (init)
        {
            if (secondHandle.IsCompleted)
            {
                secondHandle.Complete();
                init = false;
                for (int i = 0; i < num; ++i)
                {
                    Debug.Log(result[i]);
                }
                result.Dispose();
            }
        }
    }

    protected void LaunchJobParallel()
    {
        init = true;
        result = new NativeArray<int>(num, Allocator.Persistent);
        FibonacciJob fibJob = new FibonacciJob(num, ref result);
        CalcWithFibonacciParallel calcWitJob = new CalcWithFibonacciParallel(2, ref result);
        handle = fibJob.Schedule();
        secondHandle = calcWitJob.Schedule(num, 100, handle);
    }

}
