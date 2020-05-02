// GENERATED AUTOMATICALLY FROM 'Assets/ControllerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @ControllerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @ControllerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""ControllerControls"",
    ""maps"": [
        {
            ""name"": ""Main"",
            ""id"": ""c2dbb653-fed4-42db-bbeb-16df68680895"",
            ""actions"": [
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""be218dc2-35d2-4958-bd16-73b455e110ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""rLeft"",
                    ""type"": ""Button"",
                    ""id"": ""cd030852-e310-415e-bf16-7068c5acf31f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""rRight"",
                    ""type"": ""Button"",
                    ""id"": ""1d58b69a-225f-4837-ad9c-f1aacd386c15"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""rUp"",
                    ""type"": ""Button"",
                    ""id"": ""71b42647-d4ab-4b55-82c0-51bb7a45e1d4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""rDown"",
                    ""type"": ""Button"",
                    ""id"": ""ae610555-0ac8-4712-a531-b8528f141058"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AirGun"",
                    ""type"": ""Button"",
                    ""id"": ""b8c87545-ed64-47b3-b6cb-5f0e2146d810"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ead0bf62-613e-4b49-94e6-7a952363b9a1"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bdf12748-29bf-4e2d-9663-3b4e3e9b7278"",
                    ""path"": ""<XInputController>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""rLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3cc552c8-6ffd-462e-bc6e-826e4faf6597"",
                    ""path"": ""<XInputController>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""rRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b65053b6-de22-4f0f-b52b-9781a16a8c40"",
                    ""path"": ""<XInputController>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""rUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a34ce4e-0474-4ede-92d4-d3a62eea83e2"",
                    ""path"": ""<XInputController>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""rDown"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60bcf7f7-469d-4a44-bd7e-32793541c441"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AirGun"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""controller"",
            ""bindingGroup"": ""controller"",
            ""devices"": []
        }
    ]
}");
        // Main
        m_Main = asset.FindActionMap("Main", throwIfNotFound: true);
        m_Main_Fire = m_Main.FindAction("Fire", throwIfNotFound: true);
        m_Main_rLeft = m_Main.FindAction("rLeft", throwIfNotFound: true);
        m_Main_rRight = m_Main.FindAction("rRight", throwIfNotFound: true);
        m_Main_rUp = m_Main.FindAction("rUp", throwIfNotFound: true);
        m_Main_rDown = m_Main.FindAction("rDown", throwIfNotFound: true);
        m_Main_AirGun = m_Main.FindAction("AirGun", throwIfNotFound: true);
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

    // Main
    private readonly InputActionMap m_Main;
    private IMainActions m_MainActionsCallbackInterface;
    private readonly InputAction m_Main_Fire;
    private readonly InputAction m_Main_rLeft;
    private readonly InputAction m_Main_rRight;
    private readonly InputAction m_Main_rUp;
    private readonly InputAction m_Main_rDown;
    private readonly InputAction m_Main_AirGun;
    public struct MainActions
    {
        private @ControllerControls m_Wrapper;
        public MainActions(@ControllerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fire => m_Wrapper.m_Main_Fire;
        public InputAction @rLeft => m_Wrapper.m_Main_rLeft;
        public InputAction @rRight => m_Wrapper.m_Main_rRight;
        public InputAction @rUp => m_Wrapper.m_Main_rUp;
        public InputAction @rDown => m_Wrapper.m_Main_rDown;
        public InputAction @AirGun => m_Wrapper.m_Main_AirGun;
        public InputActionMap Get() { return m_Wrapper.m_Main; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainActions set) { return set.Get(); }
        public void SetCallbacks(IMainActions instance)
        {
            if (m_Wrapper.m_MainActionsCallbackInterface != null)
            {
                @Fire.started -= m_Wrapper.m_MainActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnFire;
                @rLeft.started -= m_Wrapper.m_MainActionsCallbackInterface.OnRLeft;
                @rLeft.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnRLeft;
                @rLeft.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnRLeft;
                @rRight.started -= m_Wrapper.m_MainActionsCallbackInterface.OnRRight;
                @rRight.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnRRight;
                @rRight.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnRRight;
                @rUp.started -= m_Wrapper.m_MainActionsCallbackInterface.OnRUp;
                @rUp.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnRUp;
                @rUp.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnRUp;
                @rDown.started -= m_Wrapper.m_MainActionsCallbackInterface.OnRDown;
                @rDown.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnRDown;
                @rDown.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnRDown;
                @AirGun.started -= m_Wrapper.m_MainActionsCallbackInterface.OnAirGun;
                @AirGun.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnAirGun;
                @AirGun.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnAirGun;
            }
            m_Wrapper.m_MainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @rLeft.started += instance.OnRLeft;
                @rLeft.performed += instance.OnRLeft;
                @rLeft.canceled += instance.OnRLeft;
                @rRight.started += instance.OnRRight;
                @rRight.performed += instance.OnRRight;
                @rRight.canceled += instance.OnRRight;
                @rUp.started += instance.OnRUp;
                @rUp.performed += instance.OnRUp;
                @rUp.canceled += instance.OnRUp;
                @rDown.started += instance.OnRDown;
                @rDown.performed += instance.OnRDown;
                @rDown.canceled += instance.OnRDown;
                @AirGun.started += instance.OnAirGun;
                @AirGun.performed += instance.OnAirGun;
                @AirGun.canceled += instance.OnAirGun;
            }
        }
    }
    public MainActions @Main => new MainActions(this);
    private int m_controllerSchemeIndex = -1;
    public InputControlScheme controllerScheme
    {
        get
        {
            if (m_controllerSchemeIndex == -1) m_controllerSchemeIndex = asset.FindControlSchemeIndex("controller");
            return asset.controlSchemes[m_controllerSchemeIndex];
        }
    }
    public interface IMainActions
    {
        void OnFire(InputAction.CallbackContext context);
        void OnRLeft(InputAction.CallbackContext context);
        void OnRRight(InputAction.CallbackContext context);
        void OnRUp(InputAction.CallbackContext context);
        void OnRDown(InputAction.CallbackContext context);
        void OnAirGun(InputAction.CallbackContext context);
    }
}
