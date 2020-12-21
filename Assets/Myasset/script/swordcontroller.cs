using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordcontroller : MonoBehaviour
{
    [SerializeField] private float finishTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.GetComponent<BoxCollider>().enabled = true;
            Invoke("finishattack",finishTime);
        }
    }
    private void finishattack()
    {
        this.GetComponent<BoxCollider>().enabled = false;
    }
}
