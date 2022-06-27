using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed;
    public int damage;
    public float destroyDistance;
    private Rigidbody2D  rb2d;
    private Vector3 startPos;
    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();
        rb2d.velocity=transform.right*speed;
        startPos=transform.position;
    }

   
    void Update()
    {
        float distance=(transform.position-startPos).sqrMagnitude;
        if(distance>destroyDistance)
        {
            Destroy(gameObject);
        }
    }
     void OnTriggerEnter2D(Collider2D other)
    {
      if(other.gameObject.CompareTag("Enemy"))
      {
          other.GetComponent<Enemy>().TakeDamage(damage);
      }   
    }
}
