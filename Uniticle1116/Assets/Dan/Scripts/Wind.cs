using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    public float strength;

    public bool LeftWind;
    public bool RightWind;
    public bool FowordWind;
    public bool BackWind;

    public UnicycleController Player;

    bool InWindArea = false;

    bool InputKey = false;

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            InputKey = true;
        }

        else
        {
            InputKey = false;
        }

        if(InWindArea)
        {
            if (!InputKey)
            {
                if (LeftWind)
                {
                    Player.frameRigidbody.angularVelocity = -transform.forward * strength;
                }

                else if (RightWind)
                {
                    Player.frameRigidbody.angularVelocity = transform.forward * strength;
                }

                else if (FowordWind)
                {
                    Player.frameRigidbody.angularVelocity = -transform.right * strength;
                }

                else if (BackWind)
                {
                    Player.frameRigidbody.angularVelocity = transform.right * strength;
                }
            }

            else
            {

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            InWindArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            InWindArea = false;
        }
    }
}
