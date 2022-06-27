using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int damage;
    public int health;
    public float flashTime;
    public GameObject bloodEffect;
    public GameObject dropCoin;
    public GameObject floatPoint;
    
    private SpriteRenderer sr;
    private Color originalColor;
    private PlayerHealth playerHealth;
    public void Start()
    {
       playerHealth=GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
       sr=GetComponent<SpriteRenderer>();
       originalColor=sr.color; 
    }

    
    public void Update()
    {
       if(health<=0)
       {
           Instantiate(dropCoin,transform.position,Quaternion.identity);
           Destroy(gameObject);
       } 
    }

    public void TakeDamage(int Getdamage)
    {
        GameObject gb=Instantiate(floatPoint,transform.position,Quaternion.identity) as GameObject;
        gb.transform.GetChild(0).GetComponent<TextMesh>().text=damage.ToString();
        health-=Getdamage;
        FlashColor(flashTime);
        Instantiate(bloodEffect,transform.position,Quaternion.identity);
        GameController.camShake.Shake();
    }
      void FlashColor(float time)
    {
        sr.color=Color.red;
        Invoke("ResetColor",time);
    }
    
    void ResetColor()
    {
        sr.color=originalColor;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")&&other.GetType().ToString()=="UnityEngine.CapsuleCollider2D")
        {
            if(playerHealth!=null)
            {
              playerHealth.DamagePlayer(damage);
            }
        }
    }
}
