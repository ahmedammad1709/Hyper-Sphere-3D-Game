using UnityEngine;
using System.Collections;


public class player : MonoBehaviour
{
    private float moveforce = 10f;
    private float forwardforce = 17f;
    [SerializeField] private float jumpForce = 12f;
    private bool isGrounded = false;
    [SerializeField] private float extraGravity = 30f;

    double speed =0; //Extra variable to increase speed 
    float sp;
   
    private Rigidbody mybody;
   
    private Score scoreManager; //Only for ScoreBooster

    public int counter = 0;

    private float horizontal;

    void Start()
    {
        mybody = GetComponent<Rigidbody>();
        scoreManager = FindFirstObjectByType<Score>();

    }

    void Update()
    {
        speed += 0.004;
        move();
        if (isGrounded)
        {
            jump();
        }
    }
    public bool collideWithObstacle = false;

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Obstacles"))
        {
            Debug.Log("Collide with obs game end");
            collideWithObstacle = true;
            FindFirstObjectByType<overallGameManager>().playGameOverAudio();
            FindFirstObjectByType<overallGameManager>().gameEnd(0);
            destroyPlayer();
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("Player touches the ground.");
        }

    }

    public void destroyPlayer()
    {
        Destroy(gameObject);
    }

    void move()
    {
       horizontal = 0;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //Debug.Log("moving right");
            horizontal = 1;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal = -1;
        }

       
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
        {
            mybody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            Debug.Log("Jump");
            isGrounded = false;
        }
    }

    public void FixedUpdate()
    {        
        sp = (float)speed;
        float s = forwardforce + sp;
        //Debug.Log("Speed : " + s);

        Vector3 movement = new Vector3(horizontal * moveforce, 0, s) * Time.fixedDeltaTime;

        // Use Rigidbody for movement
        mybody.MovePosition(transform.position + movement);

        if (!isGrounded)
        {
            mybody.AddForce(Vector3.down * extraGravity, ForceMode.Acceleration);
        }
    }


    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            //CoinAudio.Play();
            FindFirstObjectByType<overallGameManager>().playCoinAudio();
            Coins coinIncrease = FindFirstObjectByType<Coins>();
            Destroy(other.gameObject);
            coinIncrease.coinIncrease();
           
        }

        if (other.gameObject.CompareTag("ScoreBooster"))
        {
            Debug.Log("Score Booster Starts ");
            //scoreBooster.SetActive(true);
            FindFirstObjectByType<overallGameManager>().ScoreBoosterImageTrue();
            StartCoroutine(ActiveScoreBoost());
            FindFirstObjectByType<overallGameManager>().playScoreBoosterAudio();
            Destroy(other.gameObject);
        }
       
        if (other.gameObject.CompareTag("ObstacleCounter"))
        {
            counter++;
          
        }

       
    }

    IEnumerator ActiveScoreBoost()
    {
        scoreManager.BoostScore(true);
        yield return new WaitForSeconds(5f);
        //scoreBooster.SetActive(false);
        FindFirstObjectByType<overallGameManager>().ScoreBoosterImageFalse();
        scoreManager.BoostScore(false);
        Debug.Log("Score Booster Exits");

    }



}