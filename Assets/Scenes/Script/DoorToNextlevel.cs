using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorToNextlevel : MonoBehaviour
{
    
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
       
             if(other.gameObject.CompareTag("Player")&&other.GetType().ToString()=="UnityEngine.CapsuleCollider2D")
           {
                //Debug.Log("如果想传送请按Z");
                //if(Input.GetKeyDown(KeyCode.Z))
               // {
                  SceneManager.LoadScene("Scene1");
                //}
           }
          
    }
}
