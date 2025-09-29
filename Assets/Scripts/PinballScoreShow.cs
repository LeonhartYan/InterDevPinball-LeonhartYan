using UnityEngine;
using TMPro;
public class PinballScoreShow : MonoBehaviour
{
    public int score;
    [SerializeField]
    TMP_Text scoreText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = PlayerPrefs.GetInt("Score");
        scoreText.text = "Your Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
