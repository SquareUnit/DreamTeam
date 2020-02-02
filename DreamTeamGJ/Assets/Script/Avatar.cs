using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Avatar : MonoBehaviour
{
    public InputMaster controls;
    private Transform tr;
    public Animator animator;

    private GameObject[] test;

    private float wKey;
    private float aKey;
    private float sKey;
    private float dKey;
    private float qKey;
    private float eKey;

    //for interaction

    RaycastHit hit;
    public int playerCurrentPosition;
    public int tileToInteract;
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

        controls.AvatarActionMap.EscapeAction.performed += ctx => EscapeKey();

    }

    private void Start()
    {
        tr = transform;
        tileToInteract = 0;
        animator = GetComponent<Animator>();
    } 

    private void EscapeKey()
    {

    }

    private void FixedUpdate()
    {
        animator.SetBool("isMoving", false);
        if (wKey == 1.0f)
        {
            tr.position = tr.position + new Vector3(0, 0, 0.1f);
            animator.SetBool("isMoving", true);
        }
        if (aKey == 1.0f)
        {
            tr.position = tr.position + new Vector3(-0.1f, 0, 0);
            animator.SetBool("isMoving", true);
        }
        if (sKey == 1.0f)
        {
            tr.position = tr.position + new Vector3(0, 0, -0.1f);
            animator.SetBool("isMoving", true);
        }
        if (dKey == 1.0f)
        {
            tr.position = tr.position + new Vector3(0.1f, 0, 0);
            animator.SetBool("isMoving", true);
        }
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
        if (Physics.Raycast(tr.position, Vector3.down, out hit, 1f))
        {
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

        if (tileToInteract < 0 || tileToInteract > 84)
            tileToInteract = 0;
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

        if (tileToInteract != 0 && TileManager.instance.tileArray[tileToInteract].state == 2 && timePressed == 2)
        {
            Eat();
            timePressed = 0;
        }
        if (tileToInteract != 0 && TileManager.instance.tileArray[tileToInteract].state == 1 && timePressed == 2)
        {
            Repair();
            Eat();
            timePressed = 0;
        }
        if (tileToInteract != 0 && TileManager.instance.tileArray[tileToInteract].state == 0 && timePressed == 2)
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
        GameManager.instance.eventInteract.Invoke();
    }

    public void Repair()
    {
        TileManager.instance.tileArray[tileToInteract].state = 2;
        GameManager.instance.webCount -= 1;
        GameManager.instance.eventInteract.Invoke();
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

        GameManager.instance.eventInteract.Invoke();
    }

}
