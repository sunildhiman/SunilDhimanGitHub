using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
            bounce = false;
        }
    }
}
