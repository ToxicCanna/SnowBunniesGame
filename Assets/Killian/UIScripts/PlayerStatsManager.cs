using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : Singleton<PlayerStatsManager>
{
    private float hungerValue;
    private float maxHungerValue = 100f;
    private float warmthValue;
    private float maxWarmthValue = 100f;

    public void Start()
    {
        hungerValue = 100f;
        warmthValue = 100f;
    }

    public float GetHungerValue()
    {
        return hungerValue;
    }
    public float GetMaxHungerValue()
    {
        return maxHungerValue;
    }

    public float GetWarmthValue()
    {
        return warmthValue;
    }
    public float GetMaxWarmthValue()
    {
        return maxWarmthValue;
    }

    public void AddValueToHunger(float value)
    {
        hungerValue += value;
    }

    public void AddValueToWarmth(float value)
    {
        warmthValue += value;
    }

    public void SetWarmthToMax()
    {
        warmthValue = 100f;
    }

    // Update is called once per frame
    void Update()
    {
                
    }
}
