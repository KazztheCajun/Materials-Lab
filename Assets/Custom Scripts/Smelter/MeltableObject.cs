using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MeltableObject : MonoBehaviour, IEquatable<MeltableObject>
{

    // the metal that this object is
    public string metalName;
    public Material roomTemp;
    public Material redHot;
    public float temperature; // current temperature of the object | F
    [Range(0f, 1000f)]
    public float threshold;
    [Range(0f, 7000f)]
    public float maxTemp;
    [Range(0f, 1000f)]
    public float heatSpeed; // how fast the object heats up | could use specific heat if we want
    [Range(0f, 1000f)]
    public float coolSpeed; // how fast the object cools down
    public bool isMelting;
    public Metal Metal
    {
        get {return metal;} 
        set {metal = value;} 
    }

    private MeshRenderer render;
    private Metal metal;

    // Start is called before the first frame update
    void Start()
    {
        isMelting = false;
        this.metalName = "Nothing";
        this.render = this.GetComponent<MeshRenderer>();
        if(render == null)
        {
            this.render = this.GetComponentInChildren<MeshRenderer>();
        }
        this.render.material = new Material(render.material); // clone prefab material so it doesn't affect all crucibles
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

    private void UpdateColor()
    {
        if(temperature >= threshold) // color change threshold
        {
            // When the cruciable is sufficiently hot, Lerp between the roomTemp material and the redHot material, scaled to a % between 0 to maxTemp
            this.render.material.Lerp(roomTemp, redHot, Mathf.Clamp(temperature - threshold, 0, maxTemp) / maxTemp);
        }
    }

    public void HeatObject()
    {
        this.temperature += heatSpeed * Time.deltaTime;
    }

    public void CoolObject()
    {
        if(this.temperature > EnvironmentSettings.RoomTemperature)
        {
            this.temperature -= coolSpeed * Time.deltaTime;
        }
    }

    public bool Equals(MeltableObject other)
    {
        if (other == null) return false;

        return (this.gameObject.Equals(other.gameObject));
    }
}
