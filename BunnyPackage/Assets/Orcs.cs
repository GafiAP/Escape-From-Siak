using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orcs : MonoBehaviour
{
    public Transform targetPoint;
    public Transform[] wayPoints;
    public bool action = true;
    public bool anim;
    public bool StartPortal;
    public float moveSpeed;

    public Transform portalPositionUp;
    public Transform portalPositionDown;
    public Transform portalPositionUp1;
    public Transform portalPositionDown1;
    public Transform portalPositionUp2;
    public Transform portalPositionDown2;
    public BoxCollider2D portal;
    public BoxCollider2D portal1;
    public BoxCollider2D portal2;
    public BoxCollider2D portal3;
    public BoxCollider2D portal4;
    public BoxCollider2D portal5;
    public int count;

    public Transform pointToFlip;
    public Transform pointToFlip1;

    private Animator orcsAnim;

    public bool winlose = true;

    // Start is called before the first frame update
    void Start()
    {
        orcsAnim = GetComponent<Animator>();
        targetPoint = wayPoints[0];
        anim = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (winlose)
        {
            if (anim == false)
            {
                Move();
                Flip();

            }

        }
        if (transform.position == wayPoints[5].transform.position)
        {
            StartCoroutine(BoxColliderAct());
        }
        else if (transform.position == wayPoints[7].transform.position)
        {
            StartCoroutine(BoxColliderAct1());
        }
    }

    IEnumerator BoxColliderAct()
    {

        orcsAnim.SetBool("Portal", true);
        StartPortal = true;
        yield return new WaitForSeconds(1f);
        if (transform.position == wayPoints[count].transform.position)
        {

            anim = true;
            yield return new WaitForSeconds(1);
            transform.position = portalPositionUp.position;
            count = 7;
            SelectTarget();

            orcsAnim.SetBool("Portal", false);
            StartPortal = false;
            yield return new WaitForSeconds(1);
            anim = false;

        }

    }
    IEnumerator BoxColliderAct1()
    {

        orcsAnim.SetBool("Portal", true);
        StartPortal = true;
        yield return new WaitForSeconds(1f);
        if (transform.position == wayPoints[count].transform.position)
        {

            anim = true;
            yield return new WaitForSeconds(1);
            transform.position = portalPositionUp1.position;
            count = 9;
            SelectTarget();


            orcsAnim.SetBool("Portal", false);
            StartPortal = false;
            yield return new WaitForSeconds(1);
            anim = false;
        }

    }
    IEnumerator BoxColliderAct2()
    {

        orcsAnim.SetBool("Portal", true);
        StartPortal = true;
        yield return new WaitForSeconds(1f);
        if (transform.position == wayPoints[count].transform.position)
        {

            anim = true;
            yield return new WaitForSeconds(1);
            transform.position = portalPositionUp2.position;
            count = 14;
            SelectTarget();

            orcsAnim.SetBool("Portal", false);
            StartPortal = false;
            yield return new WaitForSeconds(1);
            anim = false;
        }

    }

    public void SelectTarget()
    {

        if (count < wayPoints.Length && action == true)
        {

            targetPoint = wayPoints[count];
        }
        else if (count == wayPoints.Length)
        {
            count = 0;
            targetPoint = wayPoints[count];
        }
    }

    public void Move()
    {
        if (transform.position == wayPoints[count].transform.position)
        {
            if (StartPortal == false)
            {
                if (action == true)
                {
                    count++;
                    SelectTarget();
                }
                else
                {
                    count = 0;
                    SelectTarget();
                }
            }
        }
        else
        {
            Vector2 targetPosition = new Vector2(targetPoint.position.x, targetPoint.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x == pointToFlip.transform.position.x)
        {
            action = true;
            rotation.y = -180;

        }
        else if (transform.position.x == pointToFlip1.transform.position.x)
        {
            rotation.y = 0;

        }

        transform.eulerAngles = rotation;
    }
}
