using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zomibespown : MonoBehaviour
{
    [SerializeField]private GameObject zombie;
    private GameObject player,Zombie;
    [SerializeField]private float time;
    private float counter;
    private int num = 2;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("knight");
        Zombie = GameObject.Find("Zombie");
        counter = time;
    }

    // Update is called once per frame
    void Update()
    {
        if(counter <= 0 && num >= 0)
        {
            spown();
        }
        else
        {
            counter -= Time.deltaTime;
        }

    }

    private void spown()
    {
        counter = time;
        num--;
        Instantiate(zombie, this.transform.position,Quaternion.identity);
        Zombie.GetComponent<enemycontroller1>().target = player;
    }
}
