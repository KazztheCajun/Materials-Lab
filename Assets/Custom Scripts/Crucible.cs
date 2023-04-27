using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crucible : MonoBehaviour
{
    public float maxTemp;
    public Material roomTemp;
    public Material redHot;
    public List<MeltableObject> items;
    

    public bool Pourable => pourable;
    public bool IsBeingHeated 
    {
        get {return isBeingHeated;} 
        set {isBeingHeated = value;} 
    }
    public MeltableObject Thermo => thermo;

    private bool pourable; // can the material in the crucible be poured?
    private bool isBeingHeated; // is the crucible currently being heated by something
    private MeltableObject thermo; // thermodynamic information
    private MeshRenderer render; 


    // Start is called before the first frame update
    void Start()
    {
        this.pourable = false;
        this.items = new List<MeltableObject>();
        this.render = this.GetComponent<MeshRenderer>();
        this.render.material = new Material(render.material); // clone prefab material so it doesn't affect all crucibles
        this.isBeingHeated = false;
        this.thermo = this.GetComponent<MeltableObject>();
        //this.contents = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(isBeingHeated)
        {
            HeatContents(); // heat em up
        }
        else
        {
            CoolContents();
        }

        UpdateColor();

        if(items.Count > 0)
        {
            pourable = true; // assume it is pourable
            foreach(MeltableObject o in items)
            {
                if(!o.isMelting)
                {
                    pourable = false; // prove it wrong
                    break; // no need to check the others
                }
            }
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "meltable")
        {
            Debug.Log($"Adding {other.gameObject} to the cruciable");
            items.Add(other.gameObject.GetComponent<MeltableObject>()); // when an Item enters the trigger area, add it to the item list
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "meltable")
        {
            Debug.Log($"Removing {other.gameObject} from the cruciable");
            items.Remove(other.gameObject.GetComponent<MeltableObject>()); // when the Item leaves the trigger, remove it from the item list
        }
    }

    private void UpdateColor()
    {
        if(thermo.temperature >= 600) // color change threshold
        {
            // When the cruciable is sufficiently hot, Lerp between the roomTemp material and the redHot material, scaled to a % between 0 to maxTemp
            this.render.material.Lerp(roomTemp, redHot, Mathf.Clamp(thermo.temperature - 600, 0, maxTemp) / maxTemp);
        }
    }

    public void HeatContents()
    {
        this.thermo.HeatObject();
        // Heat up each meltable object inside the crucible
        if(items.Count > 0) // if there are items in the list
        {
            foreach(MeltableObject o in items)
            {
                o.HeatObject();
            }
        }
    }

    public void CoolContents()
    {
        // cool off each meltable object inside the crucible
        this.thermo.CoolObject();
        if(items.Count > 0) // if there are items in the list
        {
            foreach(MeltableObject o in items)
            {
                o.CoolObject();
            }
        }
    }

}
