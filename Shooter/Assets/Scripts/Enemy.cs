using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor.U2D;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    private float stopTime;
    public float StartStopTime;
    public float normalSpeed;

    public int hp;
    public float speed;
    public Player1 player;

    public int damage;
    public GameObject[] drop;

    void Start()
    {
        player = FindObjectOfType<Player1>() ;
    
    }

    // Update is called once per frame
    void Update()
    {
        if(stopTime <= 0)
        {
            speed = normalSpeed;
        }
        else
        {
            speed = 0;
            stopTime -= Time.deltaTime;
        }
        if(hp <= 0) 
        {
            System.Random rng = new System.Random(DateTime.Now.Millisecond);
            
            Instantiate(drop[rng.Next(2)], gameObject.transform.position, transform.rotation);
            Destroy(gameObject);
        }
        }
    private void LateUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

    }
    public void TakeDamage(int damage)
    {
        stopTime = StartStopTime;
        hp -= damage;
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(timeBtwAttack <= 0)
            {
                OnEnemyAttack();
            }
            else
            {
                timeBtwAttack -= Time.deltaTime; 
            }
        }else if (other.CompareTag("Enemy"))
        {

        }
    }
    public void OnEnemyAttack()
    {
        player.ChangeHealth(-damage);
        timeBtwAttack = startTimeBtwAttack;
    }
}
