using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionSuccess : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject pointsText;
    public GameObject comboText;
    public GameObject Line;
    public float time = 0.0f;
    public int combo;
    public bool inCombo;
    public Text lineText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0.0f)
        {
            time -= Time.deltaTime;
        } else
        {
            if (inCombo == true)
            {
                inCombo = false;
                if (combo == 2)
                {
                    gameManager.GetComponent<GameManager>().points += 100;
                    SoundManager.winSound();
                    lineText.text = ("Schwettos !");
                    Line.GetComponent<Animator>().SetTrigger("Line2");
                }
                if (combo == 3)
                {
                    gameManager.GetComponent<GameManager>().points += 300;
                    SoundManager.winSound();
                    lineText.text = ("S1uper !");
                    Line.GetComponent<Animator>().SetTrigger("Line3");
                }
                if (combo == 4)
                {
                    gameManager.GetComponent<GameManager>().points += 500;
                    SoundManager.winSound();
                    lineText.text = ("Cocool coolpa !");
                    Line.GetComponent<Animator>().SetTrigger("Line4");
                }
                if (combo == 5)
                {
                    gameManager.GetComponent<GameManager>().points += 1000;
                    SoundManager.winSound();
                    lineText.text = ("Santastique !");
                    Line.GetComponent<Animator>().SetTrigger("Line5");
                }
                if (combo == 6)
                {
                    gameManager.GetComponent<GameManager>().points += 3000;
                    SoundManager.winSound();
                    lineText.text = ("Pepsaculaire !");
                    Line.GetComponent<Animator>().SetTrigger("Line6");
                }
                if (combo > 6)
                {
                    gameManager.GetComponent<GameManager>().points += 5000;
                    gameManager.GetComponent<GameManager>().points += 500*combo;
                    SoundManager.winbigSound();
                    lineText.text = ("Diabète /20 !");
                    Line.GetComponent<Animator>().SetTrigger("Line7");
                }
                comboText.SetActive(false);
                combo = 1;
                gameManager.GetComponent<GameManager>().combo = combo;
            }
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (time < 1.99f)
        {
            

            if (inCombo == true && time > 0.0f)
            {
                combo += 1;
                if (combo > 1)
                {
                    comboText.SetActive(true);
                    SoundManager.comboSound();
                    gameManager.GetComponent<GameManager>().combo = combo;
                }

            }

            if (collision.gameObject.transform.parent.tag == "Ato")
            {
                gameManager.GetComponent<GameManager>().points += 5000;
                SoundManager.winbigSound();
                lineText.text = ("Atomisant !");
                Line.GetComponent<Animator>().SetTrigger("Line8");
            }

            Destroy(collision.gameObject.transform.parent.gameObject);
            SoundManager.successSound();
            gameManager.GetComponent<GameManager>().points += 10;
            pointsText.GetComponent<Animator>().SetTrigger("Shake");
            time = 2.0f;
            inCombo = true;

            
        }
    }
}
