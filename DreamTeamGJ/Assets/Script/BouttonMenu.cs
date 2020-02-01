using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BouttonMenu : MonoBehaviour
{
    //Proprietes 
    //public GameObject[] myMenu;
    public GameObject myMainMenu;
    bool isEnable = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnable == false)
        {
            myMainMenu.SetActive(false);
        }
        else
        {
            myMainMenu.SetActive(true);
        }
        // Possibilite : Revenir au main Menu quand la partie est termine. 
    }

    // Fait disparaitre le Canvas du Main Menu
    public void PressStart()
    {
        isEnable = false;

    }

    public void PressExit()
    {
        Application.Quit();
        Debug.Log("Press exit called");
    }

}
