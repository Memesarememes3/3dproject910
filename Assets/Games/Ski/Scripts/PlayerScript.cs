using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private float xInput;
    public float xForce;
    public float zForce;
    private Rigidbody rig;


    private float yInput;
    public float yForce;
    public bool grounded;


    public Vector3 startPos;
    public Quaternion startRot;
    public Vector3 startVel;

    public int health;


    public MeshRenderer mr;
    public Color green;
    public Color yellow;
    public Color red;


    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
        mr = GetComponent<MeshRenderer>();
        grounded = true;
        startPos = transform.position;
        startRot = transform.rotation;
        startVel = Vector3.zero;
        health = 3;
        mr.material.color = green;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        rig.AddForce(Vector3.right*xInput*xForce);





        yInput = Input.GetAxis("Jump");
        if (grounded && yInput>0)
        {
            rig.AddForce(Vector3.up * yInput * yForce, ForceMode.Impulse);
            grounded = false;
        }

    }

    public void resetPlayer()
    {
        rig.isKinematic = true;
        grounded = true;
        transform.position = startPos;
        transform.rotation = startRot;
        rig.velocity = startVel;
        rig.isKinematic = false;
        health = 3;
        mr.material.color = green;
        rig.isKinematic = false;
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            grounded = true;
        }

        if (collision.gameObject.CompareTag("badStuff"))
        {
            damagePlayer();
        }

        if (collision.gameObject.CompareTag("ramp"))
        {
            rig.AddForce(Vector3.forward * zForce, ForceMode.Impulse);
        }
    }


    public void damagePlayer()
    {
        //bounce off object
        rig.AddForce(Vector3.forward * -10, ForceMode.Impulse);
        //take away health
        health--;
        //change player color to match health
        if(health == 2)
        {
            //set color to yellow
            mr.material.color = yellow;
        }
        else if(health < 2)
        {
            //set color to red
            mr.material.color = red;
        }

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
