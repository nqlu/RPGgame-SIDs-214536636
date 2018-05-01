using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour {
    public string dialogue;
    private DialogueManager dMAn;
    public string[] dialogueLines;
	// Use this for initialization
	void Start () {
        dMAn = FindObjectOfType<DialogueManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            if(Input.GetKeyUp(KeyCode.Mouse0))
            {
                //dMAn.ShowBox(dialogue);
                if(!dMAn.dialogActive)
                {
                    dMAn.diaglogLines = dialogueLines;
                    dMAn.currentLine = 0;
                    dMAn.showDialogue();
                }
                if(transform.parent.GetComponent<Villagemovement>() != null)
                {
                    transform.parent.GetComponent<Villagemovement>().canMove = false;
                }
            }
        }
    }
}
