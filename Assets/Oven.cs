using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
    

    public OvenTrigger ot;
    public Cookable thingInOven;


    public float bakeTime;
    float timeLeft;
    public Color targetColor;
    public Renderer renderer;
    bool Baking;

    public Transform CloseOvenDoorPosition, OpenOvenDoorPosition;
    public Transform OvenDoor;
    
    void Update()
    {
        if(Baking){
            if (timeLeft <= Time.deltaTime)
            {
                // transition complete
                // assign the target color
                renderer.material.color = targetColor;
                EndBaking();
                // // start a new transition
                // targetColor = new Color(Random.value, Random.value, Random.value);
                // timeLeft = 1.0f;
            }
            else
            {
                // transition in progress
                // calculate interpolated color
                renderer.material.color = Color.Lerp(renderer.material.color, targetColor, Time.deltaTime / timeLeft);
            
                // update the timer
                timeLeft -= Time.deltaTime;
            }
        }
    }

    [ContextMenu("StartBaking")]
    void StartBaking(){
        OvenDoor.position = CloseOvenDoorPosition.position;
        Baking = true;
        timeLeft = bakeTime;
    }

    [ContextMenu("EndBaking")]
    void EndBaking(){
        Baking = false;
        OvenDoor.position = OpenOvenDoorPosition.position;
        thingInOven.hot = true;

    }


    public void SomethingCookableIsNowInTheOven(GameObject m){
        if(m.GetComponent<Cookable>().hot){
            return;
        }
        thingInOven = m.GetComponent<Cookable>();
        StartBaking();
    }


    public void SomethingCookableHasNowLeftTheOven(GameObject m){
        thingInOven = null;
    }



}
