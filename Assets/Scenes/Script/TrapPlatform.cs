using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlatform : MonoBehaviour
{
    private Animator anim;
    private BoxCollider2D   bx2d; 
        void Start()
    {
        anim=GetComponent<Animator>();
        bx2d=GetComponent<BoxCollider2D>();
    }

       void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.CompareTag("Player")&&other.GetType().ToString()=="UnityEngine.BoxCollider2D") 
       {
          // Debug.Log("踩到了");
           anim.SetTrigger("Collapse");
       }  
    }
    void DisableBoxCollider2D()
    {
        bx2d.enabled=false;
    }
    void DestroyTrapPlatform()
    {
        Destroy(gameObject);
    }
}
