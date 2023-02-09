using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MalleableIngot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision c)
    {
        if(c.gameObject.tag == "hammer")
        {
            this.transform.localScale = Vector3.Scale(this.transform.localScale, new Vector3(1.1f, .9f, 1.1f)); 
        }
    }
}
