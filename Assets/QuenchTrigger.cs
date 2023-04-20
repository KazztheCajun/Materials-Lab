using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuenchTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.GetComponent<Cookable>()){
            other.gameObject.GetComponent<Cookable>().TemperatureCount = -1;
        }           
    }

}
