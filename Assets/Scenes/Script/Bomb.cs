using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosionRange;
    public Vector2 startSpeed;
    public float delayExplodeTime;
    public float destroyBombTime;
    public float hitboxTime;
    private Rigidbody2D rb2d;
    private Animator anim;

    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        rb2d.velocity=transform.right*startSpeed.x+transform.up*startSpeed.y;
        Invoke("Explode",delayExplodeTime);
    }

    
    void Update()
    {
        
    }
    void Explode()
    {
        anim.SetTrigger("Explode");
        Invoke("GenExplosionRange",hitboxTime);
        Invoke("DestroyThisBomb",destroyBombTime);
    }
    void GenExplosionRange()
    {
         Instantiate(explosionRange,transform.position,Quaternion.identity);
    }
    void DestroyThisBomb()
    {
        Destroy(gameObject);
    }
}
