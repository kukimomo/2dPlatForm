using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmartBat :Enemy
{
    public float speed;
    public float radius;
    private Transform playerTransform;
    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        playerTransform=GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    public void Update()
    {
        base.Update();
        Debug.Log(playerTransform.gameObject.name);
        if(playerTransform!=null)
        {
            //Debug.Log("here!");
            //float distance=(transform.position-playerTransform.position).sqrMagnitude;
            float distance=Mathf.Abs(transform.position.x-playerTransform.position.x);
            if(distance<radius)
            {
               // Debug.Log("触发");
                transform.position=Vector2.MoveTowards(transform.position,playerTransform.position,speed*Time.deltaTime);
            }
        }
    }
}
