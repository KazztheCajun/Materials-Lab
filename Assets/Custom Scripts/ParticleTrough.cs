using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleTrough : MonoBehaviour
{
    
    public float _currentParticleCount;
    public float currentParticleCount{
        get{
            return _currentParticleCount;

        } 

        set{
            _currentParticleCount = value;
            UpdateFillerAmount();

        }
    }
    public bool Full{
        get{
            if(currentParticleCount >= particleThreshhold){
                return true;
            }
            return false;
        }
    }
    public float particleThreshhold;
    public GameObject Filler;
    public float startingFillerY, maxFillerY;
    public GameObject Sword;


    private void OnParticleCollision(GameObject other)
    {
        
        //Destroy(other);
        if(currentParticleCount < particleThreshhold)
        currentParticleCount++;
        // if(currentParticleCount > particleThreshhold){
        //     Destroy(this.gameObject);
        // }

    }

    void UpdateFillerAmount(){
        // adjust height of filler from min pos to max depending on the percentage of currentPart to Threshhold
        Filler.transform.localPosition = new Vector3(Filler.transform.localPosition.x
        , startingFillerY + ( (maxFillerY - startingFillerY) * (currentParticleCount / particleThreshhold) )
        ,Filler.transform.localPosition.z);

        // if(Filler.transform.localPosition.y >= maxFillerY){
        //     Full();
        // }

        print("a" + (maxFillerY - startingFillerY));
        print("b" + (currentParticleCount / particleThreshhold));
        print("c" + ( (maxFillerY - startingFillerY) * (currentParticleCount / particleThreshhold) ) );
        print("calculated y is " + ( startingFillerY + ( (maxFillerY - startingFillerY) * (currentParticleCount / particleThreshhold) ) ) );
    }

    // void Full(){
    //     ResetFiller();
    //     SpawnSword();
    // }

    public void SpawnSword(){
        // activate sword
        // unparent it
        
        GameObject go = GameObject.Instantiate(Sword);
        go.transform.position = Sword.transform.position;
        go.SetActive(true);
        // Sword.transform.parent = null;
    }

    void ResetFiller(){
        Filler.transform.localPosition = new Vector3(Filler.transform.localPosition.x
        , startingFillerY
        ,Filler.transform.localPosition.z);
        currentParticleCount = 0;
    }

    public void TryAndSpawnSword(){
        // if filler is full, work
        // otherwise do nothing
        if(Full){
            ResetFiller();
            SpawnSword();
        }
    }

}
