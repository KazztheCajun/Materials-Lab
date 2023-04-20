using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatArea : MonoBehaviour
{

    public bool isHeating;

    // Start is called before the first frame update
    void Start()
    {
        this.isHeating = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other) // while a cruciable is in a heating zone
    {
        if(other.gameObject.tag == "crucible")
        {
            //Debug.Log($"{other.gameObject} was heated up by {this}.");
            other.GetComponent<Crucible>().isBeingHeated = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "crucible")
        {
            other.GetComponent<Crucible>().isBeingHeated = false;
        }
    }

    public void setHeating(bool b)
    {
        this.isHeating = b;
    }


}
