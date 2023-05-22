using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HammerButtonController : MonoBehaviour
{
    // public HammerButton

    public corroder cor;
    public TextMeshProUGUI yearDisplay;

    public void thisButtonHit(HammerButton hit){
        cor.yearsToSimulate = hit.years;
        yearDisplay.text = "Years To Simulate: \n" + hit.years;

    }



}
