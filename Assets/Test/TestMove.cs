using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip boing1;
    public AudioClip boing2;
    public AudioClip boing3;
    int randomInt;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Translate(-0.1f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0.1f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(0.0f, 0f, 0.1f);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(0.0f, 0f, -0.1f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 0.02)
        {
            randomInt = Random.Range(1, 3);
            if (randomInt == 1)
            {
                audioSource.PlayOneShot(boing1);
            }
            else if (randomInt == 2)
            {
                audioSource.PlayOneShot(boing2);
            }
            else if (randomInt == 3)
            {
                audioSource.PlayOneShot(boing3);
            }
        }

    }
}
