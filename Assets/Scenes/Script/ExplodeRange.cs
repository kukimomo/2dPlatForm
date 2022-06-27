using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeRange : MonoBehaviour
{
    public int damage;
    public float destroyTime;

    private PlayerHealth playerHealth;
    void Start()
    {
        playerHealth=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        Destroy(gameObject,destroyTime);
    }

        void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.CompareTag("Enemy"))
       {
           other.GetComponent<Enemy>().TakeDamage(damage);
       }    
       if(other.gameObject.CompareTag("Player")&&other.GetType().ToString()=="UnityEngine.CapsuleCollider2D")
       {
           if(playerHealth!=null)
           {
               playerHealth.DamagePlayer(damage);
           }
       }
    }
}
