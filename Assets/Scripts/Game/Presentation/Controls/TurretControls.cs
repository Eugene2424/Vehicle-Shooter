//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Controls/TurretControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Game.Controls
{
    public partial class @TurretControls: IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @TurretControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""TurretControls"",
    ""maps"": [
        {
            ""name"": ""Turret"",
            ""id"": ""3e26b371-1a8e-42d0-b83d-7bcc9d4e700d"",
            ""actions"": [
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""8525f297-825d-4a91-b23b-b08340851aad"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""TouchPress"",
                    ""type"": ""Button"",
                    ""id"": ""41280f12-03cc-4f96-aa0c-0d6cde90b53c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e98b5ce4-ca34-4da3-9941-27499b77fd04"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4af87654-5d62-437b-bf33-e24d7a446446"",
                    ""path"": ""<Touchscreen>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""12187150-cc09-4c11-94d8-e98ac964b56c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7430f226-d379-476f-a09a-56497b1b204d"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPress"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Turret
            m_Turret = asset.FindActionMap("Turret", throwIfNotFound: true);
            m_Turret_Look = m_Turret.FindAction("Look", throwIfNotFound: true);
            m_Turret_TouchPress = m_Turret.FindAction("TouchPress", throwIfNotFound: true);
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

        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }

        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // Turret
        private readonly InputActionMap m_Turret;
        private List<ITurretActions> m_TurretActionsCallbackInterfaces = new List<ITurretActions>();
        private readonly InputAction m_Turret_Look;
        private readonly InputAction m_Turret_TouchPress;
        public struct TurretActions
        {
            private @TurretControls m_Wrapper;
            public TurretActions(@TurretControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Look => m_Wrapper.m_Turret_Look;
            public InputAction @TouchPress => m_Wrapper.m_Turret_TouchPress;
            public InputActionMap Get() { return m_Wrapper.m_Turret; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(TurretActions set) { return set.Get(); }
            public void AddCallbacks(ITurretActions instance)
            {
                if (instance == null || m_Wrapper.m_TurretActionsCallbackInterfaces.Contains(instance)) return;
                m_Wrapper.m_TurretActionsCallbackInterfaces.Add(instance);
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @TouchPress.started += instance.OnTouchPress;
                @TouchPress.performed += instance.OnTouchPress;
                @TouchPress.canceled += instance.OnTouchPress;
            }

            private void UnregisterCallbacks(ITurretActions instance)
            {
                @Look.started -= instance.OnLook;
                @Look.performed -= instance.OnLook;
                @Look.canceled -= instance.OnLook;
                @TouchPress.started -= instance.OnTouchPress;
                @TouchPress.performed -= instance.OnTouchPress;
                @TouchPress.canceled -= instance.OnTouchPress;
            }

            public void RemoveCallbacks(ITurretActions instance)
            {
                if (m_Wrapper.m_TurretActionsCallbackInterfaces.Remove(instance))
                    UnregisterCallbacks(instance);
            }

            public void SetCallbacks(ITurretActions instance)
            {
                foreach (var item in m_Wrapper.m_TurretActionsCallbackInterfaces)
                    UnregisterCallbacks(item);
                m_Wrapper.m_TurretActionsCallbackInterfaces.Clear();
                AddCallbacks(instance);
            }
        }
        public TurretActions @Turret => new TurretActions(this);
        public interface ITurretActions
        {
            void OnLook(InputAction.CallbackContext context);
            void OnTouchPress(InputAction.CallbackContext context);
        }
    }
}
