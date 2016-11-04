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
            Debug.Log("sonando al chocar el bloque");
            PlaySoundOneShot(punto);	
		}
          if (otro.gameObject.CompareTag("Barra"))
          {
              PlaySoundOneShot(rebote);
              Debug.Log("sonando al chocar la barra");
          }
        if (otro.gameObject.CompareTag("Suelo"))
        {
            PlaySoundOneShot(muere);
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

    void OnDestroy()
    {
        // Dado que los eventos a los que nos subscribimos son estaticos
        // es decir, pertenecen a la clase y no a la instancia, cuando la escena
        // finaliza la instancia se destruye y este codigo va a intentar 
        // seguir accediendo al mismo evento aunque ya ha sido destruido
        // para evitar esto y hacer que se actualice en cada escena
        // es necesario desubscribirme de los eventos estaticos cuando la escena finaliza
        Vidas2.OnPierdeVida -= Muere;
    }
}
