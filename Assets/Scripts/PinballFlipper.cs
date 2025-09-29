using System;
using Unity.VisualScripting;
using UnityEngine;

public class PinballFlipper : MonoBehaviour
{

    [SerializeField]
    KeyCode flipKey; //ref to key that'll trigger the flipper

    [SerializeField]
    Rigidbody2D myBody; //ref to the flipper's body

    [SerializeField]
    float flipPower; //how hard we want the flipper to push

    [SerializeField]
    Transform anchor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    float isMoving;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if the flip key is pressed
        if (Input.GetKeyDown(flipKey))
        {
            //add force to the flipper in the upwards direction
            myBody.AddForce(transform.up * flipPower);
            isMoving = 1;
        }
        else if (Input.GetKeyUp(flipKey))
        {
            isMoving = 0;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ball") && collision.collider.GetComponent<PinballBall>().onFlipper == false)
        {
            collision.collider.GetComponent<PinballBall>().onFlipper = true;
            var contact = collision.collider.ClosestPoint(anchor.position);
            float distance = Vector2.Distance(contact, anchor.position);
            float distRatio = Mathf.Clamp01(distance / 2.0f);
            collision.collider.GetComponent<Rigidbody2D>().AddForce(transform.up * flipPower/1.25f * distRatio * isMoving);

        }
    }
}

