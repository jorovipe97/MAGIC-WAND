using UnityEngine;
using System.Collections;


public class Bloque : MonoBehaviour {
	
	public delegate void BloqueEvents(Vector3 position);

    public static event BloqueEvents OnBloqueDestroy;

	public GameObject efectoParticulas; // Pariticulas cuando se dañe el bloque

	//public Puntos puntos; 

    /// <summary>
    /// 1. Crea la particula en el lugar donde esta el bloque
    /// 2. Destruye el bloque
    /// </summary>
	void OnCollisionEnter() // Se llama en Is Trigger desactivado
	{
		Debug.Log ("Bloque destruido en Bloque.OnCollisionEnnter()");
        // Instantiate (efectoParticulas, transform.position, Quaternion.identity);
        OnBloqueDestroy(gameObject.transform.position);
        Destroy (gameObject);
		transform.SetParent (null); 
		//puntos.GanarPunto (); 
	}

}
