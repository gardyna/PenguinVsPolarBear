using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class UserInputControl : MonoBehaviour {

    private PlatformCharacter2D m_Character;
    private bool m_Jump;

    [SerializeField]
    private KeyCode m_jumpButton;
    [SerializeField]
    private KeyCode m_crouchButton;


    private void Awake()
    {
        m_Character = GetComponent<PlatformCharacter2D>();
    }


    private void Update()
    {
        if (!m_Jump)
        {
            // Read the jump input in Update so button presses aren't missed.
            m_Jump = Input.GetKeyDown(m_jumpButton);
        }
    }


    private void FixedUpdate()
    {
        // Read the inputs.
        bool crouch = Input.GetKey(m_crouchButton);
        // bool test = Input.GetKey(KeyCode.T);
        // Pass all parameters to the character control script.
        m_Character.Move(crouch, m_Jump);
        m_Jump = false;
    }
}
