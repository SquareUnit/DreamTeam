using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int webCount;
    public float currenttime;

    public int nestWebPool;
    public int playerWebPool;


    public void PlayerTakesWeb()
    {
        if(nestWebPool > 0)
        { 
        nestWebPool -=1;

            if (webCount < 4) //if the player has not a full pouch
            {
            webCount +=1;
            }
        }
        
    }

    public void PlayerStashWeb()
    {
        if (webCount > 0) //if the player has some silk in his pouch
            {
            webCount -=1;
            nestWebPool +=1;

            if (nestWebPool == 30) {/*YOU WIN*/}
            }
        }
    


}
