using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class corroder : MonoBehaviour
{
    
    public CorroderTrigger ot;
    public Corrodable thingInOven;

    
    public float bakeTime;
    float timeLeft;
    public Color targetColor;
    public Renderer renderer;
    bool Baking;

    public Transform CloseOvenDoorPosition, OpenOvenDoorPosition;
    public Transform OvenDoor, cylindertrans;
    public float cylinderspeed;

    public TextMeshProUGUI text;
    
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
            
                cylindertrans.Rotate(Vector3.up, Time.deltaTime * cylinderspeed);     //...rotate the object.
                // update the timer
                timeLeft -= Time.deltaTime;
            }
        }
    }

    [ContextMenu("StartBaking")]
    public void StartBaking(){
        if(thingInOven == null)
            return;
        OvenDoor.position = CloseOvenDoorPosition.position;
        Baking = true;
        timeLeft = thingInOven.corrodeTime;
    }

    [ContextMenu("EndBaking")]
    void EndBaking(){
        Baking = false;
        OvenDoor.position = OpenOvenDoorPosition.position;
        thingInOven.corroded = true;
        text.text = "Simulated Days of Corrosion: " + thingInOven.corrodeTime;

    }

    public void SomethingCorrodableIsNowInTheCorroder(GameObject m){
        // if(m.GetComponent<Corrodable>().corroded){
        //     return;
        // }
        thingInOven = m.GetComponent<Corrodable>();
        // StartBaking();
    }


    public void SomethingCorrodableHasNowLeftTheOven(GameObject m){
        thingInOven = null;
    }


}
