using UnityEngine;
using System.Collections;

public class ParticlePiscinaMaster : MonoBehaviour {

    private int contador = 0;


	// Use this for initialization
	void Start () {
        Bloque.OnBloqueDestroy += SelectParticulaFromPiscina; //El metodo se suscribe al evento y se llama cuando el evento se llame

	}
	
	void SelectParticulaFromPiscina(Vector3 posToMove)
    {
		if (contador > gameObject.GetComponent<Transform> ().childCount - 1) { // childCount = numero de hijos y se mira como en un array empezando desde 0 así que hay que restarle uno para llamar el ultimo hijo que si es.
			contador = 0; 
		}
        GameObject childSelected = gameObject.GetComponent<Transform>().GetChild(contador).transform.gameObject;
        childSelected.transform.position = posToMove;
        childSelected.SetActive(true);
        Debug.Log("Se destruyo un bloque en: " + posToMove);
        contador++;
    }
}
