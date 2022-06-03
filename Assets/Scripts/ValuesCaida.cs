using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ValuesCaida : MonoBehaviour
{

    public TextMeshProUGUI Y;
    public TextMeshProUGUI T;
    public TextMeshProUGUI velY;

    public void setValues(string tiempo, string posY, string veloY)
    {
        Y.text = tiempo;
        T.text = posY;
        velY.text = veloY;
    }
  
}
