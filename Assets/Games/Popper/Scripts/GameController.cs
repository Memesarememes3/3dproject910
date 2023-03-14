using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{

    [SerializeField] private int score;

    public TextMeshProUGUI scoreText;
    AudioSource audio;
    public GameObject[] prefbs;
    public int[] range;

    private void Awake()
    {
        score = 0;
        scoreText = GameObject.FindWithTag("Score Text").GetComponent<TextMeshProUGUI>();
        audio = GetComponent<AudioSource>();
    }


    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score:" + score.ToString();
     /*   int i = 0;
        while (i < 1000)
        {
            spawnBalloon();
            i++;
        }*/

        /*for(int i = 0; i<100; i++)
        {
            spawnBalloon();
        }*/

        foreach(int i in range)
        {
            spawnBalloon();
        }


    }

    public void updateScore(int value)
    {
        score += value;
        scoreText.text = "Score:" + score.ToString();
        spawnBalloon();
    }

    public void spawnBalloon()
    {
        int num = Random.Range(0, 3);
        int x = Random.Range(-13, 15);
        int y = Random.Range(3, 11);
        int z = Random.Range(37, 37);

        Instantiate(prefbs[num], new Vector3(x, y, z), Quaternion.identity);
    }
}
