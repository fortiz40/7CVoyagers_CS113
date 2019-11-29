using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{

    private Rigidbody2D m_rigidbody;
    private bool grounded = true;

    [SerializeField] int move_speed = 5;
    [SerializeField] int jump_force = 5;

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)){
            Debug.Log("Right Key Pressed");

            m_rigidbody.velocity = transform.right * move_speed;
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Left Key Pressed");
            m_rigidbody.velocity = -transform.right * move_speed;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space Pressed");
            m_rigidbody.AddForce(Vector2.up * jump_force);
        }

    }

    void OnJump()
    {
        grounded = false;
    }

    void OnLand()
    {
        grounded = true;
    }

}
