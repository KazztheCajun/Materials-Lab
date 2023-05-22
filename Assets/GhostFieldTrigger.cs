using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFieldTrigger : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.GetComponent<Corrodable>()){
            other.gameObject.GetComponent<Corrodable>().ShowMaskableChildIngot();
        }           
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.GetComponent<Corrodable>()){
            other.gameObject.GetComponent<Corrodable>().HideMaskableChildIngot();

        }           
    }
}
