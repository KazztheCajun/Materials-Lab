using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeltableObject : MonoBehaviour
{

    public Metal metal; // the metal that this object is
    public float temperature; // current temperature of the object | F
    [Range(0f, 1000f)]
    public float fillSpeed; // how fast the object heats up | could use specific heat if we want
    public bool isMelting;

    // Start is called before the first frame update
    void Start()
    {
        isMelting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(temperature >= metal.MeltingPoint)
        {
            isMelting = true;
        }
        else
        {
            isMelting = false;
        }
    }

    public void HeatObject()
    {
        this.temperature += fillSpeed * Time.deltaTime;
    }
}
