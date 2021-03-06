﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{

    public int MaxHealth;
    public int CurrentHealth;
    private PlayerStat thePlayerStats;
    public int expToGive;
    public string enemyQuestName;
    private QuestMangers theQM;
    // Use this for initialization
    void Start()
    {
        CurrentHealth = MaxHealth;
        thePlayerStats = FindObjectOfType<PlayerStat>();
        theQM = FindObjectOfType<QuestMangers>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (CurrentHealth <= 0)
        {
            theQM.enemyKilled = enemyQuestName;
            Destroy(gameObject); // enemy will be kill
            thePlayerStats.AddExperience(expToGive); // Add experince to chracter when enemy be killed

        }

    }
    public void HurtEnemy(int damagetoGive)
    {
        CurrentHealth -= damagetoGive;
    }
    public void SetMaxhealth()
    {
        CurrentHealth = MaxHealth;
    }
}

