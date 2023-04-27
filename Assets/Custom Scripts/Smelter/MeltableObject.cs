using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MeltableObject : MonoBehaviour, IEquatable<MeltableObject>
{

    public Metal metal; // the metal that this object is
    public float temperature; // current temperature of the object | F
    [Range(0f, 1000f)]
    public float heatSpeed; // how fast the object heats up | could use specific heat if we want
    [Range(0f, 1000f)]
    public float coolSpeed; // how fast the object cools down
    public bool isMelting;

    // Start is called before the first frame update
    void Start()
    {
        isMelting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(metal != null && temperature >= metal.MeltingPoint)
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
        this.temperature += heatSpeed * Time.deltaTime;
    }

    public void CoolObject()
    {
        this.temperature -= coolSpeed * Time.deltaTime;
    }

    public bool Equals(MeltableObject other)
    {
        if (other == null) return false;

        return (this.gameObject.Equals(other.gameObject));
    }
}
