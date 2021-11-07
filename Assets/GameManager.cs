using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public RectTransform windowParent;
    public Camera sceneCamera;
    public RectTransform breakImage;
    public bool machineHit;
    public GameObject machine;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.tag == "WindowHitBox")
                {
                    Debug.Log("---> Hit: ");
                    Vector2 anchoredPos;
                    RectTransformUtility.ScreenPointToLocalPointInRectangle(windowParent, Input.mousePosition, sceneCamera, out anchoredPos);
                    breakImage.anchoredPosition = new Vector2(anchoredPos.x + 5, anchoredPos.y + 5);
                    machine.GetComponent<Animator>().SetTrigger("MachineHit");
                    SoundManager.smashSound();
                    SoundManager.voiceSound();
                }
            }
            
        }
    }
}
