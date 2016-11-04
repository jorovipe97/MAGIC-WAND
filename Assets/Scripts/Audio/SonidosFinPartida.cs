using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SonidosFinPartida : MonoBehaviour {

	private AudioSource audioSource; 

	public AudioClip completado;
	public AudioClip gameOver;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        Puntuacion.OnLevelCompleted += NivelCompletado;
        Vidas2.OnNoMoreLifes += GameOver;
    }

	public void GameOver ()
	{
        Debug.Log("Has muerto puto, desde sonidosfinapartida.cs");
		ReproduceSonido (gameOver); 
	}

	public void NivelCompletado ()
	{
		ReproduceSonido (completado);
		Debug.Log ("Has ganado");
	}

	void ReproduceSonido(AudioClip sonido)
	{
        audioSource.PlayOneShot(sonido);
	}

    void OnDestroy()
    {
        // Dado que los eventos a los que nos subscribimos son estaticos
        // es decir, pertenecen a la clase y no a la instancia, cuando la escena
        // finaliza la instancia se destruye y este codigo va a intentar 
        // seguir accediendo al mismo evento aunque ya ha sido destruido
        // para evitar esto y hacer que se actualice en cada escena
        // es necesario desubscribirme de los eventos estaticos cuando la escena finaliza
        // Keep in mind that since static members don't belong to a specific instance, the variable only exists once and is shared between all instances of that class.
        // dado que cuando finaliza la escena se pierden todas las instancias la variable estatica de la funcion deja de existir
        Puntuacion.OnLevelCompleted -= NivelCompletado;
        Vidas2.OnNoMoreLifes -= GameOver;
    }
}
