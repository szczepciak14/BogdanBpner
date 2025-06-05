using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleetScript : MonoBehaviour
{

    public float moveTime = 2f;
    public float moveSpeed = 0.3f;
    public bool gameRun;

    private int moveCounter = 0;
    private int moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        moveDirection = 1;
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameRun && transform.childCount == 0)
        {
            StopGame(true);
        }
    }

    public void StopGame(bool win)
    {
        CancelInvoke("Move");
        gameRun = false;
    }

    public void StartGame()
    {
        InvokeRepeating("Move", moveTime, moveTime);
        gameRun = true;
    }

    void Move()
    {
        transform.position += new Vector3(moveSpeed + moveDirection, 0f, 0f);

        moveCounter += moveDirection;

        if (moveCounter <= -4 || moveCounter >= 4)
        {
            moveDirection *= -1;
            transform.position -= new Vector3(0, moveSpeed, 0);
        }
    }
}
