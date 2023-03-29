using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coals : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "crucible")
        {
            //Debug.Log($"{other.gameObject} was heated up by {this}.");
            other.GetComponent<Crucible>().HeatContents();
        }
    }


}
