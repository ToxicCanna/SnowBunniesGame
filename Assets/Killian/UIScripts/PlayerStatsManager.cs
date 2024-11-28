using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : Singleton<PlayerStatsManager>
{
    private float hungerValue;
    private float maxHungerValue = 100f;
    private float warmthValue;
    private float maxWarmthValue = 100f;

    private float hungerDrainRate = 1f; // Amount hunger decreases per second
    private float warmthDrainRate = 0.5f; // Amount warmth decreases per second

    public float GetHungerValue() => hungerValue;
    public float GetMaxHungerValue() => maxHungerValue;
    public float GetWarmthValue() => warmthValue;
    public float GetMaxWarmthValue() => maxWarmthValue;

    public void Start()
    {
        hungerValue = 100f;
        warmthValue = 100f;
    }

    public void AddValueToHunger(float value)
    {
        hungerValue = Mathf.Min(hungerValue + value, maxHungerValue);
    }

    public void AddValueToWarmth(float value)
    {
        warmthValue = Mathf.Min(warmthValue + value, maxWarmthValue);
    }

    public void SetWarmthToMax()
    {
        warmthValue = maxWarmthValue;
    }

    // Update is called once per frame
    void Update()
    {
        // Drain hunger and warmth over time
        hungerValue -= hungerDrainRate * Time.deltaTime;
        warmthValue -= warmthDrainRate * Time.deltaTime;

        // Ensure values don't go below 0
        hungerValue = Mathf.Max(0f, hungerValue);
        warmthValue = Mathf.Max(0f, warmthValue);
    }
}
