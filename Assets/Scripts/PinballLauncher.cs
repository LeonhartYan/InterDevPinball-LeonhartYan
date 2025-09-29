using UnityEngine;

public class PinballLauncher : MonoBehaviour
{

    SpringJoint2D mySpring;
    Rigidbody2D myBody;

    [SerializeField]
    float minDist;

    [SerializeField]
    float launchPower;

    [SerializeField]
    PinballBall ballScript;

    [SerializeField]
    AudioClip launchClip, chargeClip;
    AudioSource myAudioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        mySpring = GetComponent<SpringJoint2D>();
        myBody = GetComponent<Rigidbody2D>();
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (mySpring.distance > minDist)
            {
                mySpring.distance -= 0.01f;
                if (!myAudioSource.isPlaying)
                    myAudioSource.PlayOneShot(chargeClip);
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            myBody.AddForce(transform.up * launchPower);
            myAudioSource.PlayOneShot(launchClip);
            mySpring.distance = 2.5f;
        }
    }
}
