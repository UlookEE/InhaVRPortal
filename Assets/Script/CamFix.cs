using UnityEngine;
using UnityEngine.XR;

public class CamFix : MonoBehaviour
{
    void Update()
    {
        transform.localPosition = new Vector3(0f, 0f, 0f);
        transform.GetChild(0).localPosition = Vector3.zero;
    }
}
