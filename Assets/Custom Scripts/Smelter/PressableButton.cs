using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressableButton : MonoBehaviour
{
    public Transform middle;
    public Transform idle;
    public Transform press;
    public Material idleMat;
    public Material pressMat;
    public MeshRenderer mid;
    [Range(0, 5f)]
    public float speed;
    public UnityEvent ButtonPressed;
    private bool isPressed;
    

    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPressed)
        {
            middle.transform.position = Vector3.MoveTowards(middle.transform.position, press.position, speed * Time.deltaTime);
            if(Vector3.Distance(middle.transform.position, press.position) < .000001f)
            {
                middle.transform.position = idle.position;
                mid.material = idleMat;
                isPressed = false;
            }
        }
    }

    public void PressButton()
    {
        if(!isPressed)
        {
            isPressed = true;
            mid.material = pressMat;
            ButtonPressed.Invoke();
        }
    }
}
