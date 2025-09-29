using System.Threading;
using UnityEngine;

public class PinballPortal : MonoBehaviour
{
    [SerializeField]
    public bool canScore = true;
    public int scoreValue;
    float scoreCooldown = 0.5f;
    float scoreTimer = 0.0f;

    [SerializeField]
    public Transform targetPortal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (canScore)
        {
            canScore = false;
            scoreTimer += Time.deltaTime;
            if (scoreTimer >= scoreCooldown)
            {
                canScore = true;
                scoreTimer = 0.0f;
            }
        }
    }
}
