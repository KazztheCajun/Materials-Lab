using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookable : MonoBehaviour
{
    
    bool _hot;
    public bool hot{
        get{
            return _hot;
        } set{
            _hot = value;
            if(value == true){
                TemperatureCount = maxTempCount;
            }
        }
    }

    public int _TemperatureCount;
    public int TemperatureCount{
        get{
            return _TemperatureCount;
        }
        set{
            _TemperatureCount = value;
            if(value <= 0){
                SetColorToStart();
                hot = false;
            }
        }
    }
    public int maxTempCount;

    public Color targetColor;
    public Renderer renderer;

    void SetColorToStart(){
        renderer.material.color = targetColor;
    }

}
