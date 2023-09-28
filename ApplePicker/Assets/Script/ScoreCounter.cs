using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [HideInInspector] public int score = 0;
    private Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();   
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString("#,0");
    }
}
