using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour {
    public GameObject dBox;
    public Text dText;
    public bool dialogActive;
    public string[] diaglogLines;
    public int currentLine;
    private PlayerController thePlayer;
	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();
    
	}
	
	// Update is called once per frame
	void Update () {
		if(dialogActive && Input.GetKeyDown(KeyCode.Mouse0))
        {
            // dBox.SetActive(false);
            // dialogActive = false;
            currentLine++;
        }
        if(currentLine >= diaglogLines.Length)
        {
            dBox.SetActive(false);
             dialogActive = false;
            currentLine = 0;
            thePlayer.canMove = true;
        }
        dText.text = diaglogLines[currentLine];
    }
    public void ShowBox(string dialogue)
    {
        dialogActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }
    public void showDialogue()

    {
        dialogActive = true;
        dBox.SetActive(true);
        thePlayer.canMove = false;

    }
}
