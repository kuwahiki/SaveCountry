using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPbarcomtroller : MonoBehaviour
{
    [SerializeField] GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Image>().fillAmount =
           (float) player.GetComponent<playercontroller>().getHP() / player.GetComponent<playercontroller>().getMaxHP();
    }
}
