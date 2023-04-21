using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    [Range(0, 200f)]
    public float speed;
    public GameObject item;
    public GameObject start;
    public GameObject middle;
    public GameObject end;

    private Transform current;
    private bool isEngaged;

    // Start is called before the first frame update
    void Start()
    {
        current = start.transform;
        item.transform.position = current.transform.position;
        isEngaged = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isEngaged)
        {
            MoveItem();
        }
    }

    private void MoveItem()
    {
        if(Vector3.Distance(item.transform.position, current.position) > .1)
        {
            item.transform.position = Vector3.MoveTowards(item.transform.position, current.position, speed * Time.deltaTime);
        }
        else
        {
            SignalConveyor(false);
        }
    }

    public void SignalConveyor(bool b)
    {
        isEngaged = b;
    }


}
