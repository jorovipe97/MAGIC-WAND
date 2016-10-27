using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EmpezarPartida : MonoBehaviour {

	void Update () {
		if (Input.GetButtonDown ("Fire1")) 
		{
			Puntos.puntos = 0; 
			Vidas.vidas = 3;
			SceneManager.LoadScene ("Nivel 01");
		}
	}
}
