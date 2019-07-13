using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text scoreText;
    public Text livesText;
    public Text winText;
    private int teleport;
    private Rigidbody rb;
    private int count;
    private int score;
    private int lives;
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        lives = 3;
        teleport = 0;
        SetCountText ();
        SetScoreText ();
        SetLivesText ();

        winText.text = "";
    }
    
void FixedUpdate ()
{
    float moveHorizontal = Input.GetAxis ("Horizontal");
    float moveVertical = Input.GetAxis ("Vertical");

    Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

   rb.AddForce (movement *(speed*Time.deltaTime));
  // rb.AddForce (movement *speed *Time.deltaTime);

   if (Input.GetKey("escape"))
     Application.Quit();
}
void OnTriggerEnter(Collider other)
    {
     if (other.gameObject.CompareTag("Pick Up"))
     {
         other.gameObject.SetActive (false);
         count = count + 1;
         score = score + 1;
         SetCountText ();
         SetScoreText ();
     }
     if (other.gameObject.CompareTag("Enemy"))
     {
         other.gameObject.SetActive (false);
         count = count + 1;
         score = score - 1;
         lives = lives - 1;
         SetCountText ();
         SetScoreText ();
         SetLivesText ();
     }
    }

void SetCountText (){
countText.text = "Count: " + count.ToString ();
        if (count >= 12)
        {
            if (teleport <= 0){
        transform.position = new Vector3(34.1f, 0.5f, -13.66f);
         teleport = teleport + 1;}
       
  }
  
}
void SetScoreText (){
scoreText.text = "Score: " + score.ToString ();
       if (score >= 20)
        {winText.text = "You Win!";}

        
}
void SetLivesText(){
livesText.text = "Lives: " + lives.ToString ();
       if (lives <= 0)
        {winText.text = "You Lose!";
        gameObject.SetActive(false);
       
        }
         
}

 
}

