using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] int sneneNumber;

    public void StartGame()
    {
        SceneManager.LoadScene(sneneNumber);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
