using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Avatar : MonoBehaviour
{
    public InputMaster controls;
    private Transform tr;
    public GameObject ropePrefab;

    private GameObject[] test;

    private float wKey;
    private float aKey;
    private float sKey;
    private float dKey;
    private float qKey;
    private float eKey;
    private float plusKey;
    private float minusKey;

    //for interaction

    RaycastHit hit;
    public int playerCurrentPosition;
    private int tileToInteract;
    private bool eReleased = true;
    private int timePressed;

    //private float speed = 0.01f;

    private void Awake()
    {
        controls = new InputMaster();

        controls.AvatarActionMap.MoveUpwardAction.performed += ctx => wKey = ctx.ReadValue<float>();
        controls.AvatarActionMap.MoveUpwardAction.canceled += (ctx => wKey = 0.0f);
        controls.AvatarActionMap.MoveLeftAction.performed += (ctx => aKey = ctx.ReadValue<float>());
        controls.AvatarActionMap.MoveLeftAction.canceled += (ctx => aKey = 0.0f);
        controls.AvatarActionMap.MoveDownAction.performed += (ctx => sKey = ctx.ReadValue<float>());
        controls.AvatarActionMap.MoveDownAction.canceled += (ctx => sKey = 0.0f);
        controls.AvatarActionMap.MoveRightAction.performed += (ctx => dKey = ctx.ReadValue<float>());
        controls.AvatarActionMap.MoveRightAction.canceled += (ctx => dKey = 0.0f);

        controls.AvatarActionMap.QInteract.performed += (ctx => qKey = ctx.ReadValue<float>());
        controls.AvatarActionMap.QInteract.canceled += (ctx => qKey = 0.0f);
        controls.AvatarActionMap.EInteract.performed += (ctx => eKey = ctx.ReadValue<float>());
        controls.AvatarActionMap.EInteract.canceled += (ctx => eKey = 0.0f);

        controls.AvatarActionMap.PlaceRopeAction.performed += (ctx => SpawnRope());
        //controls.AvatarActionMap.GrowRopeAction.performed += (ctx => ctx.ReadValue<float>());
        //controls.AvatarActionMap.GrowRopeAction.canceled += (ctx => eKey = 0.0f);
        //controls.AvatarActionMap.ShrinkRopeAction.performed += (ctx => ctx.ReadValue<float>());
        //controls.AvatarActionMap.ShrinkRopeAction.canceled += (ctx => eKey = 0.0f);

        controls.AvatarActionMap.EscapeAction.performed += ctx => EscapeKey();
    }

    private void Start()
    {
        tr = transform;
    }

    private void SpawnRope()
    {
        Debug.Log("Rope spawned");
        GameObject rope = Instantiate(ropePrefab, tr.position, Quaternion.identity);
    }

    private void EscapeKey()
    {

    }

    private void FixedUpdate()
    {
        if (wKey == 1.0f) tr.position = tr.position + new Vector3(0, 0, 0.1f);
        if (aKey == 1.0f) tr.position = tr.position + new Vector3(-0.1f, 0, 0);
        if (sKey == 1.0f) tr.position = tr.position + new Vector3(0, 0, -0.1f);
        if (dKey == 1.0f) tr.position = tr.position + new Vector3(0.1f, 0, 0);
    }

    private void OnEnable()
    {
        controls.AvatarActionMap.Enable();
    }

    private void OnDisable()
    {
        controls.AvatarActionMap.Disable();
    }

    private void Update()
    {
        // raycast for tile bellow character
        Debug.DrawRay(tr.position, Vector3.down);
        if (Physics.Raycast(tr.position, Vector3.down, out hit, 1f))
        {
            Debug.Log(hit);
            playerCurrentPosition = hit.collider.GetComponent<Tile>().id;
        }
  
        //tiles next to the character tile
        if (aKey == 1.0f)
        {
            tileToInteract = playerCurrentPosition - 1;
        }
        if (dKey == 1.0f)
        {
            tileToInteract = playerCurrentPosition + 1;
        }
        if (wKey == 1.0f)
        {
            tileToInteract = playerCurrentPosition - 12;
        }
        if (sKey == 1.0f)
        {
            tileToInteract = playerCurrentPosition + 12;
        }

        //to see how many time the player release the E buttom
        if (eKey == 1.0f)
        {
            eReleased = false;
        }
        if (eReleased == false && eKey == 0f)
        {
            eReleased = true;
            timePressed += 1;
        }

        //to call the different fonction of interact 
        if (TileManager.instance.tileArray[tileToInteract].state == 2 && timePressed == 2)
        {
            Eat();
            timePressed = 0;
        }
        if (TileManager.instance.tileArray[tileToInteract].state == 1 && timePressed == 2)
        {
            Repair();
            Eat();
            timePressed = 0;
        }
        if (TileManager.instance.tileArray[tileToInteract].state == 0 && timePressed == 2)
        {
            Build();
            timePressed = 0;
        }
    }

    //interaction fonction
    public void Build()
    {
        TileManager.instance.tileArray[tileToInteract].state = 2;
        GameManager.instance.webCount -= 2;
    }

    public void Repair()
    {
        TileManager.instance.tileArray[tileToInteract].state = 2;
        GameManager.instance.webCount -= 1;
    }

    public void Eat()
    {
        if (TileManager.instance.tileArray[tileToInteract].state == 2)
        {
            GameManager.instance.webCount += 2;
        }
        else
        {
            GameManager.instance.webCount += 1;

        }
        TileManager.instance.tileArray[tileToInteract].state = 0;
    }
}
