using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showbossHP : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    private int MaxHP, HP;
    // Start is called before the first frame update
    void Start()
    {
        MaxHP = boss.GetComponent<bosscontroller>().getMaxHP();
        HP = boss.GetComponent<bosscontroller>().getHP();
    }

    // Update is called once per frame
    void Update()
    {
        MaxHP = boss.GetComponent<bosscontroller>().getMaxHP();
        HP = boss.GetComponent<bosscontroller>().getHP();
        this.GetComponent<Image>().fillAmount = (float)HP / MaxHP;
    }
}
