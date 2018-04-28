using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {
    public float moveSpeed; // set up Speed of the character which can change the speed of character in Inspector > Move Speed
                            // Use this for initialization
    private Animator anim;
    private bool PlayMoving;
    private Vector2 lastMove;
    private Rigidbody2D myRigibody;
    void Start() {
        anim = GetComponent<Animator>();
        myRigibody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
   
    void Update() {
        Playmoving = false;
       
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate (new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            
            Playmoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }
        //this one for moving the character in vertical
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
             transform.Translate(new Vector3(0f,Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
           
            Playmoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayMoving", Playmoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y); 
    }
}
