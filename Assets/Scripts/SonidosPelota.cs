using UnityEngine;
using System.Collections;

public class SonidosPelota : MonoBehaviour {

	public AudioSource rebote;

	public AudioSource punto; 

	public AudioSource cae; 

	void OnCollisionEnter(Collision otro)
	{
		if (otro.gameObject.CompareTag("Bloque"))
		{
			punto.Play();	
		}
		else
		{
			rebote.Play (); 	
		}
	}

	void OnTriggerEnter()
	{
		cae.Play (); 
	}
}
