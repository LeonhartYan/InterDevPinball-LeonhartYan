using UnityEngine;

public class PinballDirection : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("RotateDir", 2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void RotateDir()
    {
        transform.Rotate(0, 0, 90);
    }
    
}
