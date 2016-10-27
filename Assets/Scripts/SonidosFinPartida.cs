using UnityEngine;
using System.Collections;

public class SonidosFinPartida : MonoBehaviour {

	public AudioSource audioSource ; 

	public AudioClip completado;

	public AudioClip gameOver; 

	public void GameOver ()
	{
		ReproduceSonido (gameOver); 
	}

	public void NivelCompletado ()
	{
		ReproduceSonido (completado); 
	}

	void ReproduceSonido(AudioClip sonido)
	{
		audioSource.clip = sonido;
		audioSource.loop = false;
		audioSource.Play (); 
	}
}
