using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public Rigidbody hook;
    public GameObject linkPrefab;
    public int linkQty = 7;
    public List<GameObject> links = new List<GameObject>();
    private float ropeLength;

    void Start()
    {
        GenerateRope();
    }

    void GenerateRope()
    {
        Rigidbody previousRB = hook;
        for(int i = 0; i < linkQty; i++)
        {
            // Instantiate
            GameObject link = Instantiate(linkPrefab, transform);
            link.name = "Link" + i.ToString();
            // Add to array
            links.Add(link);
            // Get comp and connect to previous
            HingeJoint joint = link.GetComponent<HingeJoint>();
            joint.connectedBody = previousRB;
            // Swap previous for next intantiated link
            previousRB = link.GetComponent<Rigidbody>();
        }
    }

    void ResizeRope(float increment) // UNTESTED
    {
        ropeLength = Mathf.Clamp(ropeLength + increment, 0, 1);
        foreach(GameObject i in links)
        {
            i.GetComponent<HingeJoint>().connectedAnchor = new Vector2(0, ropeLength);
        }
    }

}
