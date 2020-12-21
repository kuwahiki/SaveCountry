using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossVisibility : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    private bool lookplayer;

    private void Start()
    {
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            lookplayer = true;
            boss.GetComponent<bosscontroller>().setLookplayer(lookplayer);
            Debug.Log("visibility");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            lookplayer = false;
            boss.GetComponent<bosscontroller>().setLookplayer(lookplayer);
        }
    }
}
