using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestructibleLayer : MonoBehaviour
{
    public float offsetX;
    public float offsetY;
    private Tilemap destructiableTilemap;

    private Vector3 pos1;
    private Vector3 pos2;
    private Vector3 pos3;
    private Vector3 pos4;
    private Vector3 pos5;
    private Vector3 pos6;
    private Vector3 pos7;
    private Vector3 pos8;
    void Start()
    {
        destructiableTilemap=GetComponent<Tilemap>();
    }

   
    void Update()
    {
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            Vector3 hitPos=other.bounds.ClosestPoint(other.transform.position);
            pos1=new Vector3(hitPos.x+offsetX,hitPos.y,0f);
            pos2=new Vector3(hitPos.x-offsetX,hitPos.y,0f);
            pos3=new Vector3(hitPos.x,hitPos.y+offsetY,0f);
            pos4=new Vector3(hitPos.x,hitPos.y-offsetY,0f);
            pos5=new Vector3(hitPos.x+offsetX,hitPos.y+offsetY,0f);
            pos6=new Vector3(hitPos.x+offsetX,hitPos.y-offsetY,0f);
            pos7=new Vector3(hitPos.x+offsetX,hitPos.y+offsetY,0f);
            pos8=new Vector3(hitPos.x+offsetX,hitPos.y-offsetY,0f);

            Vector3Int position=destructiableTilemap.WorldToCell(pos1);
            destructiableTilemap.SetTile(position,null);
            position=destructiableTilemap.WorldToCell(pos2);  
            destructiableTilemap.SetTile(position,null);
            position=destructiableTilemap.WorldToCell(pos3);  
            destructiableTilemap.SetTile(position,null);
            position=destructiableTilemap.WorldToCell(pos4);  
            destructiableTilemap.SetTile(position,null);
            position=destructiableTilemap.WorldToCell(pos5);  
            destructiableTilemap.SetTile(position,null);
            position=destructiableTilemap.WorldToCell(pos6);  
            destructiableTilemap.SetTile(position,null);
            position=destructiableTilemap.WorldToCell(pos7); 
            destructiableTilemap.SetTile(position,null);
            position=destructiableTilemap.WorldToCell(pos8);   
            destructiableTilemap.SetTile(position,null);
            
            Destroy(other.gameObject);
        }
        
    }
}
