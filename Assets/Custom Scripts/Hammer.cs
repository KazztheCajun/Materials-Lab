using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public GameObject onHit;

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
        if(c.gameObject.tag == "ingot")
        {
            GameObject temp = Instantiate(onHit, c.GetContact(0).point, Quaternion.identity);
            Destroy(temp, 2);
        }
        
    }
}
