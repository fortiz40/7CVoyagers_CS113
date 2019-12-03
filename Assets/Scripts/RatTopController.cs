using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatTopController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string colliderTag = collision.collider.tag;
        Debug.Log("RAT TOP COLLIDED WITH" + colliderTag);
        if (colliderTag == "CatFeet")
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
