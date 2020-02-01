﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float currentTime;
    public bool dayTime;

    public int nestWebPool;
    public int webCount;

    public float dayTransition = 300f;
    public float nightTransition = 120f;

    public int currentDay = 0;

    public void PlayerTakesWeb()
    {
        if (nestWebPool > 0)
        {
            nestWebPool -= 1;

            if (webCount < 4) //if the player has not a full pouch
            {
                webCount += 1;
            }
        }

    }

    public void PlayerStashWeb()
    {
        if (webCount > 0) //if the player has some silk in his pouch
        {
            webCount -= 1;
            nestWebPool += 1;

            if (nestWebPool >= 30) {/*YOU WIN*/}
        }
    }

    public void Update()
    {
        currentTime += Time.deltaTime;


        if(currentTime >= nightTransition && dayTime == true)
        {
            //transition to night here

            currentDay += 1;
            dayTime = false;
            currentTime = 0f;
            if(currentDay >= 6) {/*You lose*/}
        }
        if (currentTime >= dayTransition && dayTime == false)
        {
            //transition to day here
            dayTime = true;
            currentTime = 0f;
        }
    }
}
