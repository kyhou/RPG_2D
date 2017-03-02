using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed, attackTime, runSpeedMultiplier;
    public Vector2 lastMove;
    public string startPoint;
    public bool canMove;

    private Vector2 moveInput;
    private Animator animator;
    private Rigidbody2D playerRig;
    private SFXManager sfxManager;
    private GameObject inventoryPanel, characterPanel;
    private bool playerMoving, attacking;
    private static bool playerExists;
    private float attackTimeCounter, moveSpeedTemp;

	void Start ()
    {
        inventoryPanel = GameObject.Find("Inventory Panel");
        characterPanel = GameObject.Find("Character Panel");
        animator = GetComponent<Animator>();
        playerRig = GetComponent<Rigidbody2D>();
        sfxManager = FindObjectOfType<SFXManager>();

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        canMove = true;
        lastMove = new Vector2(0, -1f);
        moveSpeedTemp = moveSpeed;

        if (runSpeedMultiplier < 1)
        {
            runSpeedMultiplier = 1;
        }
    }
	
	void Update ()
    {
        playerMoving = false;

        if (!canMove)
        {
            playerRig.velocity = Vector2.zero;
            animator.SetBool("PlayerMoving", false);
            return;
        }

        if (!attacking)
        {
            /*if (Input.GetAxisRaw("Horizontal") != 0)
            {
                playerRig.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, playerRig.velocity.y);
                //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            }
            else
            {
                playerRig.velocity = new Vector2(0f, playerRig.velocity.y);
            }

            if (Input.GetAxisRaw("Vertical") != 0)
            {
                playerRig.velocity = new Vector2(playerRig.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);
                //transform.Translate(new Vector3(0, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                playerMoving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }
            else
            {
                playerRig.velocity = new Vector2(playerRig.velocity.x, 0f);
            }

            if (Input.GetAxisRaw("Vertical") != 0 && Input.GetAxisRaw("Horizontal") != 0)
            {
                playerRig.velocity = playerRig.velocity * diagonalMoveModifier;
            }*/

            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

            if(moveInput != Vector2.zero)
            {
                playerRig.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
                playerMoving = true;
                lastMove = moveInput;
            }
            else
            {
                playerRig.velocity = Vector2.zero;
                playerMoving = false;
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                attackTimeCounter = attackTime;
                attacking = true;
                playerRig.velocity = Vector2.zero;
                animator.SetBool("Attack", true);
                sfxManager.playerAttack.Play();
            }

            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (moveSpeed == moveSpeedTemp)
                {
                    moveSpeed *= runSpeedMultiplier;
                }
            }
            else
            {
                moveSpeed = moveSpeedTemp;
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                if (!inventoryPanel.activeSelf)
                    inventoryPanel.SetActive(true);
                else
                    inventoryPanel.SetActive(false);

            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                if (!characterPanel.activeSelf)
                    characterPanel.SetActive(true);
                else
                    characterPanel.SetActive(false);

            }


        }

        if(attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }

        if(attackTimeCounter <= 0)
        {
            attacking = false;
            animator.SetBool("Attack", false);
        }

        animator.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        animator.SetBool("PlayerMoving", playerMoving);
        animator.SetFloat("LastMoveX", lastMove.x);
        animator.SetFloat("LastMoveY", lastMove.y);
    }


}
