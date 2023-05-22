using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{

    public UnityEvent m_MyEvent;
    
    public HingeJoint hinge;
    public float alertAmount;

    public bool InTargetPos = false;

    void Update(){
        if(hinge.angle <= alertAmount && !InTargetPos){
            m_MyEvent.Invoke();
            InTargetPos = true;
        }

        if(InTargetPos && hinge.angle > alertAmount){
            InTargetPos = false;
        }

        // print(hinge.angle);
    }


}
