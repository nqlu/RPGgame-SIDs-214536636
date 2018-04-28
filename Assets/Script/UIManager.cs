using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public Slider healthBar;
    public Text HPText;
    public PlayerHealthsystem playerHealth;
    private PlayerStat thePS;
    public Text levelText;
    private static bool UIExist;
	// Use this for initialization
	void Start () {
        if (!UIExist)
        {
            UIExist = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        thePS = GetComponent<PlayerStat>(); 
    

}
	
	// Update is called once per frame
	void Update () {
        // Health bar UI
        healthBar.maxValue = playerHealth.playerMaxHealth;
        healthBar.value = playerHealth.playerCurrentHealth;
        HPText.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;
        // Level UI 
        levelText.text = "Lvl: " + thePS.currentLevel;
	}
}
