using UnityEngine;

public class PinballCamera : MonoBehaviour
{
    [SerializeField]
    Transform ballTransform;

    [SerializeField]
    float smoothVal;
    Vector3 velocity = Vector3.zero;

    Vector3 startPos;


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
        transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, smoothVal);
    }
}
