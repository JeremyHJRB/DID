using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    Animator anim;
    [SerializeField]Transform goundCheck;
    [SerializeField]LayerMask groundLayer;

    const float groundRadius = 0.2f;
    public float moveSpeed = 3f;
    private float moveHorizontal;
    // Start is called before the first frame update
    [SerializeField]bool isGrounded=false;
    bool faceRight = true;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove()==false)
            return;
        //store the moveHorizontal value
        moveHorizontal = Input.GetAxisRaw("Horizontal");

    }

    void FixedUpdate()
    {
        groundCheck();
        Move(moveHorizontal);
    }

    bool canMove()
    {
        bool can = true;
        if(FindObjectOfType<InteractionSystem>().isUsed)
            can = false;
        return can;
    }

    void groundCheck()
    {
        isGrounded = false;
        //check if the player is on the ground
        Collider2D[] colliders = Physics2D.OverlapCircleAll(goundCheck.position, groundRadius, groundLayer);
        if (colliders.Length > 0)
            isGrounded = true;
    }

    
    void Move(float dir){
        float xVal = dir * moveSpeed * 100 * Time.fixedDeltaTime;
        Vector2 targetVelocity = new Vector2(xVal,rb2D.velocity.y);
        rb2D.velocity = targetVelocity;

        

        //if looking right click left flip character to left
        if(dir < 0 && faceRight){
            transform.localScale = new Vector3(-1,1,1);
            faceRight = false;
        }
        //if looking left click right flip character to right
        if (dir > 0 && !faceRight)
        {
            transform.localScale = new Vector3(1, 1, 1);
            faceRight = true;
        }

        // 0 = idle, 3 = move
        anim.SetFloat("xVelocity", Mathf.Abs(rb2D.velocity.x));

    }
}
