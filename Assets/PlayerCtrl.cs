using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class PlayerCtrl : MonoBehaviourPunCallbacks
{
    private float h, v, r;
    private Transform tr;
    public float speed = 10.0f;
    public float rotSpeed = 60.0f;
    
    void Start()
    {
        tr = GetComponent<Transform>();

    }
    void Update()
    {
        if(photonView.IsMine)
        {
            v = Input.GetAxis("Vertical");
            h = Input.GetAxis("Horizontal");
            Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
            tr.Translate(moveDir * Time.deltaTime * speed);

            r = Input.GetAxis("Mouse X");
            tr.Rotate(Vector3.up * Time.deltaTime * r * rotSpeed);

  

        }
        
    }
}
