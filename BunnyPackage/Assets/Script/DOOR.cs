using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOOR : MonoBehaviour
{
    [SerializeField] Transform waypoinA;
    [SerializeField] Transform waypointB;
    [SerializeField] Transform waypoinC;
    [SerializeField] Transform waypoinD;
    [SerializeField] Transform waypoinE;
    [SerializeField] Transform waypoinF;
    [SerializeField] Transform waypoinG;
    [SerializeField] Transform waypoinH;
    private Rigidbody2D rb;

    private Animator anim;
    private PlayerMovement pMove;

    public bool walk = true;
    private void Awake()
    {
        pMove = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("door1A") && Input.GetKeyDown(KeyCode.W))
        {
            pMove.preventRun = true;
            
            anim.SetTrigger("Climb");
            Invoke("ComeDoorA", 0.8f);
            StartCoroutine(StopMove());
        }
        else if (col.gameObject.CompareTag("door1B") && Input.GetKeyDown(KeyCode.W))
        {
            pMove.preventRun = true;
            anim.SetTrigger("Climb");
            Invoke("ComeDoorB", 0.8f);
            StartCoroutine(StopMove());
        }
        else if (col.gameObject.CompareTag("door1C") && Input.GetKeyDown(KeyCode.W))
        {
            pMove.preventRun = true;
            anim.SetTrigger("Climb");
            Invoke("ComeDoorC", 0.8f);
            StartCoroutine(StopMove());
        }
        else if (col.gameObject.CompareTag("door1D") && Input.GetKeyDown(KeyCode.W))
        {
            pMove.preventRun = true;
            anim.SetTrigger("Climb");
            Invoke("ComeDoorD", 0.8f);
            StartCoroutine(StopMove());
        }
        else if (col.gameObject.CompareTag("door1E") && Input.GetKeyDown(KeyCode.W))
        {
            pMove.preventRun = true;
            anim.SetTrigger("Climb");
            Invoke("ComeDoorE", 0.8f);
            StartCoroutine(StopMove());
        }
        else if (col.gameObject.CompareTag("door1F") && Input.GetKeyDown(KeyCode.W))
        {
            pMove.preventRun = true;
            anim.SetTrigger("Climb");
            Invoke("ComeDoorF", 0.8f);
            StartCoroutine(StopMove());
        }
        else if (col.gameObject.CompareTag("door1G") && Input.GetKeyDown(KeyCode.W))
        {
            pMove.preventRun = true;
            anim.SetTrigger("Climb");
            Invoke("ComeDoorG", 0.8f);
            StartCoroutine(StopMove());
        }
        else if (col.gameObject.CompareTag("door1H") && Input.GetKeyDown(KeyCode.W))
        {
            pMove.preventRun = true;
            anim.SetTrigger("Climb");
            Invoke("ComeDoorH", 0.8f);
            StartCoroutine(StopMove());
        }

    }
    IEnumerator StopMove()
    {
        yield return new WaitForSeconds(0.8f);
        pMove.preventRun = false;
    }


    void ComeDoorA()
    {
        transform.position = waypointB.position;
    }
    void ComeDoorB()
    {
        transform.position = waypoinA.position;
    }
    void ComeDoorC()
    {
        transform.position = waypoinD.position;
    }
    void ComeDoorD()
    {
        transform.position = waypoinC.position;
    }
    void ComeDoorE()
    {
        transform.position = waypoinF.position;
    }
    void ComeDoorF()
    {
        transform.position = waypoinE.position;
    }
    void ComeDoorG()
    {
        transform.position = waypoinH.position;
    }
    void ComeDoorH()
    {
        transform.position = waypoinG.position;
    }

    public void doorA()
    {
        transform.position = waypoinA.position;
    }

    public void palsu()
    {
        walk = false;
    }


}
