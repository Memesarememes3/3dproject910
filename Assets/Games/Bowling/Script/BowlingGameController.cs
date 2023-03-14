using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BowlingGameController : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;
    public pinScript[] pins;


    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void scorePins()
    {
        foreach(pinScript pin in pins)
        {
            Debug.Log(pin);
            if(pin.KnockedOver == true)
            {
                score++;
            }
            pin.resetPin();
        }
        scoreText.text = "score: " + score.ToString();
    }
}
