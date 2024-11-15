using UnityEditor.Experimental.GraphView;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    private Animator anim;
    float hmove;

    public float speed, jumpForce;
    public Transform groundcheck;//是否觸地
    public LayerMask ground;


    public bool isGround;

    bool jumpPress; //按鍵是否按下 
    int jumpCount = 0; // 跳躍次數


    void Start(){
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }


    void Update(){
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
            jumpPress = true; //按鍵按下

    }

    void FixedUpdate(){
        isOnGroundCheck();
        // isGround = Physics2D.OverlapCircle(groundcheck.position, 0.1f, ground);
        groundMove();
        jump();
    }

    void isOnGroundCheck(){
        if (coll.IsTouchingLayers(ground))
            isGround = true;

        else
            isGround = false;

    }

    //地面move
    void groundMove(){
        hmove = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(hmove * speed, rb.linearVelocity.y);

        if(hmove != 0){
            transform.localScale = new Vector3(hmove, 1, 1); // hmove +向右 -向左
        }

    }

    
    void jump(){
        if(isGround)
            jumpCount = 1;

    

        if(jumpPress && isGround){
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpCount--;
            jumpPress = false;

        }

        else if(jumpPress && jumpCount > 0 && !isGround){ // == !=isGround 二段跳 
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpCount--;
            jumpPress = false;
        }


    }





}
