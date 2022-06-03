using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Reiniciar : MonoBehaviour
{
    public void onClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
