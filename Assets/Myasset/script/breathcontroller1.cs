using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breathcontroller1 : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("knight");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        if(other.gameObject.tag == "Player")
        {
            player.GetComponent<playercontroller>().hitbreath();
            Debug.Log("hit");
        }
        //Debug.Log("hit");
    }
}
