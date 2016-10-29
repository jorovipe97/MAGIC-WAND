using UnityEngine;
using System.Collections;

public class ParticlePiscinaMaster : MonoBehaviour {

    private int contador = 0;


	// Use this for initialization
	void Start () {
        Bloque.OnBloqueDestroy += SelectParticulaFromPiscina;
	}
	
	void SelectParticulaFromPiscina(Vector3 posToMove)
    {
        if (contador > gameObject.GetComponent<Transform>().childCount - 1)
            contador = 0; 
        GameObject childSelected = gameObject.GetComponent<Transform>().GetChild(contador).transform.gameObject;
        childSelected.transform.position = posToMove;
        childSelected.SetActive(true);
        Debug.Log("Se destruyo un bloque en: " + posToMove);
        contador++;
    }
}
