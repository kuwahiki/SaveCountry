using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemnumcontroller : MonoBehaviour
{
    public GameObject PlayerObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Text>().text = PlayerObj.GetComponent<playercontroller>().getPotion().ToString();
    }
}
