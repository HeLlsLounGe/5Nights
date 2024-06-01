using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PowerLevel : MonoBehaviour
{
    public float powerLevel = 100;
    public int levelDisplay;
    public float drainMultiplier = 0.05f;
    public float usageMultiplier = 1;
    public TextMeshProUGUI display;
    Camera securityCamera;
    void Awake()
    {
        levelDisplay = 100;
        securityCamera = GameObject.FindWithTag("SecurityCam").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (powerLevel > 0)
        {
            powerLevel = powerLevel - (Time.deltaTime * drainMultiplier * usageMultiplier);
        }
        levelDisplay = Mathf.RoundToInt(powerLevel);
        display.SetText(levelDisplay + "%");
    }

    public void UpdateUseRate(float usage)
    {
        usageMultiplier = usageMultiplier + usage;
    }
}

