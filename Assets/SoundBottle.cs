using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBottle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (GetComponentInParent<PropManager>().falling == true)
        {
            SoundManager.bottleSound();
        }


    }
}
