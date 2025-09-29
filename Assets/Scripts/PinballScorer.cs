using UnityEngine;

public class PinballScorer : MonoBehaviour
{
    [SerializeField]
    public bool canScore = true;
    [SerializeField]
    public int scoreValue;
    float scoreCooldown = 0.5f;
    float scoreTimer = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (!canScore)
        {
            scoreTimer += Time.deltaTime;
            if (scoreTimer >= scoreCooldown)
            {
                canScore = true;
                scoreTimer = 0.0f;
            }
        }
    }
}
