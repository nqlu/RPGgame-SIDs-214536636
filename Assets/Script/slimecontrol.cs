    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimecontrol : MonoBehaviour {
    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    private bool moving;
    public float timeBetweenMove;
    private float timeBetweenCounter;
    public float timetoMove;
    private float timeToMoveCounter;
    private Vector3 moveDirection;
    public float waitToRelad;
    private bool reloading;
    private GameObject thePlayer;
	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        //timeBetweenCounter = timeBetweenMove;
        // timeToMoveCounter = timetoMove;
        timeBetweenCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timetoMove * 0.75f, timeBetweenMove * 1.25f);
		
	}
	
	// Update is called once per frame
	void Update () {
        if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = moveDirection;
            if(timeToMoveCounter< 0f)
            {
                moving = false;
                // timeBetweenCounter = timeBetweenMove;
                timeBetweenCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
            }
        }
        else
        {
            timeBetweenCounter -= Time.deltaTime;
            myRigidbody.velocity = Vector2.zero;
            if(timeBetweenCounter < 0f )
            {
                moving = true;
                //   timeToMoveCounter = timetoMove;
                timeToMoveCounter = Random.Range(timetoMove * 0.75f, timeBetweenMove * 1.25f);
                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
            }
        }
		if (reloading)
        {
            waitToRelad -= Time.deltaTime;
            if(waitToRelad < 0)
            {
                Application.LoadLevel(Application.loadedLevel);
                thePlayer.SetActive(true);
            }
        }
	}
    void OnCollisionEnter2D(Collision2D other)
    {
       /* if(other.gameObject.name == "Player")
        {
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            reloading = true;
            thePlayer = other.gameObject;
            
        }*/
    }
}
