using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FleetScript : MonoBehaviour
{

    public float moveTime = 2f;
    public float moveSpeed = 0.3f;
    public bool gameRun;
    public TMP_Text endText;

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

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    public void StopGame(bool win)
    {
        CancelInvoke("Move");
        gameRun = false;

        endText.gameObject.SetActive(true);
        endText.text = (win) ? "LGBTQ DEFEATED" : "You Lose !!!";
    }

    public void StartGame()
    {
        InvokeRepeating("Move", moveTime, moveTime);
        gameRun = true;

        endText.gameObject.SetActive(false);
    }

    void Move()
    {
        transform.position += new Vector3(moveSpeed * moveDirection, 0f, 0f);

        moveCounter += moveDirection;

        if (moveCounter <= -4 || moveCounter >= 4)
        {
            moveDirection *= -1;
            transform.position -= new Vector3(0, moveSpeed);
        }
    }
}
