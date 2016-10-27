using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BotonSalir : MonoBehaviour {

	public bool salir;
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (salir) {
				Debug.Log ("Salimos del juego");
				Application.Quit (); 
			} 
			else
			{
				SceneManager.LoadScene("Portada");
			}
		}

	}
}
