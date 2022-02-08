using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SetValuesBG : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tiempo;
    [SerializeField] TextMeshProUGUI xPos;
    [SerializeField] TextMeshProUGUI yPos;
    [SerializeField] TextMeshProUGUI angulo;
    [SerializeField] TextMeshProUGUI velIni;

    public void setValues(string t, string x, string y, string ang, string veli)
    {
        tiempo.text = t;
        xPos.text = x;
        yPos.text = y;
        angulo.text = ang;
        velIni.text = veli;
    }
  
}
