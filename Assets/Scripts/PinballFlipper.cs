using UnityEngine;

public class PinballFlipper : MonoBehaviour
{

    [SerializeField]
    KeyCode flipKey; //ref to key that'll trigger the flipper

    [SerializeField]
    Rigidbody2D myBody; //ref to the flipper's body

    [SerializeField]
    float flipPower; //how hard we want the flipper to push

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
        }
    }
}
