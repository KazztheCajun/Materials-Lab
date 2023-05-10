using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Crucible : MonoBehaviour
{
    public List<MeltableObject> materials;
    public UnityEvent<string> materialAdded;
    public UnityEvent<string> materialRemoved;
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
     


    // Start is called before the first frame update
    void Start()
    {
        this.pourable = false;
        this.materials = new List<MeltableObject>();
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

        if(materials.Count > 0)
        {
            pourable = true; // assume it is pourable
            foreach(MeltableObject o in materials)
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
            MeltableObject o = other.gameObject.GetComponent<MeltableObject>();
            Debug.Log($"Adding {o.metal.MetalName} to the cruciable");
            materials.Add(o); // when an Item enters the trigger area, add it to the item list
            materialAdded.Invoke(o.metal.MetalName);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "meltable")
        {
            MeltableObject o = other.gameObject.GetComponent<MeltableObject>();
            Debug.Log($"Removing {o.metal.MetalName} from the cruciable");
            materials.Remove(o); // when the Item leaves the trigger, remove it from the item list
            materialRemoved.Invoke(o.metal.MetalName);
        }
    }

    public void HeatContents()
    {
        this.thermo.HeatObject();
        // Heat up each meltable object inside the crucible
        if(materials.Count > 0) // if there are materials in the list
        {
            foreach(MeltableObject o in materials)
            {
                o.HeatObject();
            }
        }
    }

    public void CoolContents()
    {
        // cool off each meltable object inside the crucible
        this.thermo.CoolObject();
        if(materials.Count > 0) // if there are materials in the list
        {
            foreach(MeltableObject o in materials)
            {
                o.CoolObject();
            }
        }
    }

}
