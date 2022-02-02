using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public RectTransform windowParent;
    public Camera sceneCamera;
    public RectTransform breakImage;
    public bool machineHit;
    public GameObject machine;
    public GameObject alert;
    public GameObject dollar;
    public GameObject timer;
    public GameObject endScreen;
    public GameObject panel;
    public bool unusedCredit;
    public int credits;
    public int points;
    public int combo;
    public Text coinsValue;
    public Text pointsValue;
    public Text comboText;
    public Text lineText;
    public Text timerText;
    public Text finalScore;
    public bool infinite;
    public float time = 0.0f;
    public float endTime = 14.0f;
    public bool gameFinished;
    public int callShowKey = 0;
    public bool lastCoin;
    public int timesound = 4;
    public float scoreAnimation;
    public bool animationActive = false;
    public float animationTime = 0.0f;
    public bool finalFinal;
    public bool gameActive = true;



    // Start is called before the first frame update
    void Start()
    {
        endTime = 14.0f;
        Time.timeScale = 2.0f;
    }

    // Update is called once per frame
    void Update()

    {

        if (gameFinished == true && endTime > 0.0f)
        {
            endTime -= Time.deltaTime;
            
        }

        if (endTime < 0.001f && gameFinished == true && animationActive == false)
        {
            endScreen.SetActive(true);
            animationActive = true;
            SoundManager.finalscoreSound();
            
        }

        if (animationActive == true && finalFinal == false)
        {
            animationTime += Time.deltaTime;
            scoreAnimation = points * (animationTime /6.0f);
            finalScore.text = Mathf.Round(scoreAnimation).ToString() + (" Pts");

            if (scoreAnimation >= points)
            {
                finalFinal = true;
                finalScore.text = points.ToString() + (" Pts");
                SoundManager.victorySound();
            }


        }

        if (infinite == true && gameFinished == false)
        {
            coinsValue.text = ("INFINI $");
            time -= Time.deltaTime;
            timerText.text = ((int)(time/2)).ToString();

            if(time < 8.0f && timesound == 4)
            {
                SoundManager.clockSound();
                timesound = 3;

            }

            if (time < 6.0f && timesound == 3)
            {
                SoundManager.clockSound();
                timesound = 2;

            }

            if (time < 4.0f && timesound == 2)
            {
                SoundManager.clockSound();
                timesound = 1;

            }

            if (time < 2.0f && timesound == 1)
            {
                SoundManager.whistleSound();
                timesound = 0;

            }

            if (time < 0.001f)
            {
                gameFinished = true;
                
            }

        } else
        {
            coinsValue.text = credits.ToString() + (" $");
        }

        if (lastCoin == true && infinite == false)
        {
            infinite = true;
            alert.GetComponent<Animator>().SetTrigger("Alert");
            SoundManager.alarmSound();
            dollar.SetActive(false);
            timer.SetActive(true);
            time = 22.0f;
        }
        
        pointsValue.text = points.ToString() + (" Pts");
        comboText.text = ("COMBO x") + combo.ToString();

        if (Input.GetMouseButtonDown(0) && gameFinished == false && gameActive == true)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.tag == "WindowHitBox")
                {
                    Vector2 anchoredPos;
                    RectTransformUtility.ScreenPointToLocalPointInRectangle(windowParent, Input.mousePosition, sceneCamera, out anchoredPos);
                    breakImage.anchoredPosition = new Vector2(anchoredPos.x + 5, anchoredPos.y + 5);
                    breakImage.transform.eulerAngles = new Vector3(0, 0, Random.Range(0, 360));
                    machine.GetComponent<Animator>().SetTrigger("MachineHit");
                    SoundManager.smashSound();
                    SoundManager.voiceSound();
                }

                if (hit.collider.tag == "CoinHitBox")
                {

                    InsertCoin();
                    
                    
                }

                if (hit.collider.tag == "ButtonsHitBox")
                {

                    callShowKey += 1;
                    SoundManager.buttonSound();


                }
            }
            
        }
    }

    public void ShowDollar()
    {
        dollar.GetComponent<Animator>().SetTrigger("Show");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Machine");
    }

    public void InsertCoin()
    {

        if (machine.GetComponent<MachineScript>().onHit == false && machine.GetComponent<MachineScript>().onCoin == false && gameActive == true)
        {
            if (unusedCredit == false && infinite == false)
            {
                if (credits > 0)
                {
                    machine.GetComponent<Animator>().SetTrigger("MachineCoin");
                    SoundManager.coinSound();
                    credits--;
                }
            } else
            {
                callShowKey += 1;
                SoundManager.buttonSound();
            }
        }
        
    }

    public void ShowInstructions()
    {
        if (panel.GetComponent<Animator>().GetBool("InfoButtonActive") == true)
        {
            panel.GetComponent<Animator>().SetBool("InfoButtonActive", false);
            gameActive = true;
        }
        else
        {
            panel.GetComponent<Animator>().SetBool("InfoButtonActive", true);
            gameActive = false;
        }
        
    }

    public void HideInstructions()
    {
        panel.GetComponent<Animator>().SetBool("InfoButtonActive", false);
        gameActive = true;
    }

}
