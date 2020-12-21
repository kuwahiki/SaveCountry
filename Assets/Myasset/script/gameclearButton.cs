using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameclearButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnclikExit()
    {
        Application.Quit();
    }

    public void Onclikgameclear()
    {
        SceneManager.LoadScene("title");
    }
}
