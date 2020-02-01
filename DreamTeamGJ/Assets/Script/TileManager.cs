using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public Tile tile;
    public int width = 5;
    public int length = 5;
    public float tileSize = 1;
    public GameObject[,] tileIndex;
    private int count = 0;
    public Tile[] tileArray = new Tile[85];

    void Start()
    {
        tileIndex = new GameObject[width, length];
        GenerateTiles(tileIndex);


        //Assign starting values (toile, durabilite, risque, etc)
        tileArray[1].state = 2;
        tileArray[2].state = 2;
        tileArray[8].state = 2;
    }

    private void GenerateTiles(GameObject[,] array)
    {
        int i = 0;
        int j = 0;

        while (j < array.GetLength(1))
        {
            count++;
            GameObject temp = Instantiate(tile.gameObject, new Vector3(tileSize * i, 0.5f, tileSize * j), Quaternion.identity);
            temp.GetComponent<Tile>().id = count;
            tileArray[count] = temp.GetComponent<Tile>();

            i++;
            if (i > width)
            {
                i = 0;
                j++;
            }

        }

    }
}
