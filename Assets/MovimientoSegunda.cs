using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovimientoSegunda : MonoBehaviour
{
    [SerializeField] float timer = 0.0f;
    float time;

    [SerializeField] float maxTime = 0.5f;

    [SerializeField] PanelNewton panel;

    private void Start()
    {
        Rigidbody rb = this.transform.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
    }
    private void Update()
    {
        if(this.transform.localPosition.y >0)
        {
            if (timer > maxTime)
            {
                time += .5f;
                panel.InstanciarPanel(time, this.transform.position.x, this.transform.position.y);
                timer = 0;
            }
            else
            {
                timer += Time.deltaTime;
            }
        
        }
        else
        {
            Rigidbody rb = this.transform.GetComponent<Rigidbody>();    
            this.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);    
            rb.useGravity = false;
            rb.isKinematic = true;
        }
     
        
    }

    public void onStartClick()
    {
        panel.InstanciarPanel(time, this.transform.position.x, this.transform.position.y);
        timer = 0;
        time = 0;
        Rigidbody rb = this.transform.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.isKinematic = false;
    }
}
