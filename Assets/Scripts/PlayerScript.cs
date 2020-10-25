using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D rd2d;
    public float speed;
    public Text score;
    private int scoreValue = 0;
    public Text win;
    public Text lives;
    private int livesValue = 3;
    public Text lose;
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    public AudioSource musicSource;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
        lives.text = livesValue.ToString();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float verMovement = Input.GetAxis("Vertical");

        rd2d.AddForce(new Vector2(hozMovement * speed, verMovement * speed));

    }

   private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);
        }

        if (collision.collider.tag == "Enemy")
        {
            livesValue -= 1;
            lives.text = livesValue.ToString();
            Destroy(collision.collider.gameObject);
        }


        if (collision.collider.tag == "TrickWall")
        {
            if (scoreValue > 3)
            {
                Destroy(collision.collider.gameObject);
            }
        }


        if (livesValue == 0)
            {
                Destroy(this);
            }
       

            if (scoreValue < 4)
        {
            win.text = "";
        }

        if (scoreValue == 8)
        {
            win.text = "You win! Game Created by Ian Smith";
            musicSource.clip = musicClipOne;
            musicSource.Play();
        }

        if (livesValue > 0)
        {
            lose.text = "";
        }

        if (livesValue == 0)
        {
            lose.text = "You lose!";
        }

        if (scoreValue == 4)
        {
            livesValue = 3;
            lives.text = livesValue.ToString();
        }

        if (collision.collider.tag == "Enemy")
        {
            livesValue -= 1;
            lives.text = livesValue.ToString();
            Destroy(collision.collider.gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            if(Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }

            if (Input.GetKey("escape"))

            {
                Application.Quit();
            }
        }
    }

}
