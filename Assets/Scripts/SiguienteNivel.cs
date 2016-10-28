using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SiguienteNivel : MonoBehaviour {

    public delegate void LevelEvents();
    public static event LevelEvents OnUltimoNivel;

    public string nivelACargar;
	public float retraso;

	[ContextMenu("ActivarCarga")] // para ejecutar desde unity al darle click.
	// es para probar 
	public void ActivarCarga() //
	{
		Invoke ("CargarNivel", retraso); // se pondra en espera cierto tiempo y ejecutara ese metodo
	}

	void CargarNivel()
	{
		SceneManager.LoadScene (nivelACargar);
		
	}

	public bool EsUltimoNivel()
	{
		if (nivelACargar == "Portada") {
            OnUltimoNivel();
			return true;
		} 
		else
		{
			return false; 
		}
	}
}
