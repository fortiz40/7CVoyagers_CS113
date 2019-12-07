using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class RatMover : MonoBehaviour
{

    enum Movement { LEFT, RIGHT, LEFT_STOPPED, RIGHT_STOPPED };
    

    public Rigidbody2D m_rigidbody;
    public SpriteRenderer m_sprite_renderer;

    [SerializeField] public float movementSeconds = 2.0f;
    [SerializeField] public int speed = 5;

    Movement status = Movement.RIGHT_STOPPED;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveLoop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MoveLoop()
    {
        while (true)
        {
            Debug.Log("FLIPPING DIRECTION");
            if (status == Movement.RIGHT_STOPPED)
            {
                status = Movement.LEFT;
                m_sprite_renderer.flipX = false;
                MoveLeft();
            }
            else if (status == Movement.LEFT_STOPPED)
            {
                status = Movement.RIGHT;
                m_sprite_renderer.flipX = true;
                MoveRight();
            }

            else if (status == Movement.RIGHT)
            {
                status = Movement.RIGHT_STOPPED;
                Stop();
            }
            else if (status == Movement.LEFT)
            {
                status = Movement.LEFT_STOPPED;
                Stop();
            }

            yield return new WaitForSeconds(movementSeconds);
        }
    }

    void MoveLeft()
    {
        m_rigidbody.velocity = Vector2.left * speed;
    }

    void MoveRight()
    {
        m_rigidbody.velocity = Vector2.right * speed;
    }

    void Stop()
    {
        m_rigidbody.velocity = Vector2.zero;
    }
}
