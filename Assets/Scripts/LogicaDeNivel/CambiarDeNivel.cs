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

    void OnDestroy()
    {
        // Dado que los eventos a los que nos subscribimos son estaticos
        // es decir, pertenecen a la clase y no a la instancia, cuando la escena
        // finaliza la instancia se destruye y este codigo va a intentar 
        // seguir accediendo al mismo evento aunque ya ha sido destruido
        // para evitar esto y hacer que se actualice en cada escena
        // es necesario desubscribirme de los eventos estaticos cuando la escena finaliza
        Vidas2.OnNoMoreLifes -= ActivarCargaPierde;
        Puntuacion.OnLevelCompleted -= ActivarCargaGana;
    }

}
