using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crucible : MonoBehaviour
{
    public float temperature; // the current temperature of the crucible
    public float threshold; // the temp where the contents melt
    public Material emptyMat; // material for when the contents have not melted
    public Material fullMat; // material for when the contents have melted
    public bool pourable; // can the material in the crucible be poured?

    private float fillSpeed = 10;
    private MeshRenderer fill;
    //private List<GameObject> contents;


    // Start is called before the first frame update
    void Start()
    {
        this.pourable = false;
        this.temperature = 0;
        this.fill = this.gameObject.GetComponent<MeshRenderer>();
        //this.contents = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(this.temperature >= this.threshold)
        {
            // foreach(GameObject g in contents)
            // {
            //     g.SetActive(false);
            // }
            this.fill.materials[1] = fullMat;
        }
    }

    public void HeatContents()
    {
        this.temperature += fillSpeed * Time.deltaTime;
    }

    //  void OnTriggerEnter(Collider other)
    // {
    //     if(other.gameObject.tag == "ore")
    //     {
    //         contents.Add(other.gameObject); // add it to the list of crucibles on the fire
    //         Debug.Log($"{other.gameObject} was placed in the crucible.");
    //     }
    // }

    // void OnTriggerExit(Collider other)
    // {
    //     if(other.gameObject.tag == "ore")
    //     {
    //         contents.Remove(other.gameObject);
    //         Debug.Log($"{other.gameObject} was removed from the crucible.");
    //     }
    // }
}
