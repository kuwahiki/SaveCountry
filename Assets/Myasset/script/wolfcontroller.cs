using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class wolfcontroller : MonoBehaviour
{
    [SerializeField] private int HP;
    [SerializeField] private GameObject thisObj;
    private GameObject attackObj;
    public NavMeshAgent player;
    public GameObject targetP,targetE;
    private Animator animator;
    private int trans;
    private bool alive,attack;

    Vector3 distans;
    void Start()
    {
        player = gameObject.GetComponent<NavMeshAgent>();
        animator = this.GetComponent<Animator>();
        trans = animator.GetInteger("trans");
        alive = true;
        attack = false;
        attackObj = GameObject.Find("WolfAttack");
    }

    void Update()
    {
        if (alive == true)
        {
            if (attack == false)
            {
                player.destination = targetP.transform.position;
            }
            else if (targetE != null && targetE.GetComponent<enemycontroller1>().getalive() == true)
            {
                player.destination = targetE.transform.position;
            }
            else
            {
                player.destination = targetP.transform.position;
            }
        }

        distans = this.GetComponent<Transform>().position - targetP.GetComponent<Transform>().position;
        player.speed = 6;
        trans = 0;
        if (attack == true)
        {
            trans = 3;
            /*if (attackObj.GetComponent<BoxCollider>().enabled == false)
            {
                attack = false;
            }*/
        }
        else {
            if (distans.magnitude <= 2)
            {

                player.speed = 0;
                trans = 2;
            }
            else if (distans.magnitude <= 4)
            {
                player.speed = 2;
                trans = 1;
            }
        }
        animator.SetInteger("trans", trans);
        if (attackObj.GetComponent<BoxCollider>().enabled == false)
        {
            attack = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            attack = true;
            targetE = other.gameObject;
            attackObj.GetComponent<BoxCollider>().enabled = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "enemy")
        {
            attack = true;
            targetE = other.gameObject;
            attackObj.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
