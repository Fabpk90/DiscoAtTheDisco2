// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class Controls : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Character"",
            ""id"": ""9d450844-5b8d-4f74-ac22-af019f9b7b02"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""c4906787-1ec1-464f-9e70-20abbf76f32f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Button1"",
                    ""type"": ""Button"",
                    ""id"": ""8b1e7c66-46d5-469c-b9bd-37d7d6398701"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Button2"",
                    ""type"": ""Button"",
                    ""id"": ""082f9245-2f91-4778-ae50-0acf2c510b3f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Button3"",
                    ""type"": ""Button"",
                    ""id"": ""172e2326-28cf-43f5-919e-ab409aed77a0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Button4"",
                    ""type"": ""Button"",
                    ""id"": ""c27a78e4-8348-4124-985d-a8fbeed3be98"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PossessJob"",
                    ""type"": ""Button"",
                    ""id"": ""bbc45a1f-3cfc-45a9-9c93-96e9b4109a4b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""265c3bbb-7f2c-443f-a36f-85b120f8d303"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""bacda32e-4378-4bbf-9dcf-20733970c74f"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""10b3d3ba-200f-4181-a51e-4c13a3ebcf95"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9f609af2-e6b8-4c00-ad06-9c4dd67e8a69"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f4bf97d5-b5a3-470e-9533-8fef69e5e227"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""cbd024c3-15f0-45b4-a982-4387707eefe1"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2ab77466-2805-45b3-b2f6-ca0c99a54110"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""203e25b3-da30-4d00-9886-3dd8dd5d32eb"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b29c339f-8ccb-4f2a-84de-19ba4518071c"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4967abad-ba10-4b2c-91e4-aa7be69945c1"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""a6106599-f6e6-468a-bd8e-d1cc63edc272"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Button2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f98eeb33-3ac7-4669-a0d6-9bb11b3a5dbd"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Button2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""70f9d812-fbac-47d4-8c01-b82ea9c59a88"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Button3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""deec37a3-da47-4e00-863b-e272fa62199a"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Button3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c01f9471-692c-4271-98a0-396c1ca140cc"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Button4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef15211b-78ef-490e-8e5b-03ffbe9a4013"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Button4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fbae96cc-2839-4cbe-8391-12cbd7b1df5d"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PossessJob"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""16e829e7-ab74-4b09-a78e-86724dab8ebb"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PossessJob"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4c9857e1-1298-445f-a5b9-f558db47ca99"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PossessJob"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8abcfbab-97fc-4c3e-935d-d71123735afe"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Button1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d02c3acc-63bc-4a03-a512-2ae8ba73a4ad"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Button1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Character
        m_Character = asset.FindActionMap("Character", throwIfNotFound: true);
        m_Character_Movement = m_Character.FindAction("Movement", throwIfNotFound: true);
        m_Character_Button1 = m_Character.FindAction("Button1", throwIfNotFound: true);
        m_Character_Button2 = m_Character.FindAction("Button2", throwIfNotFound: true);
        m_Character_Button3 = m_Character.FindAction("Button3", throwIfNotFound: true);
        m_Character_Button4 = m_Character.FindAction("Button4", throwIfNotFound: true);
        m_Character_PossessJob = m_Character.FindAction("PossessJob", throwIfNotFound: true);
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

    // Character
    private readonly InputActionMap m_Character;
    private ICharacterActions m_CharacterActionsCallbackInterface;
    private readonly InputAction m_Character_Movement;
    private readonly InputAction m_Character_Button1;
    private readonly InputAction m_Character_Button2;
    private readonly InputAction m_Character_Button3;
    private readonly InputAction m_Character_Button4;
    private readonly InputAction m_Character_PossessJob;
    public struct CharacterActions
    {
        private Controls m_Wrapper;
        public CharacterActions(Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Character_Movement;
        public InputAction @Button1 => m_Wrapper.m_Character_Button1;
        public InputAction @Button2 => m_Wrapper.m_Character_Button2;
        public InputAction @Button3 => m_Wrapper.m_Character_Button3;
        public InputAction @Button4 => m_Wrapper.m_Character_Button4;
        public InputAction @PossessJob => m_Wrapper.m_Character_PossessJob;
        public InputActionMap Get() { return m_Wrapper.m_Character; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterActions instance)
        {
            if (m_Wrapper.m_CharacterActionsCallbackInterface != null)
            {
                Movement.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMovement;
                Movement.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMovement;
                Movement.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMovement;
                Button1.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnButton1;
                Button1.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnButton1;
                Button1.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnButton1;
                Button2.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnButton2;
                Button2.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnButton2;
                Button2.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnButton2;
                Button3.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnButton3;
                Button3.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnButton3;
                Button3.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnButton3;
                Button4.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnButton4;
                Button4.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnButton4;
                Button4.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnButton4;
                PossessJob.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnPossessJob;
                PossessJob.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnPossessJob;
                PossessJob.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnPossessJob;
            }
            m_Wrapper.m_CharacterActionsCallbackInterface = instance;
            if (instance != null)
            {
                Movement.started += instance.OnMovement;
                Movement.performed += instance.OnMovement;
                Movement.canceled += instance.OnMovement;
                Button1.started += instance.OnButton1;
                Button1.performed += instance.OnButton1;
                Button1.canceled += instance.OnButton1;
                Button2.started += instance.OnButton2;
                Button2.performed += instance.OnButton2;
                Button2.canceled += instance.OnButton2;
                Button3.started += instance.OnButton3;
                Button3.performed += instance.OnButton3;
                Button3.canceled += instance.OnButton3;
                Button4.started += instance.OnButton4;
                Button4.performed += instance.OnButton4;
                Button4.canceled += instance.OnButton4;
                PossessJob.started += instance.OnPossessJob;
                PossessJob.performed += instance.OnPossessJob;
                PossessJob.canceled += instance.OnPossessJob;
            }
        }
    }
    public CharacterActions @Character => new CharacterActions(this);
    public interface ICharacterActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnButton1(InputAction.CallbackContext context);
        void OnButton2(InputAction.CallbackContext context);
        void OnButton3(InputAction.CallbackContext context);
        void OnButton4(InputAction.CallbackContext context);
        void OnPossessJob(InputAction.CallbackContext context);
    }
}
