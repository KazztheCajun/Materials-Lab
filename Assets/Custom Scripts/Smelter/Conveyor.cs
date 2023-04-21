using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    [Range(0, 200f)]
    public float speed;
    public Transform item;
    public Transform start;
    public Transform middle;
    public Transform end;

    private Transform current;
    private bool isEngaged;

    // Start is called before the first frame update
    void Start()
    {
        current = middle;
        item.position = start.position;
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
        if(Vector3.Distance(item.position, current.position) > .1)
        {
            item.position = Vector3.MoveTowards(item.position, current.position, speed * Time.deltaTime);
        }
        else
        {
            if(current == middle)
            {
                SignalConveyor(false);
                current = end;
            }
            else
            {
                SignalConveyor(false);
                current = middle;
                item.position = start.position;
            }
        }
    }

    public void SignalConveyor(bool b)
    {
        isEngaged = b;
    }


}
