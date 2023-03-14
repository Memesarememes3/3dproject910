using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{

    public Rigidbody rig;
    public float power;
    public float moveStep;
    public float rightBound;
    public float leftBound;
    public bool canMove;
    public Vector3 startPos;
    public BowlingGameController controller;



    private void Awake()
    {
        startPos = transform.position;
        canMove = true;
        rightBound = -0.5f;
        leftBound = 0.5f;
        rig = GetComponent<Rigidbody>();
        controller = FindObjectOfType<BowlingGameController>();
    }


    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
/*        if((transform.position.y < 0)|| (transform.position.x > rightBound + 1) || (transform.position.x < leftBound - 1))
        {
            ballReset();
        }
        if(rig.velocity.magnitude < .05 && canMove == false)
        {
            ballReset();
        }*/
        /*if(transform.position.x > rightBound + 1)
        {
            ballReset();
        }
        if(transform.position.x < leftBound - 1)
        {
            ballReset();
        }*/
    }
        

    public void bowl()
    {
        canMove = false;
        rig.AddForce(Vector3.back*power, ForceMode.Impulse);
    }

    public void moveLeft()
    {
        if(transform.position.x < leftBound && canMove)
        { 
           transform.position = new Vector3(transform.position.x + moveStep, transform.position.y, transform.position.z); 
           if(transform.position.x > leftBound)
           {
                transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
           }
        }
    }

    public void moveRight()
    {
        if (transform.position.x > rightBound && canMove)
        {
            transform.position = new Vector3(transform.position.x - moveStep, transform.position.y, transform.position.z);
            if (transform.position.x < rightBound)
            {
                transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
            }
        }
    }


    public void ballReset()
    {
        canMove = true;
        rig.velocity = Vector3.zero;
        transform.position = startPos;
        controller.scorePins();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pin"))
        {
            return;
        }
        if (other.CompareTag("TopOfPin"))
        {
            return;
        }
        ballReset();
    }
}
