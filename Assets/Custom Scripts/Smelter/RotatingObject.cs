using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObject : MonoBehaviour
{
    public enum RotationAxis {X, Y, Z}

    [Range(-1000,1000)]
    public float speed; // how fast the object rotates
    public RotationAxis first; // the first axis of rotation
    public bool hasSecondRotation; // if you want a second axis of rotation
    public RotationAxis second; // the second axis of rotation
    public bool hasThirdRotation; // if you want a third axis of rotation
    public RotationAxis third; // the third axis of rotation

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotateObject(GenerateRotation()); // smoothly rotate the object around it's center
    }

    void RotateObject(Vector3 rotation) // rotate the object by a given rotational vector
    {
        transform.Rotate(rotation);
    }

    Vector3 GenerateRotation() // generate between 1-3 rotations for this object along selected rotational axis'
    {
        Vector3 r = new Vector3();
        GetAxisOfRotation(first, r);
        if(hasSecondRotation)
        {
            GetAxisOfRotation(second, r);
        }

        if(hasThirdRotation)
        {
            GetAxisOfRotation(third, r);
        }

        return r;
    }

    void GetAxisOfRotation(RotationAxis a, Vector3 r) // incriment the given axis of the given vector by the speed of the object
    {
        switch (a)
        {
            case RotationAxis.X:
                r.x = speed * Time.deltaTime;
                break;
            case RotationAxis.Y:
                r.y = speed * Time.deltaTime;
                break;
            case RotationAxis.Z:
                r.z = speed * Time.deltaTime;
                break;
            default:
                Debug.Log($"No Rotation Axis set for {this.gameObject}");
                break;
        }
    }
}
