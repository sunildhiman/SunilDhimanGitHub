﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool leftDir;
    private bool rightDir;
    private float HorizontalMove;
    public float speed = 5;
    // Jump
    private bool bounce;
    public Vector2 jump;
    public float jumpForce = 2.0f;
    public float jumpheight;
    // score
    public static float score;
    public Text scoreText ;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        rb = GetComponent<Rigidbody2D>();
        leftDir = false;
        rightDir = false;
        bounce = false;

        jump = new Vector3(0.0f, 0.2f, 0.0f);
    }

    public void leftbtnDown()
    {
        leftDir = true;
    }
    public void leftbtnUp()
    {
        leftDir = false;
    }
    public void rightbtnDown()
    {
        rightDir = true;
    }
    public void rightbtnUp()
    {
        rightDir = false;
    }
    // Update is called once per frame
    void Update()
    {
        movePlayer();
        if(rb.position.y< -30)
        {
            SceneManager.LoadScene("Level01");
        }
    }
    public void Bounce()
    {
        bounce = true;

    }
    private void movePlayer()
    {
        if (leftDir)
        {
            HorizontalMove = -speed;
        }
        else if (rightDir)
        {
            HorizontalMove = speed;
        }
        else
        {
            HorizontalMove = 0;
        }

    }
    private void FixedUpdate()
    {

        rb.velocity = new Vector2(HorizontalMove, rb.velocity.y);
        if (HorizontalMove == 0 && bounce)
        {
            rb.AddForce(new Vector2(0, jumpheight), ForceMode2D.Impulse);
            bounce = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            score++;
            
        //    if (score >= 5)
        //    {
        //        print("Level Completed");
        //        wintext.SetActive(true);
        //    }
        }
        else if (collision.gameObject.tag == "Enimy")
            {
                SceneManager.LoadScene("Level01");
            }
        setscoretext();

    }
    public void setscoretext()
    {
        scoreText.text = score.ToString();
    }
}
