using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFeetController : MonoBehaviour
{

    private CatController catController;

    // Start is called before the first frame update
    void Start()
    {
        catController = GetComponentInParent<CatController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string collision_tag = collision.collider.gameObject.tag;

        if (collision_tag == "Ground")
        {
            catController.OnLand();
        }

        else if (collision_tag == "RatTop")
        {
            Debug.Log("LANDED ON TOP OF RAT!");
            catController.OnRatKill();
        }
    }
}
