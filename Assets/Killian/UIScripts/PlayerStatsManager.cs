using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerStatsManager : Singleton<PlayerStatsManager>
{
    private float hungerValue;
    private float maxHungerValue = 100f;
    private float warmthValue;
    private float maxWarmthValue = 100f;

    [SerializeField] private float hungerDrainRate = 1f; // Amount hunger decreases per second
    [SerializeField] private float warmthDrainRate = 0.5f; // Amount warmth decreases per second

    private float zeroHungerTime = 0f; // Timer to track how long hunger has been at 0
    private float zeroWarmthTime = 0f; // Timer to track how long warmth has been at 0
    private float timeThreshold = 5f; // Time limit to lose the game if hunger or warmth is 0


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
        hungerValue = Mathf.Min(hungerValue + value, maxHungerValue);//cap the stats at the maximum
        zeroHungerTime = 0f;
    }

    public void AddValueToWarmth(float value)
    {
        warmthValue = Mathf.Min(warmthValue + value, maxWarmthValue);//cap the stats at the maximum
        zeroWarmthTime = 0f;
    }

    public void SetWarmthToMax()
    {
        warmthValue = maxWarmthValue;
        zeroWarmthTime = 0f;
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
        // Track how long hunger or warmth has been 0
        if (hungerValue == 0f)
        {
            zeroHungerTime += Time.deltaTime;
        }
        else
        {
            zeroHungerTime = 0f; // Reset timer if hunger is not 0
        }

        if (warmthValue == 0f)
        {
            zeroWarmthTime += Time.deltaTime;
        }
        else
        {
            zeroWarmthTime = 0f; // Reset timer if warmth is not 0
        }

        // Check if either hunger or warmth has been 0 for 5 seconds
        if (zeroHungerTime >= timeThreshold || zeroWarmthTime >= timeThreshold)
        {
            LoseGame();
        }
    }
    private void LoseGame()
    {
        // This method will handle game over logic
        Debug.Log("Game Over! Hunger or Warmth reached 0 for 5 seconds.");
        Application.Quit();
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }
}
