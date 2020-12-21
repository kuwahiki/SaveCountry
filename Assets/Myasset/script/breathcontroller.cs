using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breathcontroller : MonoBehaviour
{
    [SerializeField] private GameObject[] breatheffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startEffect()
    {
        for(int i = 0;i < breatheffect.Length; i++)
        {
            this.breatheffect[i].GetComponent<ParticleSystem>().Play();
            Debug.Log("start");
        }
    }
    public void endEffect()
    {
        for (int i = 0; i < breatheffect.Length; i++)
        {
            this.breatheffect[i].GetComponent<ParticleSystem>().Stop();
            Debug.Log("end");
        }
    }
}
