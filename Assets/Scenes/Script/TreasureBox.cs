using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBox : MonoBehaviour
{
    public  GameObject coin;
    public float delaytime;
    private bool canOpen;
    private bool isOpened;
    private Animator anim;
    void Start()
    {
        anim=GetComponent<Animator>();
        isOpened=false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {       
             
            if(canOpen&&!isOpened)
            {
                anim.SetTrigger("Opening");
                isOpened=true;
                Invoke("GetCoin",delaytime);
            }
        }
    }
    void GetCoin()
      {
         Instantiate(coin,transform.position,Quaternion.identity); 
      }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player")&&other.GetType().ToString()=="UnityEngine.CapsuleCollider2D")
        {
         canOpen=true;   
         Debug.Log("碰到,按Y打开宝箱");        
        }    
    }

      void OnTriggerExit2D(Collider2D other) 
    {
          if(other.gameObject.CompareTag("Player")&&other.GetType().ToString()=="UnityEngine.CapsuleCollider2D")
        {
         canOpen=false;     
        // Debug.Log("离开");    
        }    
    }
}


