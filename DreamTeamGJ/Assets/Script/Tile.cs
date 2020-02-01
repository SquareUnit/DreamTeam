using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int id;
    public int state = 0;
    public new Collider collider;

    void Start()
    {
        collider = GetComponent<Collider>();
        collider.enabled = state == 0;
    }

}
