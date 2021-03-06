using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class BallLauncher : MonoBehaviour
{
	public Rigidbody ball;
	public Transform target;
	[SerializeField] float posicionInicial;

	[SerializeField] TextMeshProUGUI textoTiempo;

	[SerializeField] TextMeshProUGUI textoAngulo;
	[SerializeField] TextMeshProUGUI textoVelocidad;
	[SerializeField] Slider velocidadSlider;
	[SerializeField] Slider anguloSlider;
	[SerializeField] float velocidad;
	[SerializeField] float anguloGrados;
	[SerializeField] float anguloRadianes;

	float tiempo = 0.0f;
	[SerializeField] float tiempoEntrePanel = 0.0f;
	float resetDeTiempo = 0.5f;


	bool isRunning = false;
	[SerializeField] PanelResultados panel;
	[SerializeField] Vector3 lastVelocity;



	public float h = 0;
	public float gravity = 9.8f;

	public float yInicial;
	public float xInicial;

	bool inicial = true;

	[SerializeField] GameObject obj;
	[SerializeField] Text texto;
	// Start is called before the first frame update
	void Start()
    {
		ball.useGravity = false;
		cambiarVelocidad();
		cambiarAngulo();
	
		

}

	public void cambiarVelocidad()
    {
		velocidad = velocidadSlider.value;
		textoVelocidad.text = Math.Round(velocidad, 2).ToString();
		calcularAltura();
	}

	public void cambiarAngulo()
    {
		anguloGrados = anguloSlider.value;
		anguloRadianes = anguloGrados * (Mathf.PI / 180);
		textoAngulo.text = Math.Round(anguloGrados, 2).ToString();
		calcularAltura();

		//Debug.Log(h);
	}

	void calcularAltura()
    {
		h = (Mathf.Pow(velocidad, 2) * Mathf.Pow(Mathf.Sin(anguloRadianes), 2)) / (2 * (-gravity));
	}
    // Update is called once per frame
    void Update()
    {
        if (inicial)
        {
			posicionInicial = obj.transform.position.y;
			yInicial = posicionInicial;
			xInicial = obj.transform.position.x;
		}        
	
		if (isRunning == true)
		{
			tiempo += Time.deltaTime;
			tiempoEntrePanel += Time.deltaTime;
			if (tiempoEntrePanel >= resetDeTiempo)
            {
				tiempoEntrePanel = 0.0f;
				panel.InstanciarPanel(tiempo, (transform.position.x- xInicial), (transform.position.y - yInicial) , anguloGrados, velocidad);
			}
			textoTiempo.text = "Tiempo: " + tiempo;

			if(ball.transform.position.y< posicionInicial- 1f)
            {
				pausar();

            }


        }
		
	}


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Finish"))
        {
			isRunning = false;
			pausar();
        }
    }


    public void Launch()
	{
		yInicial = ball.transform.position.y;
		isRunning = true;
		inicial = false;
		panel.InstanciarPanel(tiempo, transform.position.x - xInicial, transform.position.y - yInicial, anguloGrados, velocidad);
		
		

		Physics.gravity = Vector3.up * gravity;
		ball.useGravity = true;

		ball.velocity = CalculateLaunchData().initialVelocity;
	}

	LaunchData CalculateLaunchData()
	{
		float displacementY = target.position.y - ball.position.y;

		float time = Mathf.Sqrt(-2 * h / gravity) + Mathf.Sqrt(2 * (displacementY - h) / gravity);
		Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * h);
		Vector3 velocityX = (Vector3.right * velocidad * Mathf.Cos(anguloRadianes));	
	
		return new LaunchData(velocityX + velocityY * -Mathf.Sign(gravity), time);
	}

	

	struct LaunchData
	{
		public readonly Vector3 initialVelocity;
		public readonly float timeToTarget;

		public LaunchData(Vector3 initialVelocity, float timeToTarget)
		{
			this.initialVelocity = initialVelocity;
			Debug.Log(initialVelocity);
			this.timeToTarget = timeToTarget;
		}

	}

	public void reiniciar()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
    }

	public void pausar()
	{
		ball.useGravity = false;
		isRunning = false;
		ball.velocity = new Vector3(0,0,0);
	}
}
