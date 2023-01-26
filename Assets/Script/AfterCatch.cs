using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterCatch : MonoBehaviour
{
    public static void StartNew()
    {
        SceneManager.LoadScene("Tarik");
        Time.timeScale = 1;
    }
}
