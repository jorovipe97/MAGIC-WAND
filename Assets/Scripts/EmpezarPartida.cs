using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EmpezarPartida : MonoBehaviour {

	public ElementoInteractivo Pantalla;

	void Update () {
		if (Input.GetButtonDown ("Fire1")|| Pantalla.pulsado) 
		{
			Puntos.puntos = 0; 
			Vidas.vidas = 3;
			SceneManager.LoadScene ("Nivel 01", LoadSceneMode.Single);
		}
	}
}
