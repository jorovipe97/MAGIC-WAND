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
}
