using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner4 : GetBird
{
    public GameObject birdPre;

    private GameObject InBird;

    private bool birdCheck;

    // Start is called before the first frame update
    void Start()
    {
        speed = 15f;
        Time_Respawn = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time_Respawn > 0f)
        {
            Time_Respawn -= Time.deltaTime;
            if (birdCheck)
            {
                InBird.transform.rotation = Quaternion.Euler(0, 180, 0);
                InBird.transform.Translate(Vector3.forward * speed * Time.deltaTime);

                if (Time_Destroy > 0f)
                {
                    Time_Destroy -= Time.deltaTime;
                }

                else if (Time_Destroy < 0f)
                {
                    Destroy(InBird);
                    birdCheck = false;
                }
            }
        }

        else
        {

        }
    }

    private void LateUpdate()
    {
        if (Time_Respawn < 0f)
        {
            Time_Respawn = 2.6f;
            Time_Destroy = 2f;
            InBird = Instantiate(birdPre, this.gameObject.transform.position, transform.rotation);
            birdCheck = true;
        }
    }
}
