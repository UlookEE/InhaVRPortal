using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Transform ViewTransform;
    public Transform Camtransform;

    // Update is called once per frame
    void Update()
    {
        UnityEngine.XR.InputTracking.disablePositionalTracking = true;
        ViewTransform.rotation = Camtransform.rotation;
    }
}
