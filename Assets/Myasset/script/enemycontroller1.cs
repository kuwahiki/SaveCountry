using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemycontroller1 : MonoBehaviour
{
    [SerializeField] private int HP;
    [SerializeField] private GameObject thisObj;
    [SerializeField] private AudioClip[] audio = new AudioClip[2];
    [SerializeField] private Transform[] points;
    [SerializeField] private GameObject[] hiteffect = new GameObject[2];
    public NavMeshAgent player;
    public GameObject target;
    public GameObject attack;
    private Animator animator;
    private AudioSource audioSource;
    private int trans,nowpoint;
    private bool alive,chase;
    private Vector3 distans,pointdis;
    void Start()
    {
        player = gameObject.GetComponent<NavMeshAgent>();
        animator = this.GetComponent<Animator>();
        trans = animator.GetInteger("trans");
        //attack = GameObject.Find("attack");
        alive = true;
        chase = false;
        nowpoint = 0;
        audioSource = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        if(target == null)
        {
            Destroy(thisObj);
        }
        distans = this.GetComponent<Transform>().position - target.GetComponent<Transform>().position;
        pointdis = this.GetComponent<Transform>().position - points[nowpoint].position;

        /*if (target != null && alive == true)
        {
            player.destination = target.transform.position;
        }*/
        if (distans.magnitude <= 10)
        {

            if (target != null && alive == true)
            {
                player.destination = target.transform.position;
                chase = true;
            }
        }
        else
        {
            if(alive == true)
            player.destination = points[nowpoint].transform.position;
            chase = false;
        }

        setnewpoint();

        if (HP > 0)
        {
            if (distans.magnitude <= 1)
            {
                this.trans = 2;
                attack.GetComponent<BoxCollider>().enabled = true;
                Invoke("ColliderReset", 0.5f);
                playAudio(1);
            }
            else if (distans.magnitude <= 5)
            {
                this.trans = 1;
                playAudio(0);
            }
            else
            {
                this.trans = 0;
                playAudio(0);

            }
        }
        else
        {
            //敵の死亡
            this.trans = 3;
            player.enabled = false;
            alive = false;
            audioSource.Stop();
        }

        if(chase == false)
        {
            trans = 1;
        }
        animator.SetInteger("trans", trans);

        if (alive == false)
        {
            Invoke("thisdestroy", 5.0f);
        }

    }
    public void playAudio(int numaudio)
    {
        audioSource.clip = this.audio[numaudio];
        if (audioSource.isPlaying == false)
        {
            audioSource.Play();
        }
    }

    private void setnewpoint()
    {
        if (pointdis.magnitude <= 1)
        {
            if (nowpoint < points.Length -1)
            {
                nowpoint++;
            }
            else
            {
                nowpoint = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "sword")
        {
            this.HP--;
            playhiteffect();
        }
        if (other.gameObject.tag == "wolfattack")
        {
            this.HP--;
            playhiteffect();
        }
    }

    private void playhiteffect()
    {
        Debug.Log("hit");
        if (alive == true)
        {
            for (int i = 0; i < hiteffect.Length; i++)
            {
                hiteffect[i].GetComponent<ParticleSystem>().Play();
            }
        }
    }

    private void ColliderReset()
    {
        attack.GetComponent<BoxCollider>().enabled = false;
    }
    private void thisdestroy()
    {
        Destroy(thisObj);
    }

    public bool getalive()
    {
        return alive;
    }
}
