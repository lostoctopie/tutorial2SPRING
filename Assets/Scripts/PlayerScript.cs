using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;

    public float speed;

    public Text score;

    private int scoreValue = 0;
    public Text WinText; 
    public int lives = 3; 
    public Text LivesText;
    public Text LoseText; 
    public AudioClip musicClipOne;

    public AudioClip musicClipTwo;

    public AudioSource musicSource;

    public int Lives { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
        WinText.text = " "; 
        LivesText.text = "Lives: " + lives.ToString();
        LoseText.text = " "; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);

            if (scoreValue == 4)
            {
                transform.position = new Vector3(46.5f, 0.77f, 50.0f); 

            lives = 3;
            LivesText.text = "Lives: " + lives.ToString();
            }

            if (scoreValue == 8)
            { 
                WinText.text = "You Win! Game created by Brenah Morales"; 
                rd2d.simulated = false;
                musicSource.clip = musicClipTwo;
                musicSource.Play();
            }
        }
        
        //enemy 
        if (collision.collider.tag == "Enemy")
        {
            lives -= 1;
            LivesText.text = "Lives: " + lives.ToString();
            Destroy(collision.collider.gameObject);

            if (lives == 0)
            {
                LoseText.text = "You Lose!"; 
                rd2d.simulated = false;
            }
            
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse); //the 3 in this line of code is the player's "jumpforce," and you change that number to get different jump behaviors.  You can also create a public variable for it and then edit it in the inspector.
            }
        }
    }
}



//TRANSFORM
//if (count == 12) /*note that this number should be equal to the number of yellow pickups on the first playfield
//{
//    transform.position = new Vector3(50.0f, 0.0f, 50.0f); 
//} 