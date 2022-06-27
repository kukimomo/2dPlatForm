using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEnter : MonoBehaviour
{
   public Transform backDoor;
   private bool isDoor;
   private Transform playerTransform;
    void Start()
    {
        playerTransform=GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

   
    void Update()
    {
         if(isDoor)
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                playerTransform.position=backDoor.position;
            }
        }
    }
    // void EnterDoor()
    // {
    //     if(isDoor)
    //     {
    //         if(Input.GetKeyDown(KeyCode.Z))
    //         {
    //             playerTransform.position=backDoor.position;
    //         }
    //     }
    // }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player")&&other.GetType().ToString()=="UnityEngine.CapsuleCollider2D")
        {
         //Debug.Log("进入门的范围,按z传送");        
         isDoor=true;   
        }    
    }

      void OnTriggerExit2D(Collider2D other) 
    {
          if(other.gameObject.CompareTag("Player")&&other.GetType().ToString()=="UnityEngine.CapsuleCollider2D")
        {
         //Debug.Log("离开门的范围");    
         isDoor=false;     
        }    
    }
}
