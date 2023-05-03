using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crucible : MonoBehaviour
{
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
     


    // Start is called before the first frame update
    void Start()
    {
        this.pourable = false;
        this.items = new List<MeltableObject>();
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
