using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sickle : MonoBehaviour
{
    public float speed;
    public int damage;
    public float rotateSpeed;
    public float tunning;
    
    private Rigidbody2D rb2d;
    private Transform playerTransform;
    private Transform sickleTransform;

    private Vector2 startSpeed;
    private CameraShake camShake;
    void Start()
    {
        rb2d=GetComponent<Rigidbody2D>();
        rb2d.velocity=transform.right*speed;
        startSpeed=rb2d.velocity;
        playerTransform=GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sickleTransform=GetComponent<Transform>();
        camShake=GameObject.FindGameObjectWithTag("CameraShake").GetComponent<CameraShake>();
            
    }

    
    void Update()
    {
        transform.Rotate(0,0,rotateSpeed);
        float y=Mathf.Lerp(transform.position.y,playerTransform.position.y,tunning);
        transform.position=new Vector3(transform.position.x,y,0.0f);
        rb2d.velocity=rb2d.velocity-startSpeed*Time.deltaTime;
        if(Mathf.Abs(transform.position.x-playerTransform.position.x)<0.5f)
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
