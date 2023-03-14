using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCollider : MonoBehaviour
{
    public pinScript pin;


    // Start is called before the first frame update
    void Start()
    {
        pin = GetComponentInParent<pinScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("test");
        if(other.CompareTag("Pin"))
        {
            return;
        }

        pin.checkPin();
    }
}
