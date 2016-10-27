using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SiguienteNivel : MonoBehaviour {

	public string nivelAlCargar;
	public float retraso;

	[ContextMenu("ActivarCarga")] // para ejecutar desde unity al darle click.
	// es para probar 
	public void ActivarCarga() //
	{
		Invoke ("CargarNivel", retraso); // se pondra en espera cierto tiempo y ejecutara ese metodo
	}

	void CargarNivel()
	{
		if (!EsultimoNivel ()) 
		{
			Vidas.vidas++; 
		}
		SceneManager.LoadScene (nivelAlCargar);
		
	}

	public bool EsultimoNivel()
	{
		if (nivelAlCargar == "Portada") {
			return true;
		} 
		else
		{
			return false; 
		}

		//return nivelAlCargar == "Portada";
	}
}
