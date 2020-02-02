using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{

    public Rigidbody2D hook;
    public GameObject linkPrefab;
    public int linkQty = 7;
    public GameObject[] links;
    public float ropeLength;

    void Start()
    {
        GenerateRope();
    }

    void GenerateRope()
    {
        Rigidbody2D previousRB = hook;
        for(int i = 0; i < linkQty; i++)
        {
            if(i == linkQty - 1)
            {
                // Spider ribigbody2D = previousRB
            }
            else
            {
                // Instatiate
                GameObject link = Instantiate(linkPrefab, transform);
                // Add to array
                links[i] = link;
                // Get comp and connect to previous
                HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
                joint.connectedBody = previousRB;
                // Swap previous for next intantiated link
                previousRB = link.GetComponent<Rigidbody2D>();
            }
        }
    }

    void ResizeRope(float increment)
    {
        ropeLength = Mathf.Clamp(ropeLength + increment, 0, 1);
        foreach(GameObject i in links)
        {
            i.GetComponent<HingeJoint2D>().connectedAnchor = new Vector2(0, ropeLength);
        }
    }

}
