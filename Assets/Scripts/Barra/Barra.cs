using UnityEngine;
using System.Collections;

public class Barra : MonoBehaviour {

	public float velocidad = 20f;

	Vector3 posicionInicial;

	// Use this for initialization
	void Start () {
		
		posicionInicial = transform.position;
        Puntuacion.OnLevelCompleted += DisableGameObject;
        Vidas2.OnNoMoreLifes += DisableGameObject;
	}

	public void Reset()
	{
		transform.position = posicionInicial;
	}
	// Update is called once per frame
	void Update () { // se ejecuta el codigo tantas veces como segundos haya
		float tecladoHorizontal = Input.GetAxisRaw("Horizontal");
		float posX = transform.position.x + (tecladoHorizontal* velocidad * Time.deltaTime);
		transform.position = new Vector3 (Mathf.Clamp(posX,-8,8),transform.position.y,transform.position.z);
	}

    void DisableGameObject()
    {
        enabled = false;
    }

    void OnDestroy()
    {
        // Dado que los eventos a los que nos subscribimos son estaticos
        // es decir, pertenecen a la clase y no a la instancia, cuando la escena
        // finaliza la instancia se destruye y este codigo va a intentar 
        // seguir accediendo al mismo evento aunque ya ha sido destruido
        // para evitar esto y hacer que se actualice en cada escena
        // es necesario desubscribirme de los eventos estaticos cuando la escena finaliza
        Puntuacion.OnLevelCompleted -= DisableGameObject;
        Vidas2.OnNoMoreLifes -= DisableGameObject;
    }
}
