using UnityEngine;

public class PinballRotator : MonoBehaviour
{
    [SerializeField]
    float rotateSpeed;
    [SerializeField]
    Rigidbody2D myBody;
    [SerializeField]
    public int scoreValue;
    float accelerate = 5.0f;
    public bool canScore = true;
    float scoreCooldown = 2.5f;
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
    
    void FixedUpdate()
    {
       myBody.angularVelocity = rotateSpeed;
       if(rotateSpeed < 100.0f)
       rotateSpeed += accelerate;
    }
}
