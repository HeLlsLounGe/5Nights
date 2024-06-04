using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Threading;

public class PowerLevel : MonoBehaviour
{
    public float powerLevel = 100;
    public int levelDisplay;
    public float drainMultiplier = 0.05f;
    public float usageMultiplier = 1;
    [SerializeField] float rebootSpeed;
    float rebootTimer = -1;
    bool isRebooting = false;
    public TextMeshProUGUI display;
    Camera securityCamera;

    //Script References / power down objects
    CameraScript cameraScript;
    [SerializeField] DoorButton[] doorButtons;
    DelayCanvas delayCanvas;
    void Awake()
    {
        levelDisplay = 100;
        securityCamera = GameObject.FindWithTag("SecurityCam").GetComponent<Camera>();
        cameraScript = GameObject.FindWithTag("SecurityCam").GetComponent<CameraScript>();
        delayCanvas = GameObject.FindWithTag("MainCamera").GetComponent<DelayCanvas>();
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
        if (powerLevel <= 0) { PowerOut(); }

        if (rebootTimer > 0 && isRebooting && powerLevel > 0)
        { rebootTimer = rebootTimer - Time.deltaTime; }

        if (rebootTimer <= 0 && isRebooting)
        {
            Reboot();
        }
    }

    public void UpdateUseRate(float usage)
    {
        usageMultiplier = usageMultiplier + usage;
    }

    public void PowerOut()
    {
        cameraScript.poweredOff = true;
        securityCamera.enabled = false;
        for (int i = 0; i < doorButtons.Length; i++)
        {
           doorButtons[i].poweredDown = true;
           doorButtons[i].BaseInteract();
        }
        rebootTimer = rebootSpeed;
        isRebooting = true;
    }
    public void Reboot()
    {
        delayCanvas.delay = 0.01f;
        cameraScript.poweredOff =  false;
        for (int i = 0; i < doorButtons.Length; i++)
        {
            doorButtons[i].poweredDown = false;

        }
    }

}

