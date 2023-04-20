using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorroderTrigger : MonoBehaviour
{


    public Transform AnchorPosition;
    public corroder corroderParent;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.GetComponent<Corrodable>()){
            other.gameObject.transform.position = AnchorPosition.position;
            other.gameObject.transform.rotation = AnchorPosition.rotation;
            corroderParent.SomethingCorrodableIsNowInTheCorroder(other.gameObject);
        }           
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.GetComponent<Corrodable>()){
            corroderParent.SomethingCorrodableHasNowLeftTheOven(other.gameObject);
        }           
    }

    
}
