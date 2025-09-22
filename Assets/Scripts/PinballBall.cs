using UnityEngine;

public class PinballBall : MonoBehaviour
{
    //serialize field gives lets me set the variable in the inspector
    //without having to make that variable public
    [SerializeField]
    Rigidbody2D myBody; //var ref to this game object's rigidbody

    AudioSource myAudioSource;

    [SerializeField]
    AudioClip bumperClip, wallClip, flipperClip;

    Vector2 lastVel;

    [SerializeField]
    PinballManager myManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //myBody = GetComponent<Rigidbody2D>();
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    //calls when a collision first occurs
    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "bumper":
                myAudioSource.PlayOneShot(bumperClip);
                break;
            case "wall":
                myAudioSource.PlayOneShot(wallClip);
                break;
            case "flipper":
                myAudioSource.PlayOneShot(flipperClip);
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("direction"))
        {
            // Vector2.dirVec = new Vector2(collision.gameObject.transform.up.x, collision.gameObject.transform.up.y)
            //change data type
            myManager.AddScore();
            myBody.linearVelocity += (Vector2)collision.gameObject.transform.up;

        }       
    }

}
