using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{


    public int damageToGive;
    private int currentDamage;
    public GameObject damageBurst;
    public Transform HitPoint;
    public GameObject damageNumber;
    private PlayerStat thePS;
    // Use this for initialization
    void Start()

    {
        thePS = FindObjectOfType<PlayerStat>();
    }

    // Update is called once per frame
    void Update()
    {


    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            currentDamage = damageToGive + thePS.currentAttack;
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(currentDamage);
            Instantiate(damageBurst, HitPoint.position, HitPoint.rotation);
            var clone = (GameObject)Instantiate(damageNumber, HitPoint.position, Quaternion.Euler(Vector3.zero));

            clone.GetComponent<FloatNumber>().damageNumber = currentDamage;

        }
    }
}
