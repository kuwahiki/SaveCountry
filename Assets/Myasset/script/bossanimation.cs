using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossanimation : MonoBehaviour
{
    [SerializeField] GameObject boss,bossbreath;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void bossrun()
    {
        boss.GetComponent<bosscontroller>().running();
    }

    public void bossnotlook()
    {
        boss.GetComponent<bosscontroller>().setLookplayer(true);
    }
    public void bossreturnlook()
    {
        boss.GetComponent<bosscontroller>().setLookplayer(false);
    }

    public void startbreath()
    {
        bossbreath.GetComponent<breathcontroller>().startEffect();
    }

    public void endbreath()
    {
        bossbreath.GetComponent<breathcontroller>().endEffect();
    }
    public void playaudio(int num)
    {
        boss.GetComponent<bosscontroller>().playAudio(num);
    }
    public void stopaudio()
    {
        boss.GetComponent<bosscontroller>().stopAudio();
    }
}
