using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickleHit : MonoBehaviour
{
    public GameObject sickle;
        void Start()
    {
        
    }

  
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
         //Debug.Log("success");
         Instantiate(sickle,transform.position,transform.rotation);
        
        }
    }

}      
