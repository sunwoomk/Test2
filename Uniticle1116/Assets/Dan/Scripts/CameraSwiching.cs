using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwiching : MonoBehaviour
{
    private bool area1 = false;
    private bool area2 = false;
    private bool area3 = false;
    private bool area4 = false;
    private bool area5 = false;
    private bool area6 = false;

    public GameObject Incamera;

    //[SerializeField]
    //private GameObject Camera1;
    //[SerializeField]
    //private GameObject Camera2;
    //[SerializeField]
    //private GameObject Camera3;
    //[SerializeField]
    //private GameObject Camera4;
    //[SerializeField]
    //private GameObject Camera5;
    //[SerializeField]
    //private GameObject Camera6;

    protected virtual void Awake()
    {
        area1 = false;
        area2 = false;
        area3 = false;
        area4 = false;
        area5 = false;
        area6 = false;

        //Camera1.gameObject.SetActive(false);
        //Camera2.gameObject.SetActive(false);
        //Camera3.gameObject.SetActive(false);
        //Camera4.gameObject.SetActive(false);
        //Camera5.gameObject.SetActive(false);
        //Camera6.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        area1 = true;
        Incamera.transform.position = new Vector3(12.33f, 28.16f, -27.36f);
        Incamera.transform.rotation = Quaternion.Euler(36f, 45f, 0f);
        //Camera1.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if(area1)
        {
            //Camera1.gameObject.SetActive(true);
            Incamera.transform.position = new Vector3(12.33f, 28.16f, -27.36f);
            Incamera.transform.rotation = Quaternion.Euler(36f, 45f, 0f);
        }

        else if (area2)
        {
            //Camera2.gameObject.SetActive(true);
            Incamera.transform.position = new Vector3(35.31f, 28.16f, -14.51f);
            Incamera.transform.rotation = Quaternion.Euler(30.997f, 90f, 0f);
        }

        else if (area3)
        {
            //Camera3.gameObject.SetActive(true);
            Incamera.transform.position = new Vector3(98.76f, 29.25f, -7.549999f);
            Incamera.transform.rotation = Quaternion.Euler(45f, 290f, 0f);
        }

        else if (area4)
        {
            //Camera4.gameObject.SetActive(true);
            Incamera.transform.position = new Vector3(89.52f, 39.79f, 22.11f);
            Incamera.transform.rotation = Quaternion.Euler(90f, 0, 0f);
        }

        else if (area5)
        {
            //Camera5.gameObject.SetActive(true);
            Incamera.transform.position = new Vector3(85.193f, 22.365f, 31.338f);
            Incamera.transform.rotation = Quaternion.Euler(0f, 270f, 0f);
        }

        else if (area6)
        {
            //Camera6.gameObject.SetActive(true);
            Incamera.transform.position = new Vector3(15.25f, 6.65f, 24.64f);
            Incamera.transform.rotation = Quaternion.Euler(-21.331f, 52.428f, 0f);
        }

        else
        {

        }
    }

    public void AreasReset()
    {
        area1 = false;
        area2 = false;
        area3 = false;
        area4 = false;
        area5 = false;
        area6 = false;
    }

    public void WeherColling(string name)
    {
        if (name == "area1")
        {
            area1 = true;
        }

        else if (name == "area2")
        {
            area2 = true;
        }

        else if (name == "area3")
        {
            area3 = true;
        }

        else if (name == "area4")
        {
            area4 = true;
        }

        else if (name == "area5")
        {
            area5 = true;
        }

        else if (name == "area6")
        {
            area6 = true;
        }

        else
        {

        }
    }
}
