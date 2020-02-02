using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Avatar : MonoBehaviour
{
    public InputMaster controls;
    private Transform tr;
    public Animator animator;
    public GameObject ropePrefab;

    private GameObject[] test;

    private float[] wasd = new float[4];
    private string lastKeyPressed;
    private float qKey;
    private float eKey;
    private float plusKey;
    private float minusKey;

    //for interaction

    RaycastHit hit;
    public int playerCurrentPosition;
    public int tileToInteract;
    public bool canInteract;

    //private float speed = 0.01f;

    private void Awake()
    {
        controls = new InputMaster();

        controls.AvatarActionMap.MoveUpwardAction.performed += ValidateInput;
        controls.AvatarActionMap.MoveUpwardAction.canceled += (ctx => wasd[0] = 0.0f);
        controls.AvatarActionMap.MoveLeftAction.performed += ValidateInput;
        controls.AvatarActionMap.MoveLeftAction.canceled += (ctx => wasd[1] = 0.0f);
        controls.AvatarActionMap.MoveDownAction.performed += ValidateInput;
        controls.AvatarActionMap.MoveDownAction.canceled += (ctx => wasd[2] = 0.0f);
        controls.AvatarActionMap.MoveRightAction.performed += ValidateInput;
        controls.AvatarActionMap.MoveRightAction.canceled += (ctx => wasd[3] = 0.0f);

        controls.AvatarActionMap.InteractChoiceAction.performed += InteractMenu;
        controls.AvatarActionMap.QInteractAction.performed += QInteract;
        controls.AvatarActionMap.EInteractAction.performed += EInteract;



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

    // Make sure only one of the wasd key can be pressed at the same time. Disallow diagonal.
    // Recieve the input context, check if any wasd input are currently being pressed. If not, allow key press.
    private void ValidateInput(InputAction.CallbackContext ctx)
    {
        int totalKeysPressed = 0;
        for(int i = 0; i < wasd.Length; i++)
        {
            if(wasd[i] == 1) totalKeysPressed++;
        }
        if(totalKeysPressed == 0)
        {
            if(ctx.action == controls.AvatarActionMap.MoveUpwardAction)
            {
                wasd[0] = 1;
                lastKeyPressed = "W";
            }
            if (ctx.action == controls.AvatarActionMap.MoveLeftAction)
            {
                wasd[1] = 1;
                lastKeyPressed = "A";
            }
            if (ctx.action == controls.AvatarActionMap.MoveDownAction)
            {
                wasd[2] = 1;
                lastKeyPressed = "S";
            }
            if (ctx.action == controls.AvatarActionMap.MoveRightAction)
            {
                wasd[3] = 1;
                lastKeyPressed = "D";
            }
        }
    }

    // Manage animation and movement
    private void FixedUpdate()
    {
        animator.SetBool("isMoving", false);
        if (wasd[0] == 1.0f)
        {
            tr.position = tr.position + new Vector3(0, 0, 0.1f);
            animator.SetBool("isMoving", true);
        }
        if (wasd[1] == 1.0f)
        {
            tr.position = tr.position + new Vector3(-0.1f, 0, 0);
            animator.SetBool("isMoving", true);
        }
        if (wasd[2] == 1.0f)
        {
            tr.position = tr.position + new Vector3(0, 0, -0.1f);
            animator.SetBool("isMoving", true);
        }
        if (wasd[3] == 1.0f)
        {
            tr.position = tr.position + new Vector3(0.1f, 0, 0);
            animator.SetBool("isMoving", true);
        }
    }

    private void Update()
    {
        // Find player current position with a raycast down
        if (Physics.Raycast(tr.position, Vector3.down, out hit, 1f))
        {
            playerCurrentPosition = hit.collider.GetComponent<Tile>().id;
        }

        // Find tileToInteract based on last key pressed.
        switch (lastKeyPressed)
        {
            case "W":
                tileToInteract = (playerCurrentPosition - 12 < 0)? 0: playerCurrentPosition - 12;
                break;

            case "A":
                tileToInteract = (playerCurrentPosition % 12 == 1)? 0: playerCurrentPosition - 1; 
                break;

            case "S":
                tileToInteract = (playerCurrentPosition + 12 > 84) ? 0 : playerCurrentPosition + 12;
                break;

            case "D":
                tileToInteract = (playerCurrentPosition % 12 == 0) ? 0 : playerCurrentPosition + 1;
                break;
        }
    }

    private void InteractMenu(InputAction.CallbackContext ctx)
    {
        if(!canInteract && tileToInteract != 0)
        {
            // Open Menu visual
            Debug.Log("Menu open");
            canInteract = true;
        }
        else if(canInteract)
        {
            //close visual
            Debug.Log("Menu closed");
            canInteract = false;
        }
    }

    private void EInteract(InputAction.CallbackContext ctx)
    {
        Debug.Log("Eat action failed");
        if (canInteract && TileManager.instance.tileArray[tileToInteract].state == 2)
        {
            Debug.Log("Eat action succes");
            Eat();
        }
    }

    private void QInteract(InputAction.CallbackContext ctx)
    {
        Debug.Log("Build/Repair action failed");
        if (canInteract && TileManager.instance.tileArray[tileToInteract].state == 0)
        {
            Debug.Log("Build action succes");
            Build();
        }
        else if(canInteract && TileManager.instance.tileArray[tileToInteract].state == 1)
        {
            Debug.Log("Repair action succes");
            Repair();
            Eat();
        }
    }

    //interaction fonction
    public void Build()
    {
        // pop le ui de selection
        if (GameManager.instance.webCount >= 2)
        {
            GameManager.instance.webCount -= 2;
            TileManager.instance.tileArray[tileToInteract].state = 2;
            GameManager.instance.eventInteract.Invoke(); // update le visuel
        }
    }

    public void Repair()
    {
        if (GameManager.instance.webCount >= 1)
        {
            GameManager.instance.webCount -= 1;
            TileManager.instance.tileArray[tileToInteract].state = 2;
            GameManager.instance.eventInteract.Invoke();
        }
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

    private void OnEnable()
    {
        controls.AvatarActionMap.Enable();
    }

    private void OnDisable()
    {
        controls.AvatarActionMap.Disable();
    }

    //ROPE NOT INTEGRATED
    /*
    private void SpawnRope()
    {
        Debug.Log("Rope spawned");
        GameObject rope = Instantiate(ropePrefab, tr.position, Quaternion.identity);
    }
    */
}
