using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineScript : MonoBehaviour
{
    public bool onHit;
    public bool onCoin;
    public bool creditInserted;
    public GameObject gameManager;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (creditInserted == true)
        {
            gameManager.GetComponent<GameManager>().unusedCredit = true;
            creditInserted = false;
        }
    }
}
