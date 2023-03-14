using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonScript : MonoBehaviour
{
    public float amountToAdd;
    public int value;

    public AudioSource audio;
    public GameController controller;
    public bool pop = false;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        controller = FindObjectOfType<GameController>();
    }

    private void OnMouseDown()
    {
        transform.localScale += new Vector3(amountToAdd, amountToAdd, amountToAdd);
        if(transform.localScale.x >= 3.0f && !pop)
        {
            pop = true;
            controller.updateScore(value);
            audio.Play();
            Destroy(gameObject,.1f);
        }
    }

}

 