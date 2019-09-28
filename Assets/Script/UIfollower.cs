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
        float alt = transform.position.y * 0.9482422f;
        float spd = rigidbody.velocity.magnitude;

        altitude.text = ((int)alt).ToString();
        speed.text = ((int)(spd * 10 * 0.9482422f) / 10f).ToString();
    }
}
