using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ptargetcontroller : MonoBehaviour
{
    private GameObject target;
    public Transform from = null;
    public float rotationSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("knight");
        this.GetComponent<Transform>().position = target.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        this.GetComponent<Transform>().position = target.GetComponent<Transform>().position;
            
        
    }
}
