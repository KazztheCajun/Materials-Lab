using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectroSmelter : MonoBehaviour
{
    public List<ParticleSystem> effects;
    // Start is called before the first frame update

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
