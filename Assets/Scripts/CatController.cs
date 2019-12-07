using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatController : MonoBehaviour
{

    private bool MOVE_DEBUG = false;

    private Rigidbody2D m_rigidbody;
    private bool grounded = true;

    public int score = 0;
    public int health = 5;


    public SpriteRenderer m_sprite_renderer;
    public Animator m_animator;

    [SerializeField] float move_speed = 0.5f;
    [SerializeField] float jump_force = 5;
    [SerializeField] public float gravity = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow)) {
            if (MOVE_DEBUG) Debug.Log("Right Key Pressed");
            //m_rigidbody.velocity = Vector2.right * move_speed;
            transform.Translate(Vector3.right * move_speed * Time.deltaTime);
            
            m_animator.SetFloat("speed", 1);
            m_sprite_renderer.flipX = false;
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (MOVE_DEBUG) Debug.Log("Left Key Pressed");
            transform.Translate(Vector3.left * move_speed * Time.deltaTime);
            //m_rigidbody.velocity = Vector2.left * move_speed;
            m_animator.SetFloat("speed", 1);
            m_sprite_renderer.flipX = true; 
        }

        else if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) )
        {
            //m_rigidbody.velocity = Vector2.zero;
            m_animator.SetFloat("speed", 0);
        }


        else
        {
            m_animator.SetFloat("speed", 0);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (MOVE_DEBUG) Debug.Log("Space Pressed");
            OnJump();
        }

    }

    /// <summary>
    /// Function to be called when the cat jumps
    /// </summary>
    void OnJump()
    {
        OnJump(1.0f);
    }

    private void OnJump(float max_height)
    {
        if (grounded == true)
        {
            grounded = false;
            m_animator.SetBool("grounded", false);
            m_rigidbody.AddForce(Vector2.up * jump_force * max_height);
        }
    }

    /// <summary>
    /// Function to be called when rat lands on the ground
    /// </summary>
    public void OnLand()
    {
        grounded = true;
        m_animator.SetBool("grounded", true);
    }
    
    /// <summary>
    /// Function to be called when the cat lands on rat to kill it
    /// </summary>
    public void OnRatKill()
    {
        score++;

        if ( score == 20)
        {
            SceneManager.LoadScene("Start Menu");
        }

        OnLand();
        m_rigidbody.velocity = Vector2.zero;
        OnJump(0.75f);
    }


    void OnDamaged()
    {
        health--;


        if (health < 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


    /// <summary>
    /// Function called when a gameObject collides with this gameObject
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.gameObject.tag);

        string collision_tag = collision.collider.gameObject.tag;

        if (collision_tag == "RatDamageBox")
        {
            Debug.Log("RAT HAS HIT THE CAT");
            OnDamaged();
        }
   
    }

}
