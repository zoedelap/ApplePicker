using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    private static TextMeshProUGUI _UI_TEXT;
    static private int _SCORE = 1000;

    private void Awake()
    {
        _UI_TEXT = GetComponent<TextMeshProUGUI>();    

        if (PlayerPrefs.HasKey("HighScore"))
        {
            SCORE = PlayerPrefs.GetInt("HighScore");
        }
        PlayerPrefs.SetInt("HighScore", SCORE);
    }

    static public int SCORE
    {
        get { return _SCORE; }
        private set { 
            _SCORE = value;
            PlayerPrefs.SetInt("HighScore", value);
            if (_UI_TEXT != null)
            {
                _UI_TEXT.SetText("High Score: " + value.ToString("#,0"));
            }
            
        }
    }

    static public void TRY_SET_HIGH_SCORE(int scoreToTry) 
    {
        if (scoreToTry <= SCORE) return;

        SCORE = scoreToTry;
    }

    [Tooltip("Check this box to reset the HighScore in PlayerPrefs")]
    public bool resetHighScoreNow = false;

    private void OnDrawGizmos()
    {
        if (resetHighScoreNow)
        {
            resetHighScoreNow = false;
            PlayerPrefs.SetInt("HighScore", 1000);
            Debug.LogWarning("PlayerPrefs HighScore reset to 1,000");
        }
    }
}
