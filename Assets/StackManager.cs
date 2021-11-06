using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    public GameObject prefab;
    Vector3 stackPos;
    float firstPrefabPosZ;
    float maxPrefabPosZ;
    GameObject[] prefabs;
    int index = 0;
    public string key;
    public bool translation;

    // Start is called before the first frame update
    void Start()
    {
        stackPos = transform.position;
        maxPrefabPosZ = 9 + stackPos.z;
        prefabs = new GameObject[100];
        prefabs[0] = Instantiate(prefab, new Vector3(0, 0, 6) + stackPos, Quaternion.identity);
        prefabs[1] = Instantiate(prefab, new Vector3(0, 0, 2) + stackPos, Quaternion.identity);
        prefabs[2] = Instantiate(prefab, new Vector3(0, 0, -2) + stackPos, Quaternion.identity);
        prefabs[3] = Instantiate(prefab, new Vector3(0, 0, -6) + stackPos, Quaternion.identity);
        translation = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            translation = true;

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
                index += 1;
                //prefabs = new GameObject[prefabs.Length + 1];
                prefabs[index + 3] = Instantiate(prefab, new Vector3(0, 0, -6) + stackPos, Quaternion.identity) as GameObject;
                translation = false;
            }
        }

    }
}
