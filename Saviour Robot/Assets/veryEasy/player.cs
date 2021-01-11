using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class player : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Hello");
    }
    /*
    [Header("Reference")]
    public Rigidbody2D  thePlayer;
    public TextMeshProUGUI theStatus;
    public GameObject drone;
    public GameObject corona;
    public GameObject[] theHeart;

    [Header("Value")]
    public int life;
    public float jumpForce;
    public bool play;
    

    void Start()
    {
        thePlayer = GetComponent<Rigidbody2D>();
        life=5;
        startGame();
    }

    
    void Update()
    {
        if(play)
        {
            if((Input.GetMouseButtonDown(0) || Input.GetButtonDown("Jump")))
            {
                thePlayer.velocity = new Vector2(0, 1) * jumpForce * Time.deltaTime;   
            }
            if(transform.position.y>5||transform.position.y<-5)
            {
                minusLife();
            }
        }
    }
    void minusLife()
    {
        life--;
        if(life<1)
        {
            Destroy(theHeart[0].gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }else if(life<2)
        {
            Destroy(theHeart[1].gameObject);
        }else if(life<3)
        {
            Destroy(theHeart[2].gameObject);
        }else if(life<4)
        {
            Destroy(theHeart[3].gameObject);
        }else if(life<5)
        {
            Destroy(theHeart[4].gameObject);
        }
        startGame();
    }

    void startGame()
    {
        StopCoroutine(theCoroutine());
        theStatus.text="System reboot";
        while(transform.position.y<=0)
        {
            thePlayer.velocity = new Vector2(0,1)*jumpForce*Time.deltaTime;
            play=true;
            StartCoroutine(theCoroutine());
        }
    }
    IEnumerator theCoroutine()
    {
        while(life>=0)
        {
            float timeGap = Random.Range(0.5f,2f);
            yield return new WaitForSeconds(timeGap);

            float yCorona = Random.Range(3, 8);
            float yDrone = Random.Range(-4, -8);

            GameObject theDrone = Instantiate(drone, new Vector2(10, yDrone), Quaternion.identity);
            GameObject theCorona = Instantiate(corona, new Vector2(12, yCorona), Quaternion.identity);
        }
    }
    */
}
