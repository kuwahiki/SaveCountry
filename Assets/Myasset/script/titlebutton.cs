using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titlebutton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void OnclikStart()
    {
        SceneManager.LoadScene("playscene");
    }
    public void OnClikExit()
    {
        Application.Quit();
    }
    public void OnclikHowplay()
    {
        SceneManager.LoadScene("howplay");
    }
}
