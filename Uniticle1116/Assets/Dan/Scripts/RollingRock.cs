using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingRock : MonoBehaviour
{
    public bool Foward;
    public bool Back;
    public bool Left;
    public bool Right;
    public bool Destroyed;

    public float Power;
   
    bool checkPlayer = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Q))
        {
            checkPlayer = true;
        }    

        if (checkPlayer && enabled != GetComponent<Rigidbody>())
        {
            if(Foward)
            {
                gameObject.AddComponent<Rigidbody>();
                this.GetComponent<Rigidbody>().AddForce(Vector3.forward * Power);
            }

            else if(Back)
            {
                gameObject.AddComponent<Rigidbody>();
                this.GetComponent<Rigidbody>().AddForce(Vector3.back * Power);
            }

            else if (Left)
            {
                gameObject.AddComponent<Rigidbody>();
                this.GetComponent<Rigidbody>().AddForce(Vector3.left * Power);
            }

            else if (Right)
            {
                gameObject.AddComponent<Rigidbody>();
                this.GetComponent<Rigidbody>().AddForce(Vector3.right * Power);
            }
        }

        if(checkPlayer && Destroyed)
        {
            Invoke("Fnish", 8f);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            checkPlayer = true;
        }
    }

    public void Fnish()
    {
        Destroy(this.gameObject);
    }
}
