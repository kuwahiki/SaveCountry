using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class bosscontroller : MonoBehaviour
{
    [SerializeField] private int MaxHP,attacktime;
    [SerializeField] private GameObject animatorObj;
    [SerializeField] private AudioClip[] audio; //0走る、1攻撃
    [SerializeField] private ParticleSystem[] DieParticles;
    [SerializeField] private Material material;
    private bool breath, attack, die,run,lookplayer;
    private int HP;
    private float speed = 0.0f;
    private NavMeshAgent target;
    private AudioSource audioSource;
    public GameObject player;
    private Vector3 distance;
    private Animator animator;
    private Color bosscolor;

    // Start is called before the first frame update
    void Start()
    {
        breath = false;
        attack = false;
        die = false;
        run = false;
        lookplayer = false;
        animator = animatorObj.GetComponent<Animator>();
        target = this.GetComponent<NavMeshAgent>();
        player = GameObject.Find("knight");
        HP = MaxHP;
        audioSource = this.GetComponent<AudioSource>();
        //player = GameObject.Find("knight");
    }

    // Update is called once per frame
    void Update()
    {
        bosscolor = material.color;
        distance = player.transform.position - this.transform.position;
        if (die == false)
        {
            //戦闘時のボスの挙動
            if (lookplayer == false)
            {
                //rotationToPlayer();
                target.destination = player.transform.position;
            }
            else
            {
                //speed = 0.0f;
            }
            //プレイヤーとの距離が20以上の時は迫ってくる
            if (distance.magnitude >= 20)
            {
                run = true;
                target.speed = 10.0f;
                target.destination = player.transform.position;

            }
            //距離が20未満10以上の時はブレスを吐く
            else if (distance.magnitude >= 10)
            {
                breath = true;
                //target.speed = 0.05f;
            }
            //距離が10未満の時は接近攻撃をする
            else
            {
                attack = true;
                //target.speed = 0.05f;
            }

            if(HP <= 0)
            {
                die = true;
            }
        }
        else
        {
            //ボスの死亡
            target.destination = this.transform.position;
            for (int i = 0; i < DieParticles.Length; i++)
            {
                if (bosscolor.a == 1.0f)
                {
                    DieParticles[i].Play();
                }
            }
            if (bosscolor.a >= 0)
            {
                bosscolor.a *= 0.99f;
                if(bosscolor.a <= 0.1f)
                {
                    Invoke("GameClear", 5.0f);
                    bosscolor.a = 0;
                }
            }
            material.color = bosscolor;
            breath = false;
            attack = false;
            run = false;
        }
        animator.SetBool("breath",breath);
        animator.SetBool("attack",attack);
        animator.SetBool("die",die);
        animator.SetBool("run",run);

        breath = false;
        attack = false;
        run = false;
    }

    public void running()
    {
        target.speed = 10.0f;
    }
    private void GameClear()
    {
        
        SceneManager.LoadScene("gameclear");
        bosscolor.a = 1.0f;
        material.color = bosscolor;
    }
    private void rotationToPlayer()
    {
        //プレイヤーの方向を向く
        Quaternion rotation = Quaternion.LookRotation(distance);
        rotation.x = 0;
        rotation.z = 0;
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, rotation, speed);
        speed += Time.deltaTime;
    }
    public void setLookplayer(bool looking)
    {
        this.lookplayer = looking;
        if(looking == true)
        {
            target.speed = 0.0f;
        }
        else
        {
            target.speed = 1.0f;
        }
    }
    public float getdistance()
    {
        return distance.magnitude;
    }

    public int getMaxHP()
    {
        return MaxHP;
    }
    public int getHP()
    {
        return HP;
    }
    public bool getbools(string boolname)
    {
        switch (boolname)
        {
            case "breath":
                return breath;
                break;
            case "attack":
                return attack;
                break;
            case "die":
                return die;
                break;
            case "run":
                return run;
                break;
            default:
                return false;
                break;
        }

    }

    public void setbools(string boolname,bool trans)
    {
        switch (boolname)
        {
            case "breath":
                this.breath = trans;
                break;
            case "attack":
                this.attack = trans;
                break;
            case "die":
                this.die = trans;
                break;
            case "run":
                this.run = trans;
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "sword")
        {
            this.HP -= 3;
        }
    }
    public void playAudio(int numaudio)
    {
        this.audioSource.clip = audio[numaudio];
        audioSource.Play();

    }
    public void stopAudio()
    {
        this.audioSource.Stop();
    }
}
