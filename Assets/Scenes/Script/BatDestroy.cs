using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatDestroy : MonoBehaviour
{
    public int batFlag;
        void Start()
    {
        
    }

   
    void Update()
    {
        
    }
    void OnDestroy()
    {
      EasterEgg.Password+=batFlag.ToString();
      Debug.Log("蝙蝠"+batFlag+"死掉了");
      Debug.Log(EasterEgg.Password);    
    }
}
