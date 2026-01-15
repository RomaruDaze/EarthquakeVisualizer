using System;
using UnityEngine;

[Serializable]
public struct EarthquakeEvent
{
    public DateTime timeUtc;
    public double latitude;
    public double longitude;
    public float depthKm;
    public float magnitude;
    public string place;

    // 計算後に使うためのキャッシュ
    public Vector3 worldPos;
}