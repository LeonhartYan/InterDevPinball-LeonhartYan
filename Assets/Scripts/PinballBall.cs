using Unity.VisualScripting;
using UnityEngine;

public class PinballBall : MonoBehaviour
{
    //serialize field gives lets me set the variable in the inspector
    //without having to make that variable public
    [SerializeField]
    Rigidbody2D myBody; //var ref to this game object's rigidbody

    AudioSource myAudioSource;

    [SerializeField]
    AudioClip bumperClip, wallClip, flipperClip, deadClip;

    Vector2 lastVel;

    [SerializeField]
    PinballManager myManager;

    [SerializeField]
    Camera myCamera;

    public bool onFlipper = false;
    float flipperTimer = 0.0f;
    float flipperCooldown = 0.2f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //myBody = GetComponent<Rigidbody2D>();
        myAudioSource = GetComponent<AudioSource>();
        myManager = GameObject.Find("Game Manager").GetComponent<PinballManager>();
        myCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (onFlipper)
        {
            flipperTimer += Time.deltaTime;
            if (flipperTimer >= flipperCooldown)
            {
                onFlipper = false;
                flipperTimer = 0.0f;
            }
        }
    }

    //calls when a collision first occurs
    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "bumper":
                if (collision.gameObject.GetComponent<PinballBumper>().canScore)
                    myManager.AddScore(collision.gameObject.GetComponent<PinballBumper>().scoreValue);
                myAudioSource.PlayOneShot(bumperClip);
                if (myCamera.GetComponent<PinballCamera>().isShaking == false)
                    myCamera.GetComponent<PinballCamera>().isShaking = true;
                break;
            case "wall":
                myAudioSource.PlayOneShot(wallClip);
                break;
            case "flipper":
                myAudioSource.PlayOneShot(flipperClip);
                myBody.linearVelocity += (Vector2)collision.gameObject.transform.up;
                break;
            case "rotator":
                if (collision.gameObject.GetComponent<PinballRotator>().canScore)
                    myManager.AddScore(collision.gameObject.GetComponent<PinballRotator>().scoreValue);
                myBody.AddForce(collision.gameObject.transform.up * 10.0f);
                myAudioSource.PlayOneShot(bumperClip);
                if (myCamera.GetComponent<PinballCamera>().isShaking == false)
                    myCamera.GetComponent<PinballCamera>().isShaking = true;
                break;
            case "restart":
                myAudioSource.PlayOneShot(deadClip);
                Destroy(gameObject);
                myManager.SpawnBall();
                if (myCamera.GetComponent<PinballCamera>().isShaking == false)
                    myCamera.GetComponent<PinballCamera>().isShaking = true;
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("direction"))
        {
            if (collision.gameObject.GetComponent<PinballScorer>().canScore)
                myManager.AddScore(collision.gameObject.GetComponent<PinballScorer>().scoreValue);
            myBody.linearVelocity += (Vector2)collision.gameObject.transform.up;

        }

        if (collision.CompareTag("portal"))
        {
            if (collision.gameObject.GetComponent<PinballPortal>().canScore)
                myManager.AddScore(collision.gameObject.GetComponent<PinballPortal>().scoreValue);
            if (!myManager.teleporting)
            {
                myManager.teleporting = true;
                myManager.GetComponent<AudioSource>().PlayOneShot(myManager.teleportClip);
                transform.position = collision.gameObject.GetComponent<PinballPortal>().targetPortal.position;
            }
        }       
    }

}
