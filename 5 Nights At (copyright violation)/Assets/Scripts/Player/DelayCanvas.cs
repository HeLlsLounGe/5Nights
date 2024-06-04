using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayCanvas : MonoBehaviour
{
    [SerializeField] Canvas delayCanvas;
    bool isActive = false;
    public float delay = 0.05f;
    float delayTimer;
    [SerializeField] float timerMult = 1.05f;
    void Start()
    {
        delayCanvas.enabled = false;
        delayTimer = delay;
    }
    void Update()
    {
        
    }

    public void CanvasActivated()
    {
        delayCanvas.enabled = true;
        Invoke("CanvasDeactivated", delayTimer);
    }
    public void CanvasDeactivated()
    {
        delayTimer = delayTimer * timerMult;
        delayCanvas.enabled = false;
    }
    public void Rebootsystem()
    {
        delayTimer = delay;
    }
}
