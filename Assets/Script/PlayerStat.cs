using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
    public int currentLevel;
    public int currentExp;
    public int[] toLevelUp;

    public int[] HPLevels;
    public int[] attackLevels;
    public int[] defenceLevels;
    public int currentHp;
    public int currentAttack;
    public int currentDefence;
    private PlayerHealthsystem thePlayerhealth;
    // Use this for initialization
    void Start()
    {
        currentHp = HPLevels[1];
        currentAttack = attackLevels[1];
        currentDefence = defenceLevels[1];
        thePlayerhealth = FindObjectOfType<PlayerHealthsystem>();

    }

    // Update is called once per frame
    void Update()
    {

        if (currentExp >= toLevelUp[currentLevel])
        {
            LevelUps();
            //currentLevel++;
        }
    }
    public void AddExperience(int experiencetoAdd)
    {
        currentExp += experiencetoAdd;
    }
    public void LevelUps()
    {
        currentLevel++;
        currentHp = HPLevels[currentLevel];
        thePlayerhealth.playerMaxHealth = currentHp;
        thePlayerhealth.playerCurrentHealth += currentHp - HPLevels[currentLevel - 1];
        currentAttack = attackLevels[currentLevel];
        currentDefence = defenceLevels[currentLevel];
    }
}
