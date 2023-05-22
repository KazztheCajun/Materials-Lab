using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corrodable : MonoBehaviour
{
    
    public bool corroded;
    public float corrodeTime;

    public float density;

    public float rustRate;

    public string materialDisplayName;

    public Transform childMaskableIngot;

    public void HideMaskableChildIngot(){
        childMaskableIngot.gameObject.SetActive(false);
    }
    public void ShowMaskableChildIngot(){
        childMaskableIngot.gameObject.SetActive(true);
    }
    

}
