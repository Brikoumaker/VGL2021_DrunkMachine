using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip coin;
    public static AudioClip button;
    public static AudioClip[] can;
    public static AudioClip[] bottle;
    public static AudioClip[] sand;
    public static AudioClip[] smash;
    public static AudioClip stack;
    public static AudioClip buzzer;
    public static AudioClip win;
    public static AudioClip winbig;
    public static AudioClip combo;
    public static AudioClip[] success;
    public static AudioClip[] toy;
    public static AudioClip[] voice;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        coin = Resources.Load<AudioClip>("coin");
        button = Resources.Load<AudioClip>("button");
        stack = Resources.Load<AudioClip>("stack");
        buzzer = Resources.Load<AudioClip>("buzzer");
        win = Resources.Load<AudioClip>("win");
        winbig = Resources.Load<AudioClip>("winbig");
        combo = Resources.Load<AudioClip>("combo");
        can = new AudioClip[6];
        can[1] = Resources.Load<AudioClip>("can1");
        can[2] = Resources.Load<AudioClip>("can2");
        can[3] = Resources.Load<AudioClip>("can3");
        can[4] = Resources.Load<AudioClip>("can4");
        can[5] = Resources.Load<AudioClip>("can5");
        bottle = new AudioClip[6];
        bottle[1] = Resources.Load<AudioClip>("bottle1");
        bottle[2] = Resources.Load<AudioClip>("bottle2");
        bottle[3] = Resources.Load<AudioClip>("bottle3");
        bottle[4] = Resources.Load<AudioClip>("bottle4");
        bottle[5] = Resources.Load<AudioClip>("bottle5");
        sand = new AudioClip[6];
        sand[1] = Resources.Load<AudioClip>("sand1");
        sand[2] = Resources.Load<AudioClip>("sand2");
        sand[3] = Resources.Load<AudioClip>("sand3");
        sand[4] = Resources.Load<AudioClip>("sand4");
        sand[5] = Resources.Load<AudioClip>("sand5");
        smash = new AudioClip[6];
        smash[1] = Resources.Load<AudioClip>("smash1");
        smash[2] = Resources.Load<AudioClip>("smash2");
        smash[3] = Resources.Load<AudioClip>("smash3");
        smash[4] = Resources.Load<AudioClip>("smash4");
        smash[5] = Resources.Load<AudioClip>("smash5");
        success = new AudioClip[4];
        success[1] = Resources.Load<AudioClip>("success1");
        success[2] = Resources.Load<AudioClip>("success2");
        success[3] = Resources.Load<AudioClip>("success3");
        toy = new AudioClip[6];
        toy[1] = Resources.Load<AudioClip>("toy1");
        toy[2] = Resources.Load<AudioClip>("toy2");
        toy[3] = Resources.Load<AudioClip>("toy3");
        toy[4] = Resources.Load<AudioClip>("toy4");
        toy[5] = Resources.Load<AudioClip>("toy5");
        voice = new AudioClip[6];
        voice[1] = Resources.Load<AudioClip>("voice1");
        voice[2] = Resources.Load<AudioClip>("voice2");
        voice[3] = Resources.Load<AudioClip>("voice3");
        voice[4] = Resources.Load<AudioClip>("voice4");
        voice[5] = Resources.Load<AudioClip>("voice5");
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void coinSound()
    {
        audioSrc.PlayOneShot(coin);
    }

    public static void buttonSound()
    {
        audioSrc.PlayOneShot(button);
    }

    public static void buzzerSound()
    {
        audioSrc.PlayOneShot(buzzer);
    }

    public static void winSound()
    {
        audioSrc.PlayOneShot(win);
    }

    public static void winbigSound()
    {
        audioSrc.PlayOneShot(winbig);
    }

    public static void comboSound()
    {
        audioSrc.PlayOneShot(combo);
    }

    public static void canSound()
    {
        int random = Random.Range(1, 5);
        audioSrc.PlayOneShot(can[random]);
    }

    public static void stackSound()
    {
        audioSrc.PlayOneShot(stack);
    }

    public static void bottleSound()
    {
        int random = Random.Range(1, 5);
        audioSrc.PlayOneShot(bottle[random]);
    }
    public static void sandSound()
    {
        int random = Random.Range(1, 5);
        audioSrc.PlayOneShot(sand[random]);
    }

    public static void smashSound()
    {
        int random = Random.Range(1, 5);
        audioSrc.PlayOneShot(smash[random]);
    }

    public static void successSound()
    {
        int random = Random.Range(1, 3);
        audioSrc.PlayOneShot(success[random]);
    }
    public static void toySound()
    {
        int random = Random.Range(1, 5);
        audioSrc.PlayOneShot(toy[random]);
    }

    public static void voiceSound()
    {
        int random = Random.Range(1, 5);
        audioSrc.PlayOneShot(voice[random]);
    }


}
