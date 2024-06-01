using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherDoor : MonoBehaviour
{
    [SerializeField] float usageMult;
    MeshRenderer meshRenderer;
    PowerLevel powerLevel;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        powerLevel = GameObject.FindWithTag("MainCamera").GetComponent<PowerLevel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
