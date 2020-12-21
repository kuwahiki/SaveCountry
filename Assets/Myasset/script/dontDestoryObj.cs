using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dontDestoryObj : MonoBehaviour
{
    public GameObject thisObj;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        if(this.tag == "Player")
        {
            this.gameObject.transform.position = new Vector3(0, 0.8383636f, 0);
        }
    }
    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "gameclear" || SceneManager.GetActiveScene().name == "gameover")
        {
            SceneManager.MoveGameObjectToScene(gameObject, SceneManager.GetActiveScene());
            Destroy(thisObj);
        }
    }
}
