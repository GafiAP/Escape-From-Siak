using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    public Rigidbody2D myRb;
    private bool isFacingRight = true;
    private Animator anim;
    private string running = "isrun";
    public bool preventRun;

    public bool winlose= false;
    void Start()
    {
        preventRun = false;
        myRb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (winlose)
        {
            Destroy(gameObject);
        }
        float move = Input.GetAxisRaw("Horizontal");
        if (preventRun == false)
        {
            myRb.velocity = new Vector2(move * moveSpeed, myRb.velocity.y);
        }
        else
        {
            myRb.velocity = Vector2.zero;
        }


        if (move > 0 && !isFacingRight)
        {
            transform.localScale = new Vector2(1, transform.localScale.y);
            isFacingRight = true;
        }
        else if (move < 0 && isFacingRight)
        {
            transform.localScale = new Vector2(-1, transform.localScale.y);
            isFacingRight = false;
        }
        if (move == 0)
        {
            anim.SetBool(running, false);
        }

        if (move != 0)
        {
            anim.SetBool(running, true);
        }
    }
}
