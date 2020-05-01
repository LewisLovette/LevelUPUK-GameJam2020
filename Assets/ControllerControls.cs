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
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ead0bf62-613e-4b49-94e6-7a952363b9a1"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
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
    public struct MainActions
    {
        private @ControllerControls m_Wrapper;
        public MainActions(@ControllerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fire => m_Wrapper.m_Main_Fire;
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
            }
            m_Wrapper.m_MainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
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
    }
}
