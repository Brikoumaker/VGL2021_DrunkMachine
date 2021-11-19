using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineManager : MonoBehaviour
{
    public Text lineText;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SoundLine(int lineID)
    {
        if (lineID == 2)
        {
            SoundManager.winSound();
            lineText.text = ("Schwettos !");
        }
        if (lineID == 3)
        {
            SoundManager.winSound();
            lineText.text = ("S1uper !");
        }
        if (lineID == 4)
        {
            SoundManager.winSound();
            lineText.text = ("Cocool coolpa !");
        }
        if (lineID == 5)
        {
            SoundManager.winSound();
            lineText.text = ("Santastique !");
        }
        if (lineID == 6)
        {
            SoundManager.winSound();
            lineText.text = ("Pepsaculaire !");
        }
        if (lineID == 7)
        {
            SoundManager.winbigSound();
            lineText.text = ("Diabète /20 !");
        }
        if (lineID == 8)
        {
            SoundManager.winbigSound();
            lineText.text = ("Atomisant !");
        }
    }

}
