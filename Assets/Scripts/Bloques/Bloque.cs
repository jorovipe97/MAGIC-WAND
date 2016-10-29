using UnityEngine;
using System.Collections;

public delegate void BloqueEvents(Vector3 position);
public class Bloque : MonoBehaviour {

    public static event BloqueEvents OnBloqueDestroy;

	public GameObject efectoParticulas; // Pariticulas cuando se dañe el bloque

	//public Puntos puntos; 

    /// <summary>
    /// 1. Crea la particula en el lugar donde esta el bloque
    /// 2. Destruye el bloque
    /// </summary>
	void OnCollisionEnter() // Se llama en Is Trigger desactivado
	{

        // Instantiate (efectoParticulas, transform.position, Quaternion.identity);
        OnBloqueDestroy(gameObject.transform.position);
        Destroy (gameObject);
		transform.SetParent (null); 
		//puntos.GanarPunto (); 
	}

}
