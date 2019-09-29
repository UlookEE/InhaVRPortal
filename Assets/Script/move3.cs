using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move3 : MonoBehaviour
{
    // Start is called before the first frame update


    public Vector3 DPower;

    private Dictionary<string, KeyCode> movementKeyBindings = new Dictionary<string, KeyCode>()
    {
            { "FORWARD", KeyCode.W },
            { "BACKWARD", KeyCode.S },
            { "LEFT", KeyCode.A },
            { "RIGHT", KeyCode.D },
            { "UP", KeyCode.Space },
            { "DOWN", KeyCode.LeftShift },
            { "ClockWise",KeyCode.E },
            { "AntiClockWise", KeyCode.Q }
    };

    private Rigidbody rb;
    public float SPEED = 1000;
    public float WEIGHT = 0.001f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -SPEED, 0);
    }

    // Update is called once per frame

    public void forceToDrone(List<float> power)
    {
        var wing = new List<Vector3> { rb.transform.TransformPoint(-0.5f, 0, 0.5f), rb.transform.TransformPoint(0.5f, 0, 0.5f),
                                           rb.transform.TransformPoint(-0.5f, 0, -0.5f), rb.transform.TransformPoint(0.5f, 0, -0.5f)};

        var force = new List<Vector3> { new Vector3(0, 1, 0), new Vector3(0, 1, 0), new Vector3(0, 1, 0), new Vector3(0, 1, 0) };


        for (int i = 0; i < force.Count; i++)
        {
            force[i] = Quaternion.Euler(Mathf.Rad2Deg * rb.rotation.x, Mathf.Rad2Deg * rb.rotation.y, Mathf.Rad2Deg * rb.rotation.z) * force[i] * power[i];
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
                addForce -= WEIGHT / 10;
                if (addForce < (1f + WEIGHT / 5) && addForce > (1f - WEIGHT / 5))
                    addForce = 1;
            }
            else
            {
                addForce += WEIGHT / 10;
                if (addForce < (1f + WEIGHT / 5) && addForce > (1f - WEIGHT / 5))
                    addForce = 1;
            }
        }
    }
    public void FixedUpdate()
    {
        var force = SPEED / 4 / Mathf.Cos(rb.transform.localRotation.x) / Mathf.Cos(rb.transform.localRotation.z);
        force *= addForce;
        if (Input.GetKey(this.movementKeyBindings["FORWARD"]))
        {
            var angle = rb.transform.localRotation.eulerAngles.x;
            if (angle < 60 || angle > 180)
            {
                forceToDrone(new List<float> { force * (1f - WEIGHT), force * (1f - WEIGHT), force * (1f + WEIGHT), force * (1f + WEIGHT) });
                adjustAddforce();
            }
            else
            {
                forceToDrone(new List<float> { force, force, force, force });
                adjustAddforce();
            }
        }
        else if (Input.GetKey(this.movementKeyBindings["BACKWARD"]))
        {
            var angle = rb.transform.localRotation.eulerAngles.x;
            if (angle > 330 || angle < 90)
            {
                forceToDrone(new List<float> { (1f + WEIGHT) * force, (1f + WEIGHT) * force, force * (1f - WEIGHT), force * (1f - WEIGHT) });
                adjustAddforce();
            }
            else
            {
                forceToDrone(new List<float> { force, force, force, force });
                adjustAddforce();
            }
        }

        else if (Input.GetKey(this.movementKeyBindings["LEFT"]))
        {
            var angle = rb.transform.localRotation.eulerAngles.z;
            if (angle < 30 || angle > 180)
            {
                forceToDrone(new List<float> { force * (1f - WEIGHT), (1f + WEIGHT) * force, force * (1f - WEIGHT), force * (1f + WEIGHT) });
                adjustAddforce();
            }
            else
            {
                forceToDrone(new List<float> { force, force, force, force });
                adjustAddforce();
            }
        }

        else if (Input.GetKey(this.movementKeyBindings["RIGHT"]))
        {
            var angle = rb.transform.localRotation.eulerAngles.z;
            if (angle > 330 || angle < 90)
            {
                forceToDrone(new List<float> { force * (1f + WEIGHT), (1f - WEIGHT) * force, force * (1f + WEIGHT), force * (1f - WEIGHT) });
                adjustAddforce();
            }
            else
            {
                forceToDrone(new List<float> { force, force, force, force });
                adjustAddforce();
            }
        }

        else if (Input.GetKey(this.movementKeyBindings["UP"]))
        {
            if (addForce < 1f + WEIGHT * 300)
                addForce += WEIGHT / 3;
            forceToDrone(new List<float> { force, force, force, force });
        }

        else if (Input.GetKey(this.movementKeyBindings["DOWN"]))
        {

            if (addForce > 1f - WEIGHT * 300)
                addForce -= WEIGHT / 3;
            forceToDrone(new List<float> { force, force, force, force });
        }
        else if (Input.GetKey(this.movementKeyBindings["ClockWise"]))
        {
            rb.transform.Rotate(rb.transform.up);
            forceToDrone(new List<float> { force, force, force, force });
            adjustAddforce();
        }
        else if (Input.GetKey(this.movementKeyBindings["AntiClockWise"]))
        {
            rb.transform.Rotate(-rb.transform.up);
            forceToDrone(new List<float> { force, force, force, force });
            adjustAddforce();
        }
        else
        {
            forceToDrone(new List<float> { force, force, force, force });
            adjustAddforce();
        }

    }
}