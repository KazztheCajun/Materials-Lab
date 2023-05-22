using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayGraph : MonoBehaviour
{
    

    public Image _1metal304, _1metal316;
    public Image _5metal304, _5metal316;
    public Image _10metal304, _10metal316;
    public TextMeshProUGUI maxText;
    public float maxMmLost;

    public void SetFillerVal(string metal, float sliderVal, float years){
        
        if(years < 2f){
            
            if(metal.Contains("304") ){
                _1metal304.fillAmount = sliderVal;
            } else if (metal.Contains("316")) {
                _1metal316.fillAmount = sliderVal;

            }

        } else if(years < 6f){
            
            if(metal.Contains("304") ){
                _5metal304.fillAmount = sliderVal;
            } else if (metal.Contains("316")) {
                _5metal316.fillAmount = sliderVal;

            }
        } else {
            
            if(metal.Contains("304") ){
                _10metal304.fillAmount = sliderVal;
            } else if (metal.Contains("316")) {
                _10metal316.fillAmount = sliderVal;

            }
        }


    }



}
