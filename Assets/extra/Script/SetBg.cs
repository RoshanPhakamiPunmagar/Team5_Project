using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBg : MonoBehaviour
{
    [SerializeField] private GameObject cleanBackground;
    [SerializeField] private GameObject cleanerBackground;
    [SerializeField] private GameObject mudBackground;
    private logicManager lm;

    void Start()
    {
        // Find and assign the logicManager script
        lm = FindObjectOfType<logicManager>();

        
        // Set the initial background
        setBackground(mudBackground);
    }

    void Update()
    {  
        // Update background based on trash amount
        changeBg();
    }

    public void changeBg()
    {

        if (lm.trash >= 20f)
        {   
            cleanBackground.SetActive(false);
            setBackground(cleanerBackground);
        }
        else if (lm.trash >= 10f)
        {
            mudBackground.SetActive(false); 
            setBackground(cleanBackground);
        }
        else
        {
            setBackground(mudBackground);
        }
    }

    public void setBackground(GameObject x)
    {
        // Activate the specified background
        x.SetActive(true);
    }
}
