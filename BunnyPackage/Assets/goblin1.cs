using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblin1 : MonoBehaviour
{
    public Transform targetPoint;
    public Transform[] wayPoints;
    public bool action = true;
    public bool anim;
    public bool StartPortal;
    public float moveSpeed;

    public int count;

    public Transform pointToFlip;
    public Transform pointToFlip1;

    private Animator gobAnim;

    public bool winlose = true;

    // Start is called before the first frame update
    void Start()
    {
        gobAnim = GetComponent<Animator>();
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
            rotation.y = 0;

        }
        else if (transform.position.x == pointToFlip1.transform.position.x)
        {
            rotation.y = -180;

        }

        transform.eulerAngles = rotation;
    }
}
