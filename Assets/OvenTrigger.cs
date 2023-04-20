using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenTrigger : MonoBehaviour
{


    public Transform AnchorPosition;
    public Oven oven;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.GetComponent<Cookable>()){
            other.gameObject.transform.position = AnchorPosition.position;
            other.gameObject.transform.rotation = AnchorPosition.rotation;
            oven.SomethingCookableIsNowInTheOven(other.gameObject);
        }           
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.GetComponent<Cookable>()){
            oven.SomethingCookableHasNowLeftTheOven(other.gameObject);
        }           
    }
}
