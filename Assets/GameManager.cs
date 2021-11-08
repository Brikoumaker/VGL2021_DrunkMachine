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
    public float endTime = 6.0f;
    public bool gameFinished;



    // Start is called before the first frame update
    void Start()
    {
        endTime = 7.0f;
    }

    // Update is called once per frame
    void Update()

    {

        if (gameFinished == true && endTime > 0.0f)
        {
            endTime -= Time.deltaTime;
            
        }

        if (endTime < 0.001f && gameFinished == true)
        {
            endScreen.SetActive(true);
        }

        if (infinite == true && gameFinished == false)
        {
            coinsValue.text = ("INFINI $");
            time -= Time.deltaTime;
            timerText.text = ((int)time).ToString();
            if (time < 0.001f)
            {
                gameFinished = true;
                finalScore.text = points.ToString() + (" Pts");
            }

        } else
        {
            coinsValue.text = credits.ToString() + (" $");
        }

        if (credits == 0 && infinite == false)
        {
            infinite = true;
            alert.GetComponent<Animator>().SetTrigger("Alert");
            SoundManager.alarmSound();
            dollar.SetActive(false);
            timer.SetActive(true);
            time = 16.0f;
        }
        
        pointsValue.text = points.ToString() + (" Pts");
        comboText.text = ("COMBO x") + combo.ToString();

        if (Input.GetMouseButtonDown(0) && gameFinished == false)
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
                    machine.GetComponent<Animator>().SetTrigger("MachineHit");
                    SoundManager.smashSound();
                    SoundManager.voiceSound();
                }

                if (hit.collider.tag == "CoinHitBox" && machine.GetComponent<MachineScript>().onHit == false && machine.GetComponent<MachineScript>().onCoin == false && unusedCredit == false && infinite == false)
                {
                    if (credits > 0)
                    {
                        machine.GetComponent<Animator>().SetTrigger("MachineCoin");
                        SoundManager.coinSound();
                        credits--;
                    }
                    
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

}
