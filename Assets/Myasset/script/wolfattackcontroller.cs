using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfattackcontroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        this.GetComponent<BoxCollider>().enabled = false;
        Debug.Log("hit");
    }
    private void OnTriggerStay(Collider other)
    {
        this.GetComponent<BoxCollider>().enabled = false;
        Debug.Log("hit");
    }
}
