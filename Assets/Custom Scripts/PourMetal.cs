using System.Collections;
using UnityEngine;
// using LiquidVolumeFX;

public class PourMetal : MonoBehaviour
{
    public int pourThreshold = 45;
    public ParticleSystem waterParticleSystem;
    public Crucible pot; // ref to the crucible this script is attached to
    // public LiquidVolume lv;

    private bool isPouring = false;


    private void Start()
    {
        EnableParticleEmission(false);
    }

    private void Update()
    {
        if(pot.Pourable) // only pour if the metal is higher than a threshold | should get from the material in the crucible
        {
            bool pourCheck = CalculatePourAngle() < pourThreshold;

            if(isPouring != pourCheck)
            {
                isPouring = pourCheck;

                if (isPouring)
                {
                    StartPour();
                }
                else
                {
                    EndPour();
                }
            }
        }
        

        if (isPouring)
        {
            //updateSpillPoint
            UpdateSpillPoint();
        }
    }

    private void StartPour()
    {
        print("start");
        EnableParticleEmission(true);
    }

    private void UpdateSpillPoint()
    {
        // Vector3 spillPoint;
        // lv.GetSpillPoint(out spillPoint);
        // waterParticleSystem.transform.position = spillPoint;
    }

    private void EndPour()
    {
        print("End");
        EnableParticleEmission(false);
    }

    private float CalculatePourAngle()
    {
        return transform.up.y * Mathf.Rad2Deg;
    }

    public void EnableParticleEmission(bool enabled)
    {
        var em = waterParticleSystem.emission;
        em.enabled = enabled;
    }
}