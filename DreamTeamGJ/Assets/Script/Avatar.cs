using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Avatar : MonoBehaviour
{
    public InputMaster controls;
    private Transform tr;

    private float wKey;
    private float aKey;
    private float sKey;
    private float dKey;

    private float speed = 0.01f;

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
    }

    private void Start()
    {
        tr = transform;
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

}
