using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class playerMove : MonoBehaviour
{
    [Header ("Component")]
    public Rigidbody2D thePlayer;
    public TextMeshProUGUI theStatus;

    [Header("Level")]
    public GameObject drone;
    public GameObject corona;

    [Header ("Value")]
    public float jumpForce;

    [Header("Boolean")]
    public bool gameStart;
    public bool gameWin;

    [Header("Timer")]
    public float timer;

 

    void Start()
    {
        thePlayer = GetComponent<Rigidbody2D>();
        gameStart = true;
        gameWin=false;
    }

    void Update()
    {
        if (gameWin)//menang
        {
            theStatus.text="You've Won";
            //Debug.Log("Win  win situatuiin");
            GameObject[] foundObjects = GameObject.FindGameObjectsWithTag("enemy"); // NOTE: only ACTIVE gameObjects will be found
 
            if (foundObjects.Length < 10){
                foreach (GameObject go in foundObjects)
                {
                    Destroy(go);
                }
            }
            else
            {
                //do something else (stop the game etc.)
            }
            //destroyAll("enemy");
        }
        else//selagi tak menang
        {
            if (gameStart)
            {
                thePlayer.velocity = new Vector2(0, 1) * jumpForce * Time.deltaTime;
                if (transform.position.y >= 0)
                {
                    gameStart = false;
                    StartCoroutine(theCoroutine());
                    theStatus.text = "Start";
                    //Debug.Log("Start");
                }
            }
            else
            {
                if ((Input.GetMouseButtonDown(0) || Input.GetButtonDown("Jump")))
                {
                    thePlayer.velocity = new Vector2(0, 1) * jumpForce * Time.deltaTime;
                }

                if (transform.position.y <= -4 || transform.position.y >= 4)
                {
                    playerDeath();
                }
                timer = timer - Time.deltaTime;
                //string theTimer = timer.ToString + "m";
                theStatus.text = timer.ToString() + "km";
                Debug.Log(timer);
            }
            if(timer<=0)
            {
                gameWin = true;
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
        if(!gameWin){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   
        }
        
    }

    IEnumerator theCoroutine()
    {
        while (gameWin==false)
        {
            float timeSlip = Random.Range(0.5f, 2f);
            yield return new WaitForSeconds(timeSlip);
            float yCorona = Random.Range(3, 8);
            float yDrone = Random.Range(-4, -8);

            Instantiate(drone, new Vector2(10, yDrone), transform.rotation);
            Instantiate(corona, new Vector2(12, yCorona), transform.rotation);
        }
    }
    /*void destroyAll(string tag){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);
        for (int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i]);
        }
    }*/
}
