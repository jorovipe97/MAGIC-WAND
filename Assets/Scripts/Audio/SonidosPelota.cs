using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SonidosPelota : MonoBehaviour {

	public AudioClip rebote;
	public AudioClip punto;
	public AudioClip muere;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        Vidas2.OnPierdeVida += Muere;
    }

	void OnCollisionEnter(Collision otro)
	{
		if (otro.gameObject.CompareTag("Bloque"))
		{
            PlaySoundOneShot(punto);	
		}
		else
		{
            PlaySoundOneShot(rebote);
        }
	}

	void Muere()
	{
        PlaySoundOneShot(muere); 
	}

    void PlaySoundOneShot(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }
}
