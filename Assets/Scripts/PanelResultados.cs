using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;
using System;

public class PanelResultados : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] GameObject instanciado;
    public void InstanciarPanel(float tiempo, float x, float y, float angulo, float velocidadInicial)
    {
        instanciado = Instantiate(prefab);
        string time = Math.Round(tiempo, 2).ToString();
        string xPos = Math.Round(x, 4).ToString();
        string yPos = Math.Round(y, 4).ToString();
        string ang = Math.Round(angulo, 4).ToString();
        string veli = Math.Round(velocidadInicial, 4).ToString();

        instanciado.GetComponent<SetValuesBG>().setValues(time,xPos,yPos,ang,veli);
        instanciado.transform.SetParent(this.gameObject.transform);


    }
}
