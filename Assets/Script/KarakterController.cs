using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterController : MonoBehaviour
{
    private Rigidbody2D rb2D;
    Animator anim;

    public float moveSpeed = 3f;
    private float moveHorizontal;
    // Start is called before the first frame update
    bool faceRight = true;

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //store the moveHorizontal value
        moveHorizontal = Input.GetAxisRaw("Horizontal");

    }

    void FixedUpdate()
    {
        Move(moveHorizontal);
    }

    
    void Move(float dir){
        float xVal = dir * moveSpeed * 100 * Time.deltaTime;
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
