using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerButton : MonoBehaviour
{



    public HammerButtonController con;
    public int years;

    public void HitByHammer(){
        
        con.thisButtonHit(this);


    }

     public void OnCollisionEnter(Collision c)
    {
        if(c.gameObject.tag == "hammer")
        {
            HitByHammer();
        }
    }
}
