using UnityEngine;
using System.Collections;

public class ParticlePiscinaMaster : MonoBehaviour {

    private int contador = 0;

    public Bloque receiveBloquesEvents;

    void Awake()
    {
        //DontDestroyOnLoad(transform.gameObject);
    }
    
	// Use this for initialization
	void Start () {
        Bloque.OnBloqueDestroy += SelectParticulaFromPiscina; //El metodo se suscribe al evento y se llama cuando el evento se llame
	}
	
	void SelectParticulaFromPiscina(Vector3 posToMove)
    {
        /*if (gameObject == null)
        {
            Debug.Log("La piscina de objetos ha sido destruida");
            return;
        }*/
		if (contador > gameObject.GetComponent<Transform> ().childCount - 1) { // childCount = numero de hijos y se mira como en un array empezando desde 0 así que hay que restarle uno para llamar el ultimo hijo que si es.
			contador = 0; 
		}
        GameObject childSelected = gameObject.GetComponent<Transform>().GetChild(contador).transform.gameObject;
        childSelected.transform.position = posToMove;
        childSelected.SetActive(true);
        Debug.Log("Se destruyo un bloque en: " + posToMove);
        contador++;
    }

    void OnDestroy()
    {
        // Dado que los eventos a los que nos subscribimos son estaticos
        // es decir, pertenecen a la clase y no a la instancia, cuando la escena
        // finaliza la instancia se destruye y este codigo va a intentar 
        // seguir accediendo al mismo evento aunque ya ha sido destruido
        // para evitar esto y hacer que se actualice en cada escena
        // es necesario desubscribirme de los eventos estaticos cuando la escena finaliza
        Bloque.OnBloqueDestroy -= SelectParticulaFromPiscina;
    }
}
