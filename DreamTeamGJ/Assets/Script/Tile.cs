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

    public void UpdateInteract()
    {
        collider.isTrigger = state != 0;
        UpdateSprite();
    }

    public void UpdateDay()
    {

    }

    public void UpdateNight()
    {

    }
}
