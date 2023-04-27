using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroSmelter : MonoBehaviour
{
    public List<ParticleSystem> effects;
    // Start is called before the first frame update

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "crucible")
        {
            Crucible c = other.gameObject.GetComponent<Crucible>();
            Debug.Log(effects[0].isPlaying);
            if(effects[0].isPlaying) // if the forge is active
            {
                c.IsBeingHeated = true; // the cruciable is being heated
            }
            else
            {
                c.IsBeingHeated = false;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "crucible")
        {
            other.GetComponent<Crucible>().IsBeingHeated = false; // when the cruciable leaves the heating area, it is not longer being heated
        }
    }

    public void ToggleEffects()
    {
        foreach(ParticleSystem effect in effects)
        {
            if(effect.isPlaying)
            {
                effect.Stop();
            }
            else
            {
                effect.Play();
            }
        }
        
    }
}
