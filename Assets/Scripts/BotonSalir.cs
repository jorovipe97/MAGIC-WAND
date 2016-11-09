using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BotonSalir : MonoBehaviour {

	public bool salir;
	public ElementoInteractivo ImagenSalir;
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape)||ImagenSalir.pulsado)
		{
			if (salir) {
				Debug.Log ("Salimos del juego");
				Application.Quit (); 
			} 
			else
			{
				SceneManager.LoadScene("MainMenu");
			}
		}

	}
}
