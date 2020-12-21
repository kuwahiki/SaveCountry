using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SPbarcontroller : MonoBehaviour
{
    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Image>().fillAmount =
            (float)player.GetComponent<playercontroller>().getSP() / player.GetComponent<playercontroller>().getMaxSP();
    }
}
