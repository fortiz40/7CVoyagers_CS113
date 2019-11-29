using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{

    private Rigidbody2D m_rigidbody;
    private bool grounded = true;

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
            Debug.Log("Right Key Pressed");

            transform.Translate(Vector3.right * move_speed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Left Key Pressed");
            transform.Translate(Vector3.left * move_speed * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space Pressed");
            OnJump();
        }

    }

    void OnJump()
    {
        if (grounded == true)
        {
            grounded = false;
            m_rigidbody.AddForce(Vector2.up * jump_force);
        }
    }

    void OnLand()
    {
        grounded = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag);

        if (collision.gameObject.tag == "Ground")
        {
            OnLand();
        }
   
    }

}
