using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tile : MonoBehaviour
{
    public int id;
    public int state = 0;
    public Collider collider;
    public SpriteRenderer renderer;
    public Sprite sprite;
    public Sprite brokenSprite;

    public bool hasFly = false;
    public bool hasCocoon = false;
    public bool hasNest = false;

    public int connections = 0;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider>();
        UpdateInteract();
        UpdateSprite();

        GameManager.instance.eventInteract.AddListener(UpdateInteract);
        GameManager.instance.eventDay.AddListener(UpdateDay);
        GameManager.instance.eventNight.AddListener(UpdateNight);
    }

    public void UpdateSprite()
    {
        switch (state)
        {
            case 0:
                renderer.enabled = false;
                break;
            case 1:
                renderer.enabled = true;
                renderer.sprite = brokenSprite;
                break;
            case 2:
                renderer.enabled = true;
                renderer.sprite = sprite;
                break;
        }
    }

    public void CalculateRisk()
    {
        connections = 0;

        int temp = id - 1;
        if (id % 12 == 1)
            connections++;
        else if (TileManager.instance.tileArray[temp].state != 0)
            connections++;

        temp = id + 1;
        if (id % 12 == 0)
            connections++;
        else if (TileManager.instance.tileArray[temp].state != 0)
            connections++;

        temp = id - 12;
        if (id < 13)
            connections++;
        else if (TileManager.instance.tileArray[temp].state != 0)
            connections++;

        temp = id + 12;
        if (id > 71)
            connections++;
        else if (TileManager.instance.tileArray[temp].state != 0)
            connections++;
    }

    public void UpdateInteract()
    {
        collider.isTrigger = state != 0;
        UpdateSprite();
        CalculateRisk();
    }

    public void UpdateDay()
    {

    }

    public void UpdateNight()
    {

    }
}
