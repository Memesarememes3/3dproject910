using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinScript : MonoBehaviour
{
    public Vector3 startPos;
    public Quaternion startRot;
    public Rigidbody rig;
    public bool KnockedOver;




    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        rig.isKinematic = true;
        startPos = transform.position;
        startRot = transform.rotation;
        rig.isKinematic = false;
        KnockedOver = false;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void resetPin()
    {
        rig.isKinematic = true;
        transform.position = startPos;
        transform.rotation = startRot;
        rig.isKinematic = false;
        KnockedOver = false;
    }


    public void checkPin()
    {
        KnockedOver = true;
    }
}
