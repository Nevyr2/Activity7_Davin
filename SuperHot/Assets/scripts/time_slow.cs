using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class time_slow : MonoBehaviour
{
    public float slowMo = 0.1f;
    public float normTime = 1;
    private bool doSlowMo = false;

    [SerializeField] private FirstPersonController player;

    void Update ()
    {
        if (player.m_CharacterController.velocity.magnitude > 0)
        {
            if (doSlowMo)
            {
                Time.timeScale = normTime;
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
                doSlowMo = false;
            }
        }
        else
        {
            if (!doSlowMo)
            {
                Time.timeScale = slowMo;
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
                doSlowMo = true;
            }
        }
    }

    

}
