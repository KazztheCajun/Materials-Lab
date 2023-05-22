using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class corroder : MonoBehaviour
{
    
    public bool UsingSprinklers, UsingFillTub;
    public float shakeTime;
    public float speedRotationMultiplier, MaxTimeSpentRotating;
    public List<GameObject> sprinklers = new List<GameObject>();
    public GameObject tubFiller;

    public CorroderTrigger ot;
    public Corrodable thingInOven;

    public DisplayGraph dgraph;

    
    public float bakeTime;
    float timeLeft, BeginningBakeTime, fromZeroTimer;
    public Color targetColor;
    public Renderer renderer;
    bool Baking;

    public Transform CloseOvenDoorPosition, OpenOvenDoorPosition;
    public Transform OvenDoor, cylindertrans;
    public float cylinderspeed;

    public TextMeshProUGUI text;

    public float yearsToSimulate;
    public float realLifeSecondsToSimulatedYears;

    public ParticleSystem psystem;

    // calculation variables

        public float densityInImperial;

        public float beforeVolume;

        public float beforeWeight;

        public float newVolume;

        public float newWeight;

        public float volumeLost;

        public float weightLost;

        public Vector3 newDimensions;

        public Vector3 GoalRotationalVector;

        float startTime;

        float timeCount = 0;

        public Transform worldSphere;
        public bool rotateWorldAsWell;
    
    // end calc variables
    

    public void SomethingCorrodableIsNowInTheCorroder(GameObject m){
        
        thingInOven = m.GetComponent<Corrodable>();
        renderer = m.GetComponent<Renderer>();

    }


    public void SomethingCorrodableHasNowLeftTheOven(GameObject m){
        thingInOven = null;
    }


    void ActivateSprinklers(){
        foreach( GameObject m in sprinklers ){ 
            m.SetActive(true);
        }
    }
    void DeactivateSprinklers(){
        foreach( GameObject m in sprinklers ){ 
            m.SetActive(false);
        }
    }


    [ContextMenu("StartBaking")]
    public void StartBaking(){
        if(thingInOven == null)
            return;
        ResetCalculationVariables();

        // FOR GHOST FIELD: get ingot child, disconnect it from its parent, then reconnect it later
        
        Transform maskingChild = thingInOven.childMaskableIngot;
        maskingChild.parent = null;
        maskingChild.localScale = new Vector3(thingInOven.transform.localScale.x, thingInOven.transform.localScale.y, thingInOven.transform.localScale.z );



        // change actual size of ingot

        CalculateHowThisIngotWillChange(thingInOven);
        float rawNum = Mathf.Pow(yearsToSimulate, 2f) + 2f;
        timeLeft = Mathf.Clamp( rawNum, 7f, MaxTimeSpentRotating );
        shakeTime = timeLeft;
        startTime = Time.time;
        BeginningBakeTime = timeLeft;
        // GoalRotationalVector = new Vector3( (10)*yearsToSimulate , 90, 90  ); // same y and z, x = (360 * 365)(one year of rotation) * yearsToSimulate()
        psystem.Play();
        

        Sequence s = DOTween.Sequence();
        s.Append(OvenDoor.DOMove(CloseOvenDoorPosition.position, 1.5f).SetEase(Ease.OutQuad));
        
        s.OnComplete(()=>
            {
				

                if(UsingFillTub){
                    ActivateSprinklers();
                    Sequence fillTub = DOTween.Sequence();
                    // scale tub filler to correct scale at same time as correct position
                    fillTub.Append(tubFiller.transform.DOLocalMoveY(0.5f, 3f).SetEase(Ease.OutQuad));
                    fillTub.Insert(0f, tubFiller.transform.DOScaleY(1.02f, 3f).SetEase(Ease.OutQuad));
                    
                    
                    fillTub.OnComplete(()=>{
                        DeactivateSprinklers();
                        
                        Baking = true;
                        Sequence shakeCorroder = DOTween.Sequence();
                        shakeCorroder.Insert( 0f, worldSphere.DORotate(new Vector3( (yearsToSimulate * 360f ) * speedRotationMultiplier, 0f, 0f ), shakeTime, RotateMode.FastBeyond360).SetEase(Ease.OutQuad) );
                        
                        
                        
                        shakeCorroder.OnComplete(()=>{
                            maskingChild.parent = thingInOven.transform;
                            
                            Sequence drainWater = DOTween.Sequence();
                            drainWater.Append(tubFiller.transform.DOLocalMoveY(0f, 3f).SetEase(Ease.OutQuad));
                            drainWater.Insert(0f, tubFiller.transform.DOScaleY(0f, 3f).SetEase(Ease.OutQuad));
                            drainWater.Append(OvenDoor.DOMove(OpenOvenDoorPosition.position, 1.5f).SetEase(Ease.OutQuad));

                        });
                    }); 
                
                }

        });
        
	
    }

    void Update()
    {
        if(Baking){
            if (timeLeft <= Time.deltaTime)
            {
                // transition complete
                // assign the target color
                renderer.material.color = targetColor;
                EndBaking();

            }
            else
            {
                // transition in progress
                // calculate interpolated color
                renderer.material.color = Color.Lerp(renderer.material.color, targetColor, Time.deltaTime / timeLeft);
                UpdateDisplayText();

                
                timeLeft -= Time.deltaTime;
                fromZeroTimer += Time.deltaTime;
            }
        }
    }

    [ContextMenu("EndBaking")]
    void EndBaking(){
        Baking = false;
        thingInOven.corroded = true;
        thingInOven.transform.localScale = newDimensions;
        psystem.Stop();

    }




    [ContextMenu("CalculateHowThisIngotWillChange")]
    public void CalculateHowThisIngotWillChange(Corrodable m){
        Vector3 oldDimensions = m.gameObject.transform.localScale;
        // print(oldDimensions);

         densityInImperial = m.density;

         beforeVolume = oldDimensions.x * oldDimensions.y * oldDimensions.z;

        // print(beforeVolume);

         beforeWeight = ConvertThisDensityToMetric(densityInImperial)*beforeVolume;

         newDimensions = new Vector3( (oldDimensions.x-(yearsToSimulate*m.rustRate) ) , (oldDimensions.y-(yearsToSimulate*m.rustRate) ) , (oldDimensions.z-(yearsToSimulate*m.rustRate) ) );

         newVolume = (oldDimensions.x-(yearsToSimulate*m.rustRate) ) * (oldDimensions.y-(yearsToSimulate*m.rustRate) ) * (oldDimensions.z-(yearsToSimulate*m.rustRate) );

         newWeight = ConvertThisDensityToMetric(densityInImperial)*newVolume;

         volumeLost = beforeVolume - newVolume;

         weightLost = beforeWeight - newWeight;

        print(" initial weight: " + beforeWeight + " weight lost: " + weightLost + ". volume lost: " + volumeLost);

    }

    void ResetCalculationVariables(){
        densityInImperial = 0f;
        beforeVolume = 0f;
        beforeWeight = 0f;
        newDimensions = Vector3.zero;
        newVolume = 0f;
        newWeight = 0f;
        weightLost = 0f;
        fromZeroTimer = 0f;

    }

    float ConvertThisDensityToMetric(float preConvert){
        // 7.85 lb/ft³ = (7.85 lb/ft³) x (0.453592 kg/lb) / (0.3048 m/ft)^3

        float newFloat = preConvert * 0.453592f / Mathf.Pow(0.3048f,3f);
        // print( newFloat);
        return newFloat;


    }

    void UpdateDisplayText(){
        text.text = "Simulated Years of Corrosion: " +  (yearsToSimulate ) + // (( (thingInOven.rustRate * yearsToSimulate) * 1000)*(fromZeroTimer/shakeTime)) 
        " \n Name: " + thingInOven.materialDisplayName + 
        " \n Milimeter(s) lost to corrosion: \n  " + Mathf.Round( ((( (thingInOven.rustRate * yearsToSimulate))*(fromZeroTimer/shakeTime)) * 1000f) * 100f) / 100f + "mm " + 
        " \n Weight lost: \n " + Mathf.Round( ((weightLost*(fromZeroTimer/shakeTime)) * 1000f) * 100f) / 100f + " g" + 
        "\n Volume lost: \n " + Mathf.Round(((volumeLost*(fromZeroTimer/shakeTime)) * 1000f) * 100f) / 100f  + " mm^3";

        // this will be where the fillers are adjusted
        // filler val should be the metal normalized val of what, 
        float fillVal = (( (thingInOven.rustRate * yearsToSimulate) * 1000)*(fromZeroTimer/shakeTime)) / ( (thingInOven.rustRate * yearsToSimulate) * 1000f );
        dgraph.SetFillerVal(thingInOven.materialDisplayName, fillVal, yearsToSimulate);


    }







}
