using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour
{
    public float moveSpeed, walkTime, waitTime;
    public bool isWalking, canMove;
    public Collider2D walkZone;

    private Vector2 minWalkPoint, maxWalkPoint;
    private Rigidbody2D rig;
    private DialogueManager dMan;
    private float walkCounter, waitCounter;
    private int walkDirection;
    private bool hasWalkZone;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        dMan = FindObjectOfType<DialogueManager>();

        if (walkZone != null)
        {

            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
            hasWalkZone = true;
        }

        waitCounter = waitTime;
        walkCounter = walkTime;

        canMove = true;

        ChooseDirection();
    }

    void Update()
    {
        if (!dMan.dialogueActive)
        {
            canMove = true;
        }

        if (!canMove)
        {
            rig.velocity = Vector2.zero;
            return;
        }

        if (isWalking)
        {
            walkCounter -= Time.deltaTime;
            
            switch (walkDirection)
            {
                case 0:
                    {
                        rig.velocity = new Vector2(0, moveSpeed);
                        if (hasWalkZone && transform.position.y >= maxWalkPoint.y)
                        {
                            isWalking = false;
                        }
                        break;
                    }
                case 1:
                    {
                        rig.velocity = new Vector2(moveSpeed, 0);
                        if (hasWalkZone && transform.position.x >= maxWalkPoint.x)
                        {
                            isWalking = false;
                        }
                        break;
                    }
                case 2:
                    {
                        rig.velocity = new Vector2(0, -moveSpeed);
                        if (hasWalkZone && transform.position.y <= minWalkPoint.y)
                        {
                            isWalking = false;
                        }
                        break;
                    }
                case 3:
                    {
                        rig.velocity = new Vector2(-moveSpeed, 0);
                        if (hasWalkZone && transform.position.x <= minWalkPoint.x)
                        {
                            isWalking = false;
                        }
                        break;
                    }
            }

            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;

            rig.velocity = Vector2.zero;

            if(waitCounter < 0)
            {
                ChooseDirection();
            }
        }
    }

    public void ChooseDirection()
    {
        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }
}
