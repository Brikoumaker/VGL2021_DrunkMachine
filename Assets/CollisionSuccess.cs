using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSuccess : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject pointsText;
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
        Destroy(collision.gameObject.transform.parent.gameObject);
        SoundManager.successSound();
        gameManager.GetComponent<GameManager>().points += 10;
        pointsText.GetComponent<Animator>().SetTrigger("Shake");
    }
}
