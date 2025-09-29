using UnityEngine;

public class PinballState : MonoBehaviour
{
    [SerializeField]
    GameObject gateObj;
    [SerializeField]
    public bool isActive = false;

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ball"))
        {
            isActive = true;
        }

    }

    void Update()
    {
        if (isActive)
        {
            gateObj.SetActive(true);
        }
        else
        {
            gateObj.SetActive(false);
        }
    }
}
