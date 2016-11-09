using UnityEngine;
using System.Collections;

public class Barra : MonoBehaviour {

	//Hola profe para hacer que la barra fuera cada vez más pequeña fue relativamente sencillo, lo unico que tuve que hacer fue que cuando se produgera
	// el evento del contador de bloques que dice cuando hay un bloque menos se suscribiera el metodo de ReducirTamaño
	public float velocidad = 20f;

	public ElementoInteractivo botonIzquierda;
	public ElementoInteractivo botonDerecha;

	Vector3 posicionInicial;
	Vector3 TamañoInicial;


	void Start () {
		
		posicionInicial = transform.position;
		TamañoInicial = transform.localScale;
		// acá cuando se escuche el evento el metodo se suscribe y se ejecuta
        Puntuacion.OnLevelCompleted += DisableGameObject;
        Vidas2.OnNoMoreLifes += DisableGameObject;
		ContadorBloques.OnBloqueDestroy += ReducirTamaño;  
	}

	public void Reset()
	{
		transform.position = posicionInicial;
	}

	void Update () { 
		float direccion;
		if (botonIzquierda.pulsado) {
			direccion = -1;
		} else {
			if (botonDerecha.pulsado) {
				direccion = 1;
			} else {
				direccion = Input.GetAxisRaw("Horizontal");
			}
		}
		//float tecladoHorizontal = Input.GetAxisRaw("Horizontal");
		float posX = transform.position.x + (direccion/*tecladoHorizontal*/* velocidad * Time.deltaTime);
		transform.position = new Vector3 (Mathf.Clamp (posX, -8, 8), transform.position.y, transform.position.z);
		//El mathf.Clamp hace que la posicion solo oxile entre esos así, esto para limitar que la barra se salga o supere las barreras (limites). 
	}

    void DisableGameObject()
    {
        enabled = false;
    }

    void OnDestroy()
    {	//
        // Dado que los eventos a los que nos subscribimos pertenecen a la clase y no a la instancia, cuando la escena
        // finaliza la instancia se destruye y este codigo va a intentar 
        // seguir accediendo al mismo evento aunque ya ha sido destruido
        // para evitar esto y hacer que se actualice en cada escena
        // es necesario desubscribirme de los eventos  cuando la escena finaliza
        // dado que cuando finaliza la escena se pierden todas las instancias la variable de la funcion deja de existir
        Puntuacion.OnLevelCompleted -= DisableGameObject;
        Vidas2.OnNoMoreLifes -= DisableGameObject;
		ContadorBloques.OnBloqueDestroy -= ReducirTamaño;

    }

	void ReducirTamaño()
	{
		transform.localScale = new Vector3 ((transform.localScale.x)- 0.08f, transform.localScale.y, transform.localScale.z);// reduce un poco el tamaño de la barra con respecto al eje x y los otros dos ejes los deja como estaba
	}
}
