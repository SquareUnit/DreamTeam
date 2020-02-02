using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BouttonMenu : MonoBehaviour
{
    //Proprietes 
    public GameObject myMainMenu;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Fait disparaitre le Canvas du Main Menu
    public void PressStart()
    {
        myMainMenu.SetActive(false);
        Debug.Log("Press Start is called");
    }

    public void PressExit()
    {
        Application.Quit();
        Debug.Log("Press exit called");
    }

}
