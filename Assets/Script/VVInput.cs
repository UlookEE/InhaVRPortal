using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VVInput : MonoBehaviour
{
    public SteamVR_ActionSet m_ActionSet;

    //public SteamVR_Action_Vector2 m_BooleanAction;
    public SteamVR_Action_Single squeezeAction;
    public SteamVR_Action_Vector2 touchPadAction;

    public float triggerValue;
    public Vector2 touchpadValue;

    private void Awake()
    {
        //m_BooleanAction = SteamVR_Actions._default.TouchPadTouch;
    }

    private void Start()
    {
        m_ActionSet.Activate(SteamVR_Input_Sources.Any, 0, true);
    }

    void Update()
    {
        //Vector2 k = SteamVR_Actions.default_TouchPadTouch.GetAxis(SteamVR_Input_Sources.Any);
        //if(k != Vector2.zero)
        //{
        //    print("Teleport up");
        //}

        if (SteamVR_Actions.default_GrabPinch.GetStateUp(SteamVR_Input_Sources.Any))
        {
            print("Grab pinch up");
        }

        triggerValue = squeezeAction.GetAxis(SteamVR_Input_Sources.Any);

        if(triggerValue > 0.0f)
        {
            print(triggerValue);
        }

        touchpadValue = touchPadAction.GetAxis(SteamVR_Input_Sources.Any);
        
        if(touchpadValue != Vector2.zero)
        {
            print(touchpadValue.ToString());
        }
    }
}
