using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class Medicion : MonoBehaviour
{
    [SerializeField]float time = 0.0f;
    [SerializeField] GameObject sphere;
    [SerializeField] bool finished;
    [SerializeField] PanelCaidaLibre panel;
    float tiempo =0.0f;
    // Update is called once per frame
    bool iniciarSim = false;

    public float tiempoEjec = 0.0f;

    public float velocidadInicial;
    public float gravedad;
    // public float velocidad;
    [SerializeField] float h;

    [SerializeField] Slider slide;
    [SerializeField] TextMeshProUGUI texto;
    [SerializeField] float alturaInicial;
    [SerializeField] float timeEJec;
    private void Start()
    {
        texto.text = sphere.transform.position.y.ToString();
        slide.value = sphere.transform.position.y;
    }
    void Update()
    {
        if(iniciarSim == true && finished==false)
        {
            if (h <= 0.0f)
            {
                string pos = Math.Round(sphere.transform.position.y, 2).ToString();
            
                finished = true;
           
       
            }
            if (!finished)
            {
                timeEJec += Time.deltaTime;
                h = (0.5f * Physics.gravity.y * Mathf.Pow(timeEJec,2)) + alturaInicial;
                Debug.Log(-0.5f * gravedad * timeEJec);


                sphere.transform.position = new Vector3(0,h,0);

                if (time <= 0.0)
                {   
                    tiempo += 0.5f;
                    string pos = Math.Round(sphere.transform.position.y, 2).ToString();
                    float velFinal = Physics.gravity.y * timeEJec;
                    string finalV = Math.Round(velFinal,2).ToString();
                    panel.instanciarPrefab(tiempo.ToString(), pos, finalV);

                    time = 0.5f;
                }
                else
                {
                    time -= Time.deltaTime;
                }

            }
        }
       


    }

    public void iniciar()
    {
        string pos = Math.Round(sphere.transform.position.y, 2).ToString();
        panel.instanciarPrefab(tiempo.ToString(), pos, "");
        h = (0.5f * Physics.gravity.y * Mathf.Pow(timeEJec, 2)) + 100;
        time = .5f;
        alturaInicial = sphere.transform.position.y;
        //iniciarSim = true; sphere.GetComponent<Rigidbody>().useGravity = true;
        iniciarSim = true;
        slide.interactable = false;
        


    }

 
    public void onValueChange()
    {
        h = slide.value;
        sphere.transform.localPosition = new Vector3(0, slide.value, 0);
        texto.text = slide.value.ToString();
    }
}
