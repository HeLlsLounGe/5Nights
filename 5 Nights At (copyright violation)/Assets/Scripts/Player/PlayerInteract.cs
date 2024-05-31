using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] float distance = 8;
    private Camera cam;
    [SerializeField] private LayerMask mask;
    private PromptUI promptUI;
    void Start()
    {
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        promptUI = GetComponent<PromptUI>();
    }

    // Update is called once per frame
    void Update()
    {
        promptUI.UpdateText(string.Empty);
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if (hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                promptUI.UpdateText(interactable.promtMessage);
                if (Input.GetButtonDown("Fire1"))
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
