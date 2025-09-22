using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    //min and max I want the player to move
    public float minSpeed;
    public float maxSpeed;
    //how quickly I want the player to pick up speed
    public float acceleration;
    //the current speed of my player
    float speed;

    //bools to check if the player is able to move in a particular direction
    bool goLeft = true;
    bool goRight = true;
    bool goTop = true;
    bool goBottom = true;

    //variable for the audio source component attached to whatever gameobject
    //this script is on
    AudioSource myCDPlayer;
    //AudioSource mySource;

    //file I want to play when I touch a flower
    public AudioClip dingCD;
    //public AudioClip dingClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set the player's speed to the lowest possible value
        speed = minSpeed;
        //set the variable to the audio source component attached to the gameobject this script is on
        myCDPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //the game object's current position
        Vector3 currentPos = transform.position;

        //if W, A, S, or D is pressed and it's possible to go in that direction
        //add speed times the current delta time to our position
        if (Input.GetKey(KeyCode.W) && goTop)
        {
            currentPos.y += speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) && goBottom)
        {
            currentPos.y -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) && goLeft)
        {
            currentPos.x -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) && goRight)
        {
            currentPos.x += speed * Time.deltaTime;
        }
        //if our next position is not our current position
        if (transform.position != currentPos)
        {
            //and if the player hasn't gone over the max speed
            if (speed < maxSpeed)
            {
                //accelerate
                speed += acceleration;
            }
        }
        //otherwise
        else
        {
            //reset our speed
            speed = minSpeed;
        }
        //set our position to the new position
        transform.position = currentPos;
    }

    //calls when this game object overlaps with a collider set as a trigger
    void OnTriggerEnter2D(Collider2D collision)
    {
        //if the tag of the thing we hit matches one of the below
        //change the related boolean to false
        if (collision.CompareTag("left"))
        {
            goLeft = false;
            Debug.Log("hit left border");
        }
        if (collision.CompareTag("right"))
        {
            goRight = false;
        }
        if (collision.CompareTag("top"))
        {
            goTop = false;
        }
        if (collision.CompareTag("bottom"))
        {
            goBottom = false;
        }

        //if we touch a game object tagged flower
        if (collision.CompareTag("flower"))
        {
            //LONGER EXPLANATION:
            //collision is a variable that returns when we hit a collider in the OnTriggerXX functions
            //collision holds information about the collision event
            //since I need to interface with the object I collided with, I have to get a reference to the game object
            //I do that with .gameObject
            //then GetComponent allows me to "get" a component on that object
            //I can reference didDing (which came from the BloomFlower script) because didDing is set to public

            //and if that flower has not yet played a ding sound
            if (collision.gameObject.GetComponent<BloomFlower>().didDing == false)
            {
                //play the ding sound
                myCDPlayer.PlayOneShot(dingCD);
                //trigger the flower's blooming animation
                collision.gameObject.GetComponent<Animator>().SetBool("doBloom", true);
                //set the flower's ding boolean to true
                collision.gameObject.GetComponent<BloomFlower>().didDing = true;
            }
        }
    }

    //calls when the game object exits (leaves) a collider set as a trigger
    void OnTriggerExit2D(Collider2D collision)
    {
        //if the object we touched is tagged as one of the following
        //set the related boolean to true
        if (collision.CompareTag("left"))
        {
            goLeft = true;
        }
        if (collision.CompareTag("right"))
        {
            goRight = true;
        }
        if (collision.CompareTag("top"))
        {
            goTop = true;
        }
        if (collision.CompareTag("bottom"))
        {
            goBottom = true;
        }
    }

}
