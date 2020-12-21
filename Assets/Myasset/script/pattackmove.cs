using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pattackmove : MonoBehaviour
{
    //Animatoe型を変数animで宣言します。
    private Animator anim;
    bool attack,canattack;
    [SerializeField] private float attacktime;
    int PlayerSP;


    void Start()
    {
        //GetComponentでAnimatorを取得して変数animで参照します。
        anim = GetComponent<Animator>();
        attack = false;
        canattack = true;
        PlayerSP = this.GetComponent<playercontroller>().SP;
    }

    void Update()
    {
        Debug.Log(canattack);
        //もしInputされている０(マウスの左クリック)が押された時の処理。
        int PlayerSP = this.GetComponent<playercontroller>().SP;
        if (Input.GetMouseButtonDown(0))
        {
            //Boolで設定したAttackをtrueにして再生します。
            anim.SetBool("Attack", true);
            if (canattack == false)
            {
                anim.SetBool("Attack", false);
            }
            if (attack == false && canattack == true)
            {
               // PlayerSP -= 50;
                if (PlayerSP <= 0)
                {
                    PlayerSP = 0;
                    canattack = false;
                }
            }
            this.GetComponent<playercontroller>().SP = PlayerSP;
        }
        if(PlayerSP >= 200 && canattack == false)
        {
            canattack = true;
        }
    }
    public void Attack()
    {
        attack = true;
        Invoke("attacking", attacktime);
    }
    void attacking()
    {
        attack = false;
    }
    public bool getattacktime()
    {
        return this.attack;
    }

    public void useSP()
    {
        this.GetComponent<playercontroller>().SP -= 50;
    }

}
