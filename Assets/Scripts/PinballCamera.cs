using UnityEngine;

public class PinballCamera : MonoBehaviour
{
    [SerializeField]
    public Transform ballTransform;

    [SerializeField]
    float smoothVal;
    Vector3 velocity = Vector3.zero;

    Vector3 startPos;

    public bool isShaking = false;
    float shakeTimer = 0.0f;
    float shakeDuration = 0.75f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // transform.rotation = Quaternion.identity;
        Vector3 target = ballTransform.position;
        // target.x = startPos.x;
        target.z = -10;
        if (isShaking)
        {
            target.x += Random.Range(-15f, 15f);
            target.y += Random.Range(-15f, 15f);
            shakeTimer += Time.deltaTime;
            if (shakeTimer >= shakeDuration)
            {
                isShaking = false;
                shakeTimer = 0.0f;
            }
        }
        Vector3 pos = Vector3.SmoothDamp(transform.position, target, ref velocity, smoothVal);
        transform.position = pos;
    }
}
