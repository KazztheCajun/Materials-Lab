using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class TouchButton : XRBaseInteractable
{
    public UnityEvent OnPress;

    private XRBaseInteractor interactor;
    private float lastHeight;
    private float yMin;
    private float yMax;
    private bool previousPress = false;


    protected override void Awake()
    {
        base.Awake();
        onSelectEnter.AddListener(StartPress);
        onSelectExit.AddListener(EndPress);
    }

    private void OnDestroy()
    {
        onSelectEnter.RemoveListener(StartPress);
        onSelectExit.RemoveListener(EndPress);
    }

    private void StartPress(XRBaseInteractor i)
    {
        interactor = i;
        lastHeight = GetLocalYPosition(i.transform.position);
    }

    private void EndPress(XRBaseInteractor i)
    {
        interactor = null;
        lastHeight = 0f;
        previousPress = false;
        SetYPosition(yMax);
    }


    // Start is called before the first frame update
    private void Start()
    {
        SetMinMax();
    }

    private void SetMinMax()
    {
        Collider collider = GetComponent<Collider>();
        yMin = transform.localPosition.y - (collider.bounds.size.y * .5f);
        yMax = transform.localPosition.y;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if(interactor)
        {
            float newHandHeight = GetLocalYPosition(interactor.transform.position);
            float handDifference = lastHeight - newHandHeight;
            lastHeight = newHandHeight;

            float newPosition = transform.localPosition.y - handDifference;
            SetYPosition(newPosition);

            CheckPress();
        }
    }

    private float GetLocalYPosition(Vector3 p)
    {
        Vector3 loc = transform.root.InverseTransformPoint(p);
        return loc.y;
    }

    private void SetYPosition(float p)
    {
        Vector3 newPosition = transform.localPosition;
        newPosition.y = Math.Clamp(p, yMin, yMax);
        transform.localPosition = newPosition;
    }

    private void CheckPress()
    {
        bool inPosition = InPosition();
        if(inPosition && inPosition != previousPress)
        {
            OnPress.Invoke();
        }
        previousPress = inPosition;
    }

    private bool InPosition()
    {
        float inRange = Math.Clamp(transform.localPosition.y, yMin, yMin + .01f);
        return transform.localPosition.y == inRange;
    }
}
