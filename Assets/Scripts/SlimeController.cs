using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour
{
    public float moveSpeed;
    public float timeBetweenMove, timeToMove, waitToReload;

    private float timeBetweenMoveCounter, timeToMoveCounter;
    private bool moving, reloading;
    private Rigidbody2D rig;
    private Vector3 moveDirection;
    private GameObject player;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);

        /*timeBetweenMoveCounter = timeBetweenMove;
        timeToMoveCounter = timeToMove;*/
    }

    void Update()
    {
        if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            rig.velocity = moveDirection;

            if (timeToMoveCounter < 0F)
            {
                moving = false;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
                //timeBetweenMoveCounter = timeBetweenMove;
            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            rig.velocity = Vector2.zero;

            if(timeBetweenMoveCounter < 0)
            {
                moving = true;
                timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeToMove * 1.25f);
                //timeToMoveCounter = timeToMove;
                moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
            }
        }

        if (reloading)
        {
            waitToReload -= Time.deltaTime;
            if(waitToReload < 0)
            {
                //Application.LoadLevel(Application.loadedLevel);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                player.SetActive(true);
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        /*if(other.gameObject.name == "Player")
        {
            other.gameObject.SetActive(false);
            reloading = true;
            player = other.gameObject;
        }*/
    }
}
