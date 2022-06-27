using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSpike : MonoBehaviour
{
    public  GameObject HideSpikeBox;
    public float time;
    private Animator anim;
    void Start()
    {
        anim=GetComponent<Animator>();
    }

   
    void Update()
    {
        
    }
     void OnTriggerEnter2D(Collider2D other)
    {
       
       if(other.CompareTag("Player")&&other.GetType().ToString()=="UnityEngine.PolygonCollider2D")
       {
          StartCoroutine(SpikeAttack());
       }    
    }
    IEnumerator SpikeAttack()
    {
        yield return new WaitForSeconds(time);
        anim.SetTrigger("Attack");
        Instantiate(HideSpikeBox,transform.position,Quaternion.identity);
    }
}
