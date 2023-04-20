using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteveIngot : MonoBehaviour
{

    public Vector3 EndScale, BegScale;
    public float HitsNeededToChange;
    public int CountOfChanges;

    private void Awake() {
        BegScale = this.transform.localScale;
    }

    [ContextMenu("HitByHammer")]
    public void HitByHammer(){
        // if(CountOfChanges >= HitsNeededToChange)
        //     return;
        if(!this.gameObject.GetComponent<Cookable>().hot){
            return;
        }
        transform.localScale =  new Vector3( 
            BegScale.x + ( (EndScale.x - BegScale.x)  / HitsNeededToChange  ),
           BegScale.y + ( (EndScale.y - BegScale.y)  / HitsNeededToChange ), 
           BegScale.z + ( (EndScale.z - BegScale.z)  / HitsNeededToChange )
        ) ;   //Vector3.Lerp (transform.localScale, newScale, speed * Time.deltaTime);
        BegScale = this.transform.localScale;
        CountOfChanges++;
        this.gameObject.GetComponent<Cookable>().TemperatureCount--;

    }

     public void OnCollisionEnter(Collision c)
    {
        if(c.gameObject.tag == "hammer")
        {
            HitByHammer();
        }
    }
}
