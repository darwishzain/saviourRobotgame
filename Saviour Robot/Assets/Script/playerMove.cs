using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMove : MonoBehaviour
{
    [Header ("Component")]
    public Rigidbody2D thePlayer;

    [Header ("Value")]
    public float jumpForce;

    [Header("Boolean")]
    public bool gameStart;
    public bool gameWin;

    void Start()
    {
        thePlayer = GetComponent<Rigidbody2D>();
        gameStart = true;
    }

    void Update()
    {
        if (gameWin)
        {

        }
        else
        {
            if ((Input.GetMouseButtonDown(0) || Input.GetButtonDown("Jump")) && !gameStart)
            {
                thePlayer.velocity = new Vector2(0, 1) * jumpForce * Time.deltaTime;
            }

            if ((transform.position.y <= -4 || transform.position.y >= 4) && !gameStart )
            {
                playerDeath();
            }
            if (gameStart)
            {
                thePlayer.velocity = new Vector2(0, 1) * jumpForce * Time.deltaTime;
                Debug.Log("Trying..");
                if (transform.position.y >= 0)
                {
                    gameStart = false;
                    Debug.Log("Start");
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag=="enemy")
        {
            playerDeath();
        }
    }

    void playerDeath()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
