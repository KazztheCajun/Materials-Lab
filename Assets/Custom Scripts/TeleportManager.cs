using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportManager : MonoBehaviour
{
    public InputActionAsset actionAsset;
    public XRRayInteractor ray;



    // Start is called before the first frame update
    void Start()
    {
        ray.enabled = false;
        var activate = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Mode Activate");
        var cancel = actionAsset.FindActionMap("XRI LeftHand Locomotion").FindAction("Teleport Mode Cancel");
        activate.Enable();
        cancel.Enable();

        activate.performed += OnTeleportActivate;
        cancel.performed += OnTeleportCancel;
    }

    // Update is called once per frame
    
 
    void OnTeleportActivate(InputAction.CallbackContext context) 
    {
        //Debug.Log("Teleportation Active");
        ray.enabled = true;
    }

    void OnTeleportCancel(InputAction.CallbackContext context)
    {
        //Debug.Log("Teleportation Canceled");
        ray.enabled = false;
    }
}
