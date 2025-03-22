using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameoverUI : MonoBehaviour
{
    public bool Stage1;
    public bool Stage2;
    public bool GameoverTrigger;
    public bool GameClearTrigger;

    public GameObject overUI;
    public GameObject clearUI;

    public UnicycleController PlayerController;
    //public UnicycleController AnimationController;
    public Animation AnimController;

    public void Retry()
    {
        if (Stage1)
        {
            SceneManager.LoadScene("Area1");
        }

        else if (Stage2)
        {
            SceneManager.LoadScene("Area2");
        }

        else
        { }
    }

    public void Clear()
    {
        if (Stage1)
        {
            SceneManager.LoadScene("Area2");
        }

        else if (Stage2)
        {
            //πÃ¡§
        }
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("TestScene");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (GameoverTrigger)
            {
                if (overUI.activeSelf == false)
                {
                    overUI.SetActive(true);

                    PlayerController.enabled = false;
                    //AnimationController.enabled = false;
                    AnimController.enabled = false;
                }
            }

            else if(GameClearTrigger)
            {
                if(clearUI.activeSelf == false)
                {
                    clearUI.SetActive(true);

                    PlayerController.enabled = false;
                    //AnimationController.enabled = false;
                    AnimController.enabled = false;
                }
            }
        }
    }
}
