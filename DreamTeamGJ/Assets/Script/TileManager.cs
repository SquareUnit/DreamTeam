using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public static TileManager instance;
    public Tile tile;
    public int width = 5;
    public int length = 5;
    public float tileSize = 1;
    public GameObject[,] tileIndex;
    private int count = 0;
    public Tile[] tileArray = new Tile[85];
    public Sprite[] spriteArray;
    public Sprite[] brokenSpriteArray;

    void Start()
    {
        instance = this;

        tileIndex = new GameObject[width, length];
        GenerateTiles(tileIndex);


        //Assign starting values (toile, durabilite, risque, etc)
        tileArray[1].state = 2;
        tileArray[2].state = 2;
        tileArray[3].state = 2;
        tileArray[11].state = 1;
        tileArray[12].state = 2;
        tileArray[12].hasFly = true;
        tileArray[13].state = 2;
        tileArray[14].state = 2;
        tileArray[25].state = 2;
        tileArray[28].state = 2;
        tileArray[28].hasCocoon = true;
        tileArray[29].state = 1;
        tileArray[40].state = 1;
        tileArray[41].state = 2;
        tileArray[45].state = 2;
        tileArray[56].state = 2;
        tileArray[57].state = 2;
        tileArray[58].state = 1;
        tileArray[69].state = 1;
    }

    private void GenerateTiles(GameObject[,] array)
    {
        int i = 0;
        int j = 0;

        while (j < array.GetLength(1))
        {
            count++;
            GameObject temp = Instantiate(tile.gameObject, new Vector3(tileSize * i, 0f, -tileSize * j), Quaternion.Euler(270f,0f,0f), this.transform);
            Tile tempTile = temp.GetComponent<Tile>();
            tempTile.id = count;
            tempTile.sprite = spriteArray[count - 1];
            tempTile.brokenSprite = brokenSpriteArray[count - 1];
            tileArray[count] = tempTile;

            i++;
            if (i > width)
            {
                i = 0;
                j++;
            }

        }

    }
}
