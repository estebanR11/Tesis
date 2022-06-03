using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;
using System;

public class PanelNewton : MonoBehaviour
{

   [SerializeField] GameObject prefab;
    [SerializeField] GameObject instanciado;
    public void InstanciarPanel(float tiempo, float x, float y)
    {
        instanciado = Instantiate(prefab);
        string time = Math.Round(tiempo, 1).ToString();
        string xPos = Math.Round(x, 4).ToString();
        string yPos = Math.Round(y, 4).ToString();
        instanciado.GetComponent<ValuesNewton>().setValues(time, xPos, yPos);
        instanciado.transform.SetParent(this.gameObject.transform);
        instanciado.transform.localScale = new Vector3(1.5f, 1.5f, 1);


    }
}


