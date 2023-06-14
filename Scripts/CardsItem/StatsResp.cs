using UnityEngine;

public class Stats<T>
{
    [SerializeField]
    public T rightResp;
    [SerializeField]
    public T leftResp;
}


[System.Serializable]
public class StatsRespFloat : Stats<float> { }

[System.Serializable]
public class StatsRespInt : Stats<int> { }