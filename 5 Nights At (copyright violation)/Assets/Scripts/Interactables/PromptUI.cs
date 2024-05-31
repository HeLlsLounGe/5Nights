using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PromptUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI promtText;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateText(string promtMessage)
    {
        promtText.text = promtMessage;
    }
}
