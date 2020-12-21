using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrollbarcontroller : MonoBehaviour
{
    private Scrollbar scrollbar;
    // Start is called before the first frame update
    void Start()
    {
        scrollbar = this.GetComponent<Scrollbar>();
        scrollbar.value = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
