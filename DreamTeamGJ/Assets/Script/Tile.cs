using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tile : MonoBehaviour
{
    public int id;
    public int state = 0;
    public new Collider collider;

    public bool hasFly = false;
    public bool hasCocoon = false;
    public bool hasNest = false;

    void Start()
    {
        collider = GetComponent<Collider>();
        collider.enabled = state == 0;

        GameManager.instance.eventInteract.AddListener(UpdateInteract);
        GameManager.instance.eventDay.AddListener(UpdateDay);
        GameManager.instance.eventNight.AddListener(UpdateNight);
    }

    public void UpdateInteract()
    {
        collider.enabled = state == 0;

        //Update visuel
    }

    public void UpdateDay()
    {

    }

    public void UpdateNight()
    {

    }
}
