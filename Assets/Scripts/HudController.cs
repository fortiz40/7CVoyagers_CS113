using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{

    public GameObject CatPlayer;
    public Text HUD;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HUD.text = "Score: " + CatPlayer.GetComponent<CatController>().score + "/10\nHealth: " + CatPlayer.GetComponent<CatController>().health + "/5";
    }
}
