// GENERATED AUTOMATICALLY FROM 'Assets/Input/Player Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""4fdfe902-10f0-4043-be7d-fe1920ca1a9a"",
            ""actions"": [
                {
                    ""name"": ""Movement Input"",
                    ""type"": ""Value"",
                    ""id"": ""149b6c76-cd04-4904-a65b-76ccbe892c6e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""014b1f9c-e7d8-4ce1-8d35-4f155a68003d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drop"",
                    ""type"": ""Button"",
                    ""id"": ""62831a8f-9d02-4295-869d-72504a8f233c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Strafe"",
                    ""type"": ""Button"",
                    ""id"": ""94cdcf32-4e3d-4529-bc7c-b0a66ca71b1b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mouse Pos"",
                    ""type"": ""Value"",
                    ""id"": ""0b9c7200-6765-4074-8b5c-3182fc9927bd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""77a3bf66-a7f7-4867-b5cc-f66997aadfcb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Throw Sand"",
                    ""type"": ""Button"",
                    ""id"": ""78d472a8-39a4-4ab8-8aaa-21fbbd57a895"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Grab Sand"",
                    ""type"": ""Button"",
                    ""id"": ""f18d6f0d-aab0-43f4-82cb-a571bc413ac0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shield Sand"",
                    ""type"": ""Button"",
                    ""id"": ""54ca2d07-983e-4bca-994d-cabf4c773d2c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""End Shield Sand"",
                    ""type"": ""Button"",
                    ""id"": ""1aea98d7-c165-4b20-9846-56e1d249bfea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""5e70477b-6178-492e-a057-a0aa8192baf2"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement Input"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""53e54d14-6779-4729-9274-ec2a4d61de15"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement Input"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b651f88a-78f5-40ef-81ee-20ce7e4563a4"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement Input"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7fee48c6-ce05-4b73-bb3f-0838eff55d77"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement Input"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f74f38a8-6561-41f4-aece-5d3e228e8960"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement Input"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""4bbbe719-5973-4df4-baef-5165a4318906"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement Input"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""84c6c843-cbfd-4967-bd1c-3f2bdb4aa8a5"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement Input"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""717e9350-316f-4bf3-9a9d-46e0e38512b6"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement Input"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a0dd99ca-1b13-4e8f-b250-f65a8df40ca6"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement Input"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""84e95714-36bf-4385-a38d-9df5eacdf48c"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement Input"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d51eaf63-3663-4eb8-8026-dff79614eddf"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9437662-71d4-4013-97b1-6bb5253515ff"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a82faa26-1497-4bc1-a5cb-48eb6662b242"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Strafe"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc2a2a11-a3f5-4625-ab47-eee6aef334d5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Strafe"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a5bc931a-ddd1-41b7-b57a-e5c11ad40268"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Strafe"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6ecf322c-7c3c-4a48-836e-54cf02256cf1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Strafe"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8e994cf4-86c1-40fd-98e2-b46fd1970e4e"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Strafe"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""36416c9b-37af-4ecf-8b25-0eb9b5e0c879"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Strafe"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1bef0f10-14f7-45a4-8051-6fadf4e08393"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Strafe"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3410df5a-c693-429c-857e-bbcc01400b89"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Strafe"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b64ee1b-8715-4398-aecf-fb5fe4ca9942"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse Pos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""36d57655-cc89-44fc-b6e3-a2c654152b8e"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b90ecaa-30ff-413c-884e-3ac6de68bd37"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throw Sand"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e0dca296-fa9c-4d01-b9da-e750cb20dde7"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab Sand"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""db647636-3c62-4b80-bdff-fdebff8086fb"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grab Sand"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c1e72573-26f7-4a3c-b0a8-2b55d410422d"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shield Sand"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a7599a28-7940-481f-80ba-beeeb65041cd"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""End Shield Sand"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aee05812-6407-46a0-ae94-cf6bbfd5e46c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b02b531-6d06-42be-ae0f-4098b1c98d70"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_MovementInput = m_Player.FindAction("Movement Input", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Drop = m_Player.FindAction("Drop", throwIfNotFound: true);
        m_Player_Strafe = m_Player.FindAction("Strafe", throwIfNotFound: true);
        m_Player_MousePos = m_Player.FindAction("Mouse Pos", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        m_Player_ThrowSand = m_Player.FindAction("Throw Sand", throwIfNotFound: true);
        m_Player_GrabSand = m_Player.FindAction("Grab Sand", throwIfNotFound: true);
        m_Player_ShieldSand = m_Player.FindAction("Shield Sand", throwIfNotFound: true);
        m_Player_EndShieldSand = m_Player.FindAction("End Shield Sand", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_MovementInput;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Drop;
    private readonly InputAction m_Player_Strafe;
    private readonly InputAction m_Player_MousePos;
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_ThrowSand;
    private readonly InputAction m_Player_GrabSand;
    private readonly InputAction m_Player_ShieldSand;
    private readonly InputAction m_Player_EndShieldSand;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MovementInput => m_Wrapper.m_Player_MovementInput;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Drop => m_Wrapper.m_Player_Drop;
        public InputAction @Strafe => m_Wrapper.m_Player_Strafe;
        public InputAction @MousePos => m_Wrapper.m_Player_MousePos;
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @ThrowSand => m_Wrapper.m_Player_ThrowSand;
        public InputAction @GrabSand => m_Wrapper.m_Player_GrabSand;
        public InputAction @ShieldSand => m_Wrapper.m_Player_ShieldSand;
        public InputAction @EndShieldSand => m_Wrapper.m_Player_EndShieldSand;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @MovementInput.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovementInput;
                @MovementInput.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovementInput;
                @MovementInput.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovementInput;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Drop.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDrop;
                @Drop.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDrop;
                @Drop.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDrop;
                @Strafe.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrafe;
                @Strafe.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrafe;
                @Strafe.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnStrafe;
                @MousePos.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePos;
                @MousePos.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePos;
                @MousePos.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMousePos;
                @Interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @ThrowSand.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThrowSand;
                @ThrowSand.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThrowSand;
                @ThrowSand.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThrowSand;
                @GrabSand.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrabSand;
                @GrabSand.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrabSand;
                @GrabSand.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnGrabSand;
                @ShieldSand.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShieldSand;
                @ShieldSand.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShieldSand;
                @ShieldSand.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShieldSand;
                @EndShieldSand.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEndShieldSand;
                @EndShieldSand.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEndShieldSand;
                @EndShieldSand.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnEndShieldSand;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MovementInput.started += instance.OnMovementInput;
                @MovementInput.performed += instance.OnMovementInput;
                @MovementInput.canceled += instance.OnMovementInput;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Drop.started += instance.OnDrop;
                @Drop.performed += instance.OnDrop;
                @Drop.canceled += instance.OnDrop;
                @Strafe.started += instance.OnStrafe;
                @Strafe.performed += instance.OnStrafe;
                @Strafe.canceled += instance.OnStrafe;
                @MousePos.started += instance.OnMousePos;
                @MousePos.performed += instance.OnMousePos;
                @MousePos.canceled += instance.OnMousePos;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @ThrowSand.started += instance.OnThrowSand;
                @ThrowSand.performed += instance.OnThrowSand;
                @ThrowSand.canceled += instance.OnThrowSand;
                @GrabSand.started += instance.OnGrabSand;
                @GrabSand.performed += instance.OnGrabSand;
                @GrabSand.canceled += instance.OnGrabSand;
                @ShieldSand.started += instance.OnShieldSand;
                @ShieldSand.performed += instance.OnShieldSand;
                @ShieldSand.canceled += instance.OnShieldSand;
                @EndShieldSand.started += instance.OnEndShieldSand;
                @EndShieldSand.performed += instance.OnEndShieldSand;
                @EndShieldSand.canceled += instance.OnEndShieldSand;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMovementInput(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnDrop(InputAction.CallbackContext context);
        void OnStrafe(InputAction.CallbackContext context);
        void OnMousePos(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnThrowSand(InputAction.CallbackContext context);
        void OnGrabSand(InputAction.CallbackContext context);
        void OnShieldSand(InputAction.CallbackContext context);
        void OnEndShieldSand(InputAction.CallbackContext context);
    }
}
