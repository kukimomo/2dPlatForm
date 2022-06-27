using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBinItem : MonoBehaviour
{
    private bool isPlayerInTrashBin;
    void Start()
    {
        
    }

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            if(isPlayerInTrashBin)
            {
                if(CoinUI.CurrentCoinQuantity>0)
                {
                    SoundManager.PlayThrowCoinClip();
                    TrashBinCoin.coinCurrent++;
                    CoinUI.CurrentCoinQuantity--;
                }
            }
        }
    }
      void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player")&&other.GetType().ToString()=="UnityEngine.CapsuleCollider2D")
        {
         isPlayerInTrashBin=true;   
         //Debug.Log("player is in Trash Bin");        
        }    
    }

      void OnTriggerExit2D(Collider2D other) 
    {
          if(other.gameObject.CompareTag("Player")&&other.GetType().ToString()=="UnityEngine.CapsuleCollider2D")
        {
         isPlayerInTrashBin=false;     
         //sDebug.Log("Player is not in Trash Bin");    
        }    
    }
}
