using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{

    public Button m_button;

    // Start is called before the first frame update
    void Start()
    {
        m_button.onClick.AddListener(LoadStartMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }
}
