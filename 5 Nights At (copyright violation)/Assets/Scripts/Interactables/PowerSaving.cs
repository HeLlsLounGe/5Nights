using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSaving : Interactable
{
    [SerializeField] Light warningLight;
    [SerializeField] float saveTimeMin;
    [SerializeField] float saveTimeMax;
    [SerializeField] float refreshMult;
    [SerializeField] float powerUseRate;
    float saveTimerMax,saveTimerMin;
    PowerLevel powerLevel;
    void Awake()
    {
        saveTimerMax = saveTimeMax;
        saveTimerMin = saveTimeMin;
        warningLight.enabled = false;
        powerLevel =GameObject.FindWithTag("MainCamera").GetComponent<PowerLevel>();
    }

    void CountDown()
    {
        float saveTimer = Random.Range(saveTimerMax, saveTimerMin);
        Invoke("PowerSaveLeave", saveTimer);
    }

    void PowerSaveLeave()
    {
        saveTimerMin = saveTimerMin * refreshMult;
        saveTimerMax = saveTimerMax * refreshMult;
        powerLevel.UpdateUseRate(powerUseRate);
        warningLight.enabled = true;
    }

    void PowerSaveEnter()
    {
        warningLight.enabled = false;
        powerLevel.UpdateUseRate(-powerUseRate);
        CountDown();
    }
    protected override void Interact()
    {
        PowerSaveEnter();
    }
}
