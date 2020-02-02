// GENERATED AUTOMATICALLY FROM 'Assets/Script/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""AvatarActionMap"",
            ""id"": ""d5fa353c-6ec2-4452-9699-303fab5c79f2"",
            ""actions"": [
                {
                    ""name"": ""MoveUpwardAction"",
                    ""type"": ""Button"",
                    ""id"": ""1aaf91a6-9100-43a3-8480-15783358c438"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveLeftAction"",
                    ""type"": ""Button"",
                    ""id"": ""a43a8489-43a6-48bc-ac99-d35d1343bcb7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveDownAction"",
                    ""type"": ""Button"",
                    ""id"": ""1e741df6-953c-43ce-b28f-6f7c2731f071"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveRightAction"",
                    ""type"": ""Button"",
                    ""id"": ""c41c0a8b-a653-4012-8b84-80547ce745c5"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""QInteract"",
                    ""type"": ""Button"",
                    ""id"": ""ab522102-526c-4f3f-aabb-67228dbc9d11"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""EInteract"",
                    ""type"": ""Button"",
                    ""id"": ""3296c76e-5255-49b5-9964-26cad29c1a21"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""EscapeAction"",
                    ""type"": ""Button"",
                    ""id"": ""22d404dc-776b-44dd-b523-56e80d688f82"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d5126ad7-196f-4bfb-a3f7-f1cbc4b24f91"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUpwardAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""59231108-110e-4852-95e7-bf9d0b3be5c1"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveLeftAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6c38a5f0-867b-4280-9ab7-32a8e0127271"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveDownAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""883aecf6-842f-471d-a1a7-f0e03aa81743"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveRightAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""16b0c178-f53f-4bd8-9dcf-b74d730003ce"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""QInteract"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed671a3f-cc84-42ff-9252-0febcb7666bf"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EInteract"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c698e7a1-1c1e-43bc-8760-e7de39f2bf4f"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EscapeAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // AvatarActionMap
        m_AvatarActionMap = asset.FindActionMap("AvatarActionMap", throwIfNotFound: true);
        m_AvatarActionMap_MoveUpwardAction = m_AvatarActionMap.FindAction("MoveUpwardAction", throwIfNotFound: true);
        m_AvatarActionMap_MoveLeftAction = m_AvatarActionMap.FindAction("MoveLeftAction", throwIfNotFound: true);
        m_AvatarActionMap_MoveDownAction = m_AvatarActionMap.FindAction("MoveDownAction", throwIfNotFound: true);
        m_AvatarActionMap_MoveRightAction = m_AvatarActionMap.FindAction("MoveRightAction", throwIfNotFound: true);
        m_AvatarActionMap_QInteract = m_AvatarActionMap.FindAction("QInteract", throwIfNotFound: true);
        m_AvatarActionMap_EInteract = m_AvatarActionMap.FindAction("EInteract", throwIfNotFound: true);
        m_AvatarActionMap_EscapeAction = m_AvatarActionMap.FindAction("EscapeAction", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // AvatarActionMap
    private readonly InputActionMap m_AvatarActionMap;
    private IAvatarActionMapActions m_AvatarActionMapActionsCallbackInterface;
    private readonly InputAction m_AvatarActionMap_MoveUpwardAction;
    private readonly InputAction m_AvatarActionMap_MoveLeftAction;
    private readonly InputAction m_AvatarActionMap_MoveDownAction;
    private readonly InputAction m_AvatarActionMap_MoveRightAction;
    private readonly InputAction m_AvatarActionMap_QInteract;
    private readonly InputAction m_AvatarActionMap_EInteract;
    private readonly InputAction m_AvatarActionMap_EscapeAction;
    public struct AvatarActionMapActions
    {
        private @InputMaster m_Wrapper;
        public AvatarActionMapActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveUpwardAction => m_Wrapper.m_AvatarActionMap_MoveUpwardAction;
        public InputAction @MoveLeftAction => m_Wrapper.m_AvatarActionMap_MoveLeftAction;
        public InputAction @MoveDownAction => m_Wrapper.m_AvatarActionMap_MoveDownAction;
        public InputAction @MoveRightAction => m_Wrapper.m_AvatarActionMap_MoveRightAction;
        public InputAction @QInteract => m_Wrapper.m_AvatarActionMap_QInteract;
        public InputAction @EInteract => m_Wrapper.m_AvatarActionMap_EInteract;
        public InputAction @EscapeAction => m_Wrapper.m_AvatarActionMap_EscapeAction;
        public InputActionMap Get() { return m_Wrapper.m_AvatarActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AvatarActionMapActions set) { return set.Get(); }
        public void SetCallbacks(IAvatarActionMapActions instance)
        {
            if (m_Wrapper.m_AvatarActionMapActionsCallbackInterface != null)
            {
                @MoveUpwardAction.started -= m_Wrapper.m_AvatarActionMapActionsCallbackInterface.OnMoveUpwardAction;
                @MoveUpwardAction.performed -= m_Wrapper.m_AvatarActionMapActionsCallbackInterface.OnMoveUpwardAction;
                @MoveUpwardAction.canceled -= m_Wrapper.m_AvatarActionMapActionsCallbackInterface.OnMoveUpwardAction;
                @MoveLeftAction.started -= m_Wrapper.m_AvatarActionMapActionsCallbackInterface.OnMoveLeftAction;
                @MoveLeftAction.performed -= m_Wrapper.m_AvatarActionMapActionsCallbackInterface.OnMoveLeftAction;
                @MoveLeftAction.canceled -= m_Wrapper.m_AvatarActionMapActionsCallbackInterface.OnMoveLeftAction;
                @MoveDownAction.started -= m_Wrapper.m_AvatarActionMapActionsCallbackInterface.OnMoveDownAction;
                @MoveDownAction.performed -= m_Wrapper.m_AvatarActionMapActionsCallbackInterface.OnMoveDownAction;
                @MoveDownAction.canceled -= m_Wrapper.m_AvatarActionMapActionsCallbackInterface.OnMoveDownAction;
                @MoveRightAction.started -= m_Wrapper.m_AvatarActionMapActionsCallbackInterface.OnMoveRightAction;
                @MoveRightAction.performed -= m_Wrapper.m_AvatarActionMapActionsCallbackInterface.OnMoveRightAction;
                @MoveRightAction.canceled -= m_Wrapper.m_AvatarActionMapActionsCallbackInterface.OnMoveRightAction;
                @QInteract.started -= m_Wrapper.m_AvatarActionMapActionsCallbackInterface.OnQInteract;
                @QInteract.performed -= m_Wrapper.m_AvatarActionMapActionsCallbackInterface.OnQInteract;
                @QInteract.canceled -= m_Wrapper.m_AvatarActionMapActionsCallbackInterface.OnQInteract;
                @EInteract.started -= m_Wrapper.m_AvatarActionMapActionsCallbackInterface.OnEInteract;
                @EInteract.performed -= m_Wrapper.m_AvatarActionMapActionsCallbackInterface.OnEInteract;
                @EInteract.canceled -= m_Wrapper.m_AvatarActionMapActionsCallbackInterface.OnEInteract;
                @EscapeAction.started -= m_Wrapper.m_AvatarActionMapActionsCallbackInterface.OnEscapeAction;
                @EscapeAction.performed -= m_Wrapper.m_AvatarActionMapActionsCallbackInterface.OnEscapeAction;
                @EscapeAction.canceled -= m_Wrapper.m_AvatarActionMapActionsCallbackInterface.OnEscapeAction;
            }
            m_Wrapper.m_AvatarActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MoveUpwardAction.started += instance.OnMoveUpwardAction;
                @MoveUpwardAction.performed += instance.OnMoveUpwardAction;
                @MoveUpwardAction.canceled += instance.OnMoveUpwardAction;
                @MoveLeftAction.started += instance.OnMoveLeftAction;
                @MoveLeftAction.performed += instance.OnMoveLeftAction;
                @MoveLeftAction.canceled += instance.OnMoveLeftAction;
                @MoveDownAction.started += instance.OnMoveDownAction;
                @MoveDownAction.performed += instance.OnMoveDownAction;
                @MoveDownAction.canceled += instance.OnMoveDownAction;
                @MoveRightAction.started += instance.OnMoveRightAction;
                @MoveRightAction.performed += instance.OnMoveRightAction;
                @MoveRightAction.canceled += instance.OnMoveRightAction;
                @QInteract.started += instance.OnQInteract;
                @QInteract.performed += instance.OnQInteract;
                @QInteract.canceled += instance.OnQInteract;
                @EInteract.started += instance.OnEInteract;
                @EInteract.performed += instance.OnEInteract;
                @EInteract.canceled += instance.OnEInteract;
                @EscapeAction.started += instance.OnEscapeAction;
                @EscapeAction.performed += instance.OnEscapeAction;
                @EscapeAction.canceled += instance.OnEscapeAction;
            }
        }
    }
    public AvatarActionMapActions @AvatarActionMap => new AvatarActionMapActions(this);
    public interface IAvatarActionMapActions
    {
        void OnMoveUpwardAction(InputAction.CallbackContext context);
        void OnMoveLeftAction(InputAction.CallbackContext context);
        void OnMoveDownAction(InputAction.CallbackContext context);
        void OnMoveRightAction(InputAction.CallbackContext context);
        void OnQInteract(InputAction.CallbackContext context);
        void OnEInteract(InputAction.CallbackContext context);
        void OnEscapeAction(InputAction.CallbackContext context);
    }
}
