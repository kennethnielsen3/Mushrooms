using System;
using UnityEngine;


[RequireComponent(typeof (CharacterControler))]
public class UserControl : MonoBehaviour
{
    private CharacterControler m_Character;
    public static Action attack;
    public static Action jumpOn;
    public static Action jumpHold;
    public static Action jumpOff;
    public static Action crouchOn;
    public static Action crouchOff;
    public static Action upKeyOn;
    public static Action upKeyOff;

    private void Awake()
    {
        m_Character = GetComponent<CharacterControler>();
    }

    private void Update()
    {
        if(StaticVars.controlActive == true)
        {
            if (Input.GetButtonDown("Jump")) 
            {
                jumpOn();
            }
            if(Input.GetButton("Jump"))
            {
                jumpHold();
            }
            if(Input.GetButtonUp("Jump"))
            {
                jumpOff();
            }

            if (Input.GetButtonDown("Fire1")) 
            {
                attack();
            }

            if(Input.GetButton("DownArrow"))
            {
                crouchOn();
            }
            if(Input.GetButtonUp("DownArrow"))
            {
                crouchOff();
            }
            if(Input.GetButton("DownArrow"))
            {
                crouchOn();
            }
            if(Input.GetButtonUp("DownArrow"))
            {
                crouchOff();
            }
            
            //Move
            float h = Input.GetAxis("Horizontal");
            m_Character.Move(h);

        }
    }
}
