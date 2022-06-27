using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBomb : MonoBehaviour
{
   public GameObject bomb;
    void Start()
    {
        
    }

        void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            Instantiate(bomb,transform.position,transform.rotation);
        }
    }
}
