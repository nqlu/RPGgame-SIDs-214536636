﻿using System.Collections;

using UnityEngine;
using System.Collections.Generic;

public class QuestMangers : MonoBehaviour {
    public QuestObject[] quests;
    public bool[] questCompleted;
    public DialogueManager theDM;
    public string itemCollected;
    
    public string enemyKilled;
	// Use this for initialization
	void Start () {
        questCompleted = new bool[quests.Length];
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ShowQuestText(string questText)
    {
        theDM.diaglogLines = new string[1];
        theDM.diaglogLines[0] = questText;
        theDM.currentLine = 0;
        theDM.showDialogue(); ;
    }
}
