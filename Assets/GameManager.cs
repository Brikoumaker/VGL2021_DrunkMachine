using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public RectTransform windowParent;
    public Camera sceneCamera;
    public RectTransform breakImage;
    public bool machineHit;
    public GameObject machine;
    public bool unusedCredit;
    public int credits;
    public int points;
    public Text coinsValue;
    public Text pointsValue;
    public Text comboText;
    public Text lineText;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()

    {
        coinsValue.text = credits.ToString() + (" $");
        pointsValue.text = points.ToString() + (" Pts");

        if (Input.GetMouseButtonDown(0))
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

                if (hit.collider.tag == "CoinHitBox" && machine.GetComponent<MachineScript>().onHit == false && machine.GetComponent<MachineScript>().onCoin == false && unusedCredit == false)
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
}
