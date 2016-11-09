using UnityEngine;
using System.Collections;


public class ContadorBloques : MonoBehaviour {
    public delegate void ContadorDeBloques(); // se crea el delegado 
    public static event ContadorDeBloques OnBloqueDestroy; // se crea el evento que avisa cuando hay un bloque menos. 
    public static event ContadorDeBloques OnZeroBloques; // se crea el evento que avisa cuando no hay mas bloques.
	  

	private bool ContadorSonido = true;

    private int countInitialBloques;


	void Start () {
        countInitialBloques = gameObject.GetComponent<Transform>().childCount; // se asocia el numero de hijos al contadorInicialBloques para saber cuantos bloques hay
        Debug.Log(countInitialBloques);
	}
	
	// Update is called once per frame
	void Update () {
        int actualBloquesCount = gameObject.GetComponent<Transform>().childCount; // se actualizan la cantidad de hijos que hay 
		//Debug.Log ("Contador de bloques: " + actualBloquesCount);
		if (actualBloquesCount < countInitialBloques)
        {
			// si la cantidad de hijos inicial es mayor a la actual es porque un bloque se destruyó y se llama el evento de que se destruyó un bloque.
            countInitialBloques = gameObject.GetComponent<Transform>().childCount;
            //Debug.Log("Un bloque se destruyo");
            OnBloqueDestroy(); 
        }

		if (actualBloquesCount == 0 && ContadorSonido == true)
        {
            OnZeroBloques();

			ContadorSonido = false;
        }
	}
}
