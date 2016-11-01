using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CambiarDeNivel : MonoBehaviour {

	public string NivelSiGana;
	public string NivelSiPierde = "MainMenu";
	public float retraso = 5f;

	void Start () {
		

		Vidas2.OnNoMoreLifes += ActivarCargaPierde;
		Puntuacion.OnLevelCompleted += ActivarCargaGana;
	
	}
	public void ActivarCargaGana() //
	{
		
		Invoke ("CargarNivelSiGana", retraso); // se pondra en espera cierto tiempo y ejecutara ese metodo
	}

	public void ActivarCargaPierde() //
	{

		Invoke ("CargarNivelSiPierde", retraso); // se pondra en espera cierto tiempo y ejecutara ese metodo
	}
	void CargarNivelSiGana()
	{
		SceneManager.LoadScene (NivelSiGana, LoadSceneMode.Single);
	}
	void CargarNivelSiPierde()
	{
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // 5.3

		SceneManager.LoadScene (NivelSiPierde, LoadSceneMode.Single);
	}

}
