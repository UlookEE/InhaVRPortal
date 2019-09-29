using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIfollower : MonoBehaviour
{
    public Text rotation;
    public Text altitude;
    public Text speed;
    Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 directionVector = transform.TransformPoint(Vector3.up) - transform.TransformPoint(Vector3.zero);

        float cos = Vector3.Dot(directionVector, Vector3.up);
        float angle = Mathf.Acos(cos) * 360 / 2 / Mathf.PI;

        float alt = transform.position.y * 0.9482422f;
        float spd = rigidbody.velocity.magnitude;

        rotation.text = ((int)(angle * 10) / 10f).ToString();
        altitude.text = ((int)alt).ToString();
        speed.text = ((int)(spd * 10 * 0.9482422f) / 10f).ToString();
    }
}
