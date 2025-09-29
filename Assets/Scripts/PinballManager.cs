using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
public class PinballManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text scoreText; //refence to text component that shows the score
    //in order to access text mesh pro components, you must include "using TMPro" up at the top

    [SerializeField]
    int score; //var to track score

    [SerializeField] GameObject ballPrefab;
    [SerializeField] Transform respawnPoint;
    Vector3 ballStartPos;
    GameObject currentBall;

    [SerializeField]
    public AudioClip deadClip, BGMClip, teleportClip;
    AudioSource myAudioSource;  

    public bool teleporting = false;
    float teleTimer = 0.0f; 
    float teleCooldown = 15.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set the score text to the score
        //b/c score is an int, it must be translated to a string
        //you can add strings together
        myAudioSource = GetComponent<AudioSource>();
        ballStartPos = ballPrefab.transform.position;
        PlayerPrefs.SetInt("Score", 0);
        score = PlayerPrefs.GetInt("Score");
        scoreText.text = "Score: " + score.ToString();
        myAudioSource.Play();
        SpawnBall();
    }

    // Update is called once per frame
    void Update()
    {
        if (teleporting)
        {
            teleTimer += Time.deltaTime;
            if (teleTimer >= teleCooldown)
            {
                teleporting = false;
                teleTimer = 0.0f;
            }
        }
    }

    //since we want to centralize macro game systems, i would probaly want to actually change
    //the score in the game manager
    public void AddScore(int scoreAdd)
    {
        //add to score
        //do score effects maybe
        score += scoreAdd;
        scoreText.text = "Score: " + score.ToString();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ball"))
        {
            PlayerPrefs.SetInt("Score", score);
            if (collision.gameObject == currentBall)
            {
                Destroy(currentBall);
                GameObject.Find("Launched Trigger").GetComponent<PinballState>().isActive = false;
                myAudioSource.PlayOneShot(deadClip);
                SpawnBall();
            }
                    
            // ballObj.transform.position = ballStartPos;

        }
    }
    public void SpawnBall()
    {
        var cam = GameObject.Find("Main Camera");
        currentBall = Instantiate(ballPrefab, respawnPoint.position, respawnPoint.rotation);
        cam.GetComponent<PinballCamera>().ballTransform = currentBall.transform;
    }
}

