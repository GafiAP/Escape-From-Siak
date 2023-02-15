using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private Transform rayCastOrigin;
    [SerializeField] private Transform playerFeet;
    [SerializeField] private LayerMask layerMask;
    private RaycastHit2D Hit2D;
    private PlayerMovement myRb;
    public bool jumpCheck;
    public PolygonCollider2D colliderStair;


    private void Start()
    {
        jumpCheck = false;
        myRb = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame

    private void Update()
    {
        if (jumpCheck == false)
        {
            GroundCheckMethod();
            
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GroundStair")
        {
            colliderStair.enabled = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GroundStair")
        {
            colliderStair.enabled = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "UpGround")
        {
            jumpCheck = true;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "UpGround")
        {
            jumpCheck = false;
            StartCoroutine(WaitCheck());
        }
        
    }
    IEnumerator WaitCheck()
    {
        yield return new WaitForSeconds(3f);
        jumpCheck = false;
    }
    void GroundCheckMethod()
    {
        
        Hit2D = Physics2D.Raycast(rayCastOrigin.position, -Vector2.up, 100f, layerMask);
        if(Hit2D != false)
        {
            Vector2 temp = playerFeet.position;
            temp.y = Hit2D.point.y;
            playerFeet.position = temp;
        }
        
    }
}
