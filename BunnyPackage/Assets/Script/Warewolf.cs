using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warewolf : MonoBehaviour
{
    public Transform targetPoint;
    public Transform[] wayPoints;
    public bool action = true;
    public bool anim;
    public bool StartPortal;
    public float moveSpeed;

    public Transform portalPositionUp;
    public BoxCollider2D portal;
   
    public int count;

    public Transform pointToFlip;
    public Transform pointToFlip1;

    private Animator warAnim;

    public bool winlose = true;

    // Start is called before the first frame update
    void Start()
    {
        warAnim = GetComponent<Animator>();
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
            if (transform.position == wayPoints[12].transform.position)
            {
                StartCoroutine(BoxColliderAct());
            }
        }
        
    }
   

    IEnumerator BoxColliderAct()
    {

        warAnim.SetBool("Portal", true);
        StartPortal = true;
        yield return new WaitForSeconds(1f);
        if (transform.position == wayPoints[count].transform.position)
        {

            anim = true;
            yield return new WaitForSeconds(1);
            transform.position = portalPositionUp.position;
            count = 13;
            SelectTarget();
            
            warAnim.SetBool("Portal", false);
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
