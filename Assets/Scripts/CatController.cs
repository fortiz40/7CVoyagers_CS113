using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)){
            Debug.Log("Right Key Pressed");
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Left Key Pressed");
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Space Pressed");
        }

    }
}
