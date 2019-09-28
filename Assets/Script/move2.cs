using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class move2 : MonoBehaviour
{
    // Start is called before the first frame update

    public SteamVR_TrackedObject divice;
    //public SteamVR_Controller.Device mdeive;

    public Vector3 DPower;

    private Dictionary<string, KeyCode> movementKeyBindings = new Dictionary<string, KeyCode>()
    {
            { "FORWARD", KeyCode.W },
            { "BACKWARD", KeyCode.S },
            { "LEFT", KeyCode.A },
            { "RIGHT", KeyCode.D },
            { "UP", KeyCode.Space },
            { "DOWN", KeyCode.LeftShift }


    };

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -100, 0);
    }

    // Update is called once per frame

    public void forceToDrone(List<float> power)
    {
        var wing = new List<Vector3> { rb.transform.TransformPoint(-0.5f, 0, 0.5f), rb.transform.TransformPoint(0.5f, 0, 0.5f),
                                           rb.transform.TransformPoint(-0.5f, 0, -0.5f), rb.transform.TransformPoint(0.5f, 0, -0.5f)};

        var force = new List<Vector3> { new Vector3(0, 1, 0), new Vector3(0, 1, 0), new Vector3(0, 1, 0), new Vector3(0, 1, 0) };

        for (int i = 0; i < force.Count; i++)
        {
            force[i] = Quaternion.EulerAngles(rb.rotation.x, rb.rotation.y, rb.rotation.z) * force[i] * power[i];
            rb.AddForceAtPosition(force[i], wing[i]);
        }
        rb.velocity = new Vector3(0, 0, 0);
    }

    public static float addForce = 1f;

    public void adjustAddforce()
    {

        if (addForce != 1f)
        {

            if (addForce > 1f)
            {
                Debug.Log("AddForce: " + addForce);
                addForce -= 0.004f;
            }
            else
            {
                Debug.Log("AddForce: " + addForce);
                addForce += 0.004f;
            }
        }
    }

    public void FixedUpdate()
    {


        var force = 25f / Mathf.Cos(rb.transform.localRotation.x) / Mathf.Cos(rb.transform.localRotation.z);
        force *= addForce;
        if (Input.GetKey(this.movementKeyBindings["FORWARD"]))
        {
            forceToDrone(new List<float> { force * 0.95f, force * 0.95f, force * 1.05f, force * 1.05f });
            adjustAddforce();
        }
        else if (Input.GetKey(this.movementKeyBindings["BACKWARD"]))
        {
            forceToDrone(new List<float> { 1.05f * force, 1.05f * force, force * 0.95f, force * 0.95f });
            adjustAddforce();
        }

        else if (Input.GetKey(this.movementKeyBindings["LEFT"]))
        {
            forceToDrone(new List<float> { force * 0.95f, 1.05f * force, force * 0.95f, force * 1.05f });
            adjustAddforce();
        }

        else if (Input.GetKey(this.movementKeyBindings["RIGHT"]))
        {

            forceToDrone(new List<float> { force * 1.05f, 0.95f * force, force * 1.05f, force * 0.95f });
            adjustAddforce();
        }

        else if (Input.GetKey(this.movementKeyBindings["UP"]))
        {
            if (addForce < 1.2f)
                addForce += 0.004f;
            forceToDrone(new List<float> { force, force, force, force });
        }

        else if (Input.GetKey(this.movementKeyBindings["DOWN"]))
        {

            if (addForce > 0.8f)
                addForce -= 0.004f;
            forceToDrone(new List<float> { force, force, force, force });
        }
        else
        {
            forceToDrone(new List<float> { force, force, force, force });
            adjustAddforce();
        }

    }

}