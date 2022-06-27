using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashBinCoin : MonoBehaviour
{
   public Text coinText;
   public static int coinCurrent;
   public static int coinMax;
   private Image trashBinBar;
    void Start()
    {
        trashBinBar=GetComponent<Image>();
        coinCurrent=0;
        coinMax=99;
    }

  
    void Update()
    {
        trashBinBar.fillAmount=(float)coinCurrent/(float)coinMax;
        coinText.text=coinCurrent.ToString()+"/"+coinMax.ToString();
    }
}
