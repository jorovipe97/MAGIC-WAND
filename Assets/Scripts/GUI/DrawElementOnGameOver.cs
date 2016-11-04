using UnityEngine;
using System.Collections;

public class DrawElementOnGameOver : MonoBehaviour {

    public GameObject[] elementsToDraw;

	// Use this for initialization
	void Start () {
        Vidas2.OnNoMoreLifes += DrawElements;
	}

    public void DrawElements()
    {
        foreach (GameObject go in elementsToDraw)
        {
            go.SetActive(true);
        }
    }

    void OnDestroy()
    {
        // Dado que los eventos a los que nos subscribimos son estaticos
        // es decir, pertenecen a la clase y no a la instancia, cuando la escena
        // finaliza la instancia se destruye y este codigo va a intentar 
        // seguir accediendo al mismo evento aunque ya ha sido destruido
        // para evitar esto y hacer que se actualice en cada escena
        // es necesario desubscribirme de los eventos estaticos cuando la escena finaliza
        // Keep in mind that since static members don't belong to a specific instance, the variable only exists once and is shared between all instances of that class.
        // dado que cuando finaliza la escena se pierden todas las instancias la variable estatica de la funcion deja de existir
        Vidas2.OnNoMoreLifes -= DrawElements;
    }
}
