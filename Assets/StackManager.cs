using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StackManager : MonoBehaviour
{
    public GameObject prefab;
    public GameObject alternativePrefab;
    Vector3 stackPos;
    float firstPrefabPosZ;
    float maxPrefabPosZ;
    GameObject[] prefabs;
    int index = 0;
    public string key;
    public bool translation;
    public GameObject gameManager;
    public Text keyChara;
    public bool animationRunning;
    int callShowKeyBuffer = 0;
    public Animator Stack;

    // Start is called before the first frame update
    void Start()
    {
        stackPos = transform.position;
        maxPrefabPosZ = 9 + stackPos.z;
        prefabs = new GameObject[50];
        prefabs[0] = Instantiate(prefab, new Vector3(0, 0, 6) + stackPos, Quaternion.identity);
        prefabs[0].transform.parent = transform;
        prefabs[1] = Instantiate(prefab, new Vector3(0, 0, 2) + stackPos, Quaternion.identity);
        prefabs[1].transform.parent = transform;
        prefabs[2] = Instantiate(prefab, new Vector3(0, 0, -2) + stackPos, Quaternion.identity);
        prefabs[2].transform.parent = transform;
        prefabs[3] = Instantiate(prefab, new Vector3(0, 0, -6) + stackPos, Quaternion.identity);
        prefabs[3].transform.parent = transform;
        translation = false;
        keyChara.text = key;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key) && gameManager.GetComponent<GameManager>().gameFinished == false)
        {
            if (translation == false)
            {
                if (gameManager.GetComponent<GameManager>().unusedCredit == true || gameManager.GetComponent<GameManager>().infinite == true)
                {
                    translation = true;
                    SoundManager.stackSound();
                    gameManager.GetComponent<GameManager>().unusedCredit = false;
                }
                else
                {
                    SoundManager.buzzerSound();
                    gameManager.GetComponent<GameManager>().ShowDollar();
                }
                
            }
            

        }

        if (translation == true)
        {
            firstPrefabPosZ = prefabs[index].transform.position.z;
            if (firstPrefabPosZ < maxPrefabPosZ)
            {
                prefabs[index].transform.Translate(Vector3.forward * Time.deltaTime * 5);
                prefabs[index + 1].transform.Translate(Vector3.forward * Time.deltaTime * 5);
                prefabs[index + 2].transform.Translate(Vector3.forward * Time.deltaTime * 5);
                prefabs[index + 3].transform.Translate(Vector3.forward * Time.deltaTime * 5);
            } else
            {
                prefabs[index].GetComponent<PropManager>().EnableRigidBody();
                prefabs[index].transform.parent = null;
                index += 1;
                int random = Random.Range(0, 20);
                if (random == 0)
                {
                    prefabs[index + 3] = Instantiate(alternativePrefab, new Vector3(0, 0, -6) + stackPos, Quaternion.identity) as GameObject;
                } else
                {
                    prefabs[index + 3] = Instantiate(prefab, new Vector3(0, 0, -6) + stackPos, Quaternion.identity) as GameObject;
                }
                prefabs[index + 3].transform.parent = transform;

                translation = false;
            }
        }

        if (callShowKeyBuffer != gameManager.GetComponent<GameManager>().callShowKey)
        {
            callShowKeyBuffer = gameManager.GetComponent<GameManager>().callShowKey;
            if (animationRunning == false)
            {
                Stack.SetTrigger("showKey");
            }
        }

    }
}
