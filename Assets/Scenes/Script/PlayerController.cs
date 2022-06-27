using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed;
    public float jumpSpeed;
    public float doubleJumpSpeed;
    public float climbSpeed;
    public float restoreTime;

    private Rigidbody2D myRigidbody;
    private Animator myAnim;
    private BoxCollider2D myFeet;
    private bool isGround;
    private bool canDoubleJump;
    private bool isOneWayPlatform;
    private bool isLadder;
    private bool isClimbing;
    private bool isJumping;
    private bool isFalling;
    private bool isDoubleJumping;
    private bool isDoubleFalling;

    private float playerGravity;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody=GetComponent<Rigidbody2D>();
        myAnim=GetComponent<Animator>();
        myFeet=GetComponent<BoxCollider2D>();
        playerGravity=myRigidbody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.isGameAlive)
        {
         CheckAirStatus();
         Run();
         Flip();
         Jump();
         Climb();
         CheckGround();
         CheckLadder();
         SwitchAnimation();
         OneWayPlatformCheck();
        //Attack();
        }
    }

    void CheckGround()
    {
          isGround=myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"))||
                   myFeet.IsTouchingLayers(LayerMask.GetMask("MovingPlatform"))||
                    myFeet.IsTouchingLayers(LayerMask.GetMask("BreakableTile"))||
                   myFeet.IsTouchingLayers(LayerMask.GetMask("OneWayPlatform"));
          isOneWayPlatform= myFeet.IsTouchingLayers(LayerMask.GetMask("OneWayPlatform"));
          
    }
    
    void CheckLadder()
    {
        isLadder=myFeet.IsTouchingLayers(LayerMask.GetMask("Ladder"));
    }

    void Flip()
    {
        bool playerHasXAxisSpeed=Mathf.Abs(myRigidbody.velocity.x)>Mathf.Epsilon;
        if(playerHasXAxisSpeed)
        {
            if(myRigidbody.velocity.x>0.1f)
            {
                transform.localRotation=Quaternion.Euler(0,0,0);
            }
            if(myRigidbody.velocity.x<-0.1f)
            {
                transform.localRotation=Quaternion.Euler(0,180,0);
            }
        }
    }

    void Run()
    {
       float   moveDir=Input.GetAxis("Horizontal");
       //Vector2 playerVec1 =new Vector2(moveDir*runSpeed,myRigidbody.velocity.y);
       //myRigidbody.velocity=playerVec1;
       myRigidbody.velocity = new Vector2(moveDir * runSpeed, myRigidbody.velocity.y);
       bool playerHasXAxisSpeed=Mathf.Abs(myRigidbody.velocity.x)>Mathf.Epsilon;
       myAnim.SetBool("Run",playerHasXAxisSpeed); 
    }
    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(isGround)
            {
             myAnim.SetBool("Jump",true);   
             Vector2 jumpVe1=new Vector2(0.0f,jumpSpeed);
             myRigidbody.velocity=Vector2.up*jumpVe1;
             canDoubleJump=true;
            }
            else
            {
                if(canDoubleJump)
                {
                    myAnim.SetBool("DoubleJump",true);
                    Vector2 doubleJumpVe1=new Vector2 (0.0f,doubleJumpSpeed);
                    myRigidbody.velocity=Vector2.up*doubleJumpVe1;
                    canDoubleJump=false;
                }
            }
        }
    }
    void Climb()
    {
        if(isLadder)
        {
            float moveY=Input.GetAxis("Vertical");
            if(moveY>0.5f||moveY<-0.5f)
            {
                myAnim.SetBool("Climbing",true);
                myRigidbody.gravityScale=0.0f;
                myRigidbody.velocity=new Vector2(myRigidbody.velocity.x,moveY*climbSpeed);

            }
            else
            {
                if(isJumping||isFalling||isDoubleJumping||isDoubleFalling)
                {
                    myAnim.SetBool("Climbing",false);
                }
                else
                {
                    myAnim.SetBool("Climbing",false);
                    myRigidbody.velocity=new Vector2(myRigidbody.velocity.x,0.0f);
                }
            }
        }
        else
        {
            myAnim.SetBool("Climbing",false);
            myRigidbody.gravityScale=playerGravity;
        }
    }
    // void Attack()
    // {
    //     if(Input.GetButtonDown("Attack"))
    //     {
    //         myAnim.SetTrigger("Attack");
    //     }
    // }
    void SwitchAnimation()
    {
        myAnim.SetBool("Idle",false);
        if(myAnim.GetBool("Jump"))
        {
            if(myRigidbody.velocity.y<0.0f)
            {
                myAnim.SetBool("Jump",false);
                myAnim.SetBool("Fall",true);
            }
        }
        else if(isGround)
        {
            myAnim.SetBool("Fall",false);
            myAnim.SetBool("Idle",true);
        }
        
        if(myAnim.GetBool("DoubleJump"))
        {
            if(myRigidbody.velocity.y<0.0f)
            {
                myAnim.SetBool("DoubleJump",false);
                myAnim.SetBool("DoubleFall",true);
            }
        }
        else if(isGround)
        {
            myAnim.SetBool("DoubleFall",false);
            myAnim.SetBool("Idle",true);
        }
       
    }
    void OneWayPlatformCheck()
    {
        if(isGround&&gameObject.layer!=LayerMask.NameToLayer("Player"))
        {
            gameObject.layer=LayerMask.NameToLayer("Player");
        }

        float moveY=Input.GetAxis("Vertical");
        if(isOneWayPlatform&&moveY<-0.1f)
        {
            gameObject.layer=LayerMask.NameToLayer("OneWayPlatform");
            Invoke("RestorePlayerLayer",restoreTime);
        }
    }
    void RestorePlayerLayer()
    {
        if(!isGround&&gameObject.layer!=LayerMask.NameToLayer("Player"))
        {
            gameObject.layer=LayerMask.NameToLayer("Player");
        }
    }
    void CheckAirStatus()
    {
        isJumping=myAnim.GetBool("Jump");
        isFalling=myAnim.GetBool("Fall");
        isDoubleJumping=myAnim.GetBool("DoubleJump");
        isDoubleFalling=myAnim.GetBool("DoubleFall");
        isClimbing=myAnim.GetBool("Climbing");
        
    }
}
