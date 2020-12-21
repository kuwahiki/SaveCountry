using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontroller : MonoBehaviour
{
    [SerializeField]private int MaxHP,potion,MaxSP,zombiedamege,dragondamege,breathdamege;
    [SerializeField] private GameObject[] hiteffect = new GameObject[2];
    [SerializeField] private AudioClip[] Audio = new AudioClip[6];//0走る、１歩く、２死亡、３回復、４攻撃、５ダメージ
    [SerializeField] private float damegeTime,ignoreTime;
    [SerializeField] private GameObject healeffect,camera;
    private Animator animator;
    private AudioSource audioSource;
    int trans, front, Sprint, attack, block,die,HP;
    public int SP;
    float rotatospeed;
    bool Attack,alive,cansprint,damegeignore;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = this.GetComponent<Animator>();
        trans = this.animator.GetInteger("trans");
        Attack = this.animator.GetBool("Attack");
        audioSource = this.GetComponent<AudioSource>();
        HP = MaxHP;
        SP = MaxSP;
        front = 1;
        Sprint = 2;
        attack = 3;
        block = 4;
        die = 6;
        rotatospeed = 1.0f;
        alive = true;
        cansprint = true;
        this.GetComponent<Transform>().localPosition = new Vector3(0, -0.8383636f,0);
        if(SceneManager.GetActiveScene().name == "bossscene")
        {
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "bossscene")
        {
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        }
        if (alive == true)
        {
            switch (trans)
            {
                case 0:
                    rotatospeed = 10;
                    break;
                case 1:
                    rotatospeed = 1;
                    break;
                case 2:
                    rotatospeed = 3;
                    break;
                default:
                    break;
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                //ポーションの使用
                usePotion();
            }
            if (Input.GetMouseButton(0))
            {
                //playAudio(4);
            }
            else if (Input.GetMouseButton(1))
            {
                this.trans = block;
            }
            else if (Input.GetKey(KeyCode.W))
            {
                this.trans = front;
                if (Input.GetKey(KeyCode.LeftShift) && cansprint == true)
                {
                    this.trans = Sprint;
                   // playAudio(0);
                }
                else
                {
                    //playAudio(1);
                }
            }
            else
            {
                
                this.trans = 0;
                if(audioSource.clip == Audio[0] || audioSource.clip == Audio[1])
                {
                    audioSource.Stop();
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (Time.timeScale == 1.0f)
                {
                    Time.timeScale = 0.0f;
                }
                else
                {
                    Time.timeScale = 1.0f;
                }
            }
            //this.GetComponent<Transform>().position = playerModel.GetComponent<Transform>().position;
            if (Input.GetKey(KeyCode.A))
            {
                this.GetComponent<Transform>().Rotate(0, -rotatospeed, 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                this.GetComponent<Transform>().Rotate(0, rotatospeed, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                //後ろを向く
                this.transform.rotation =
                   Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y - 180.0f, this.transform.rotation.z);
            }
            //スタミナの回復
            if(trans == Sprint)
            {
                SP --;
            }
            else {
                if (this.GetComponent<pattackmove>().getattacktime() == false && this.trans != block)
                {
                    SP += 2;
                }
                if(SP >= MaxSP)
                {
                    SP = MaxSP;
                }
            }
            //ダッシュできるかの判断
            if(SP == 0)
            {
                cansprint = false;
            }
            if(SP >= 200)
            {
                cansprint = true;
            }
        }
        //プレイヤーの死亡
        if(HP <= 0)
        {
            alive = false;
            trans = die;
            Invoke("gameover", 3.0f);
            playAudio(2);
        }

        animator.SetInteger("trans", trans);
        
    }

    public void playAudio(int numaudio)
    {
        audioSource.clip = this.Audio[numaudio];
            audioSource.Play();
    }

    public int getTrans()
    {
        return this.trans;
    }
    public bool getAttack()
    {
        return this.Attack;
    }
   
    private void OnTriggerEnter(Collider other)
    {
        //プレイヤーのダメージ
        if (alive == true && damegeignore == false)
        {
            switch (other.gameObject.tag)
            {
                case "zombieattack":
                    damege(other,zombiedamege);
                    break;
                case "boss_hand":
                    damege(other,dragondamege);
                    break;
                default:
                    break;
            }
        }
        //ボス画面への移行
        if (other.gameObject.tag == "gorl")
        {
            SceneManager.LoadScene("bossscene");
            this.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void damege(Collider other,int damege)
    {
        if (trans == block)
        {
            //ガードしている時
            this.transform.LookAt(other.gameObject.transform);
            //ガードしたオブジェクトに向かせる
            Vector3 rilativePos = other.gameObject.transform.position - this.transform.position;
            Quaternion rotation = Quaternion.LookRotation(rilativePos);
            rotation.x = 0;
            rotation.z = 0;
            rotation.y += 1.0f;
            transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, 10.0f);
            if (SP >= 0)
            {

                this.SP -= 30;
            }
            else
            {
                getdamege(1);
            }
            damegeignore = true;
            Invoke("invincible", ignoreTime);
        }
        else
        {
            //ガードしてない時
            getdamege(damege);
            damegeignore = true;
            Invoke("invincible", ignoreTime);
        }
    }

    private void getdamege(int damege)
    {
        this.HP -= damege;
        //playAudio(5);
        animator.SetBool("damege", true);
        Invoke("hitEattack", 0.1f);
        Debug.Log("damege");
        if (alive == true)
        {
            for (int i = 0; i < hiteffect.Length; i++)
            {
                hiteffect[i].GetComponent<ParticleSystem>().Play();
            }
        }
    }
    private void gameover()
    {
        SceneManager.LoadScene("gameover");
    }
    private void usePotion()
    {
        if (potion > 0 && HP != MaxHP)
        {
            Instantiate(healeffect,this.transform.position, Quaternion.Euler(-90,0,0));
            potion--;
            HP += 50;
            if (HP >= MaxHP)
            {
                HP = MaxHP;
            }
        }
    }
    private void hitEattack()
    {
        animator.SetBool("damege", false);
    }
    private void invincible()
    {
        this.damegeignore = false;
    }
    public void hitbreath()
    {
        if (alive == true && damegeignore == false)
        {
            if (trans == block)
            {
                //ガードしている時
                if (SP >= 0)
                {

                    this.SP -= 30;
                }
                else
                {
                    getdamege(breathdamege);
                }
                damegeignore = true;
                Invoke("invincible", ignoreTime);
            }
            else
            {
                //ガードしてない時
                getdamege(breathdamege);
                damegeignore = true;
                Invoke("invincible", ignoreTime);
            }
        }
    }
    public int getHP()
    {
        return this.HP;
    }
    public int getMaxHP()
    {
        return this.MaxHP;
    }
    public int getSP()
    {
        return this.SP;
    }
    public int getMaxSP()
    {
        return this.MaxSP;
    }
    public int getPotion()
    {
        return this.potion;
    }
}
