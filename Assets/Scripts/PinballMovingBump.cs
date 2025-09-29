using UnityEngine;

public class PinballMovingBump : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 2.0f;

    [SerializeField]
    public string axis = "v";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {

        if (axis == "h")
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            if (transform.position.x > 4.5f || transform.position.x < -4.5f)
                moveSpeed = -moveSpeed;
        }
        else if (axis == "v")
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
            if (transform.position.y > 4.5f || transform.position.y < -4.5f)
                moveSpeed = -moveSpeed;
        }
    }
}
