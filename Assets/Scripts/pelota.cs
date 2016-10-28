using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class pelota : MonoBehaviour {

	/*
	Rigidbody rig; // obtener acceso a referencia 

	void Awake() // asignar la referencia. se ejecta una vez al principio
	// para obtener referencias.
	{
		rig = GetComponent<Rigidbody> (); //intenta buscar un componente de este tipo
										  //dentro del objeto que tiene el script.
	}

	*/

	// Otra manera de hacer lo anterior es:
	public float velocidadInicial = 600f ; // velocidad de la pelota.

	public Rigidbody rig; // con esta variable obtengo referencia al primer componente.

	bool enJuego = false ; // para comprobar si la partida está en juego.

	Vector3 posicionInicial ;


	/*  //Una forma de obtener el acceso para el padre.

	Transform barra; //obtener acceso a la transform a barra

	void Awake()
	{
		barra = transform.parent.GetComponentInParent <Transform> (); // Buscar componente en el objeto que tenga como padre.
	}
	*/


	// La OTRa manera de tener acceso al padre
    public Transform barra; // y unity nos permite agregar algun objeto que tenga esta componente.
    public Barra barra2;

    public delegate void PelotaEvents();
    public static event PelotaEvents OnBallDie;

	// Use this for initialization
	void Start ()
	{
		posicionInicial = transform.position;
	}

	public void Reset()
	{
		transform.position = posicionInicial; // para que la pelota regrese a la posicion inicial.
		transform.SetParent (barra); // para que tenga padre, necesito referencia al objeto padre
		enJuego = false ;
		DetenerMovimiento ();
	}

	public void DetenerMovimiento ()
	{
		rig.isKinematic = true; 
		rig.velocity = Vector3.zero ;  // devuelve uno con todos los datos a cero.
	}
	// Update is called once per frame
	void Update () 
	{
		if(!enJuego && Input.GetButtonDown ("Fire1") ) // sin no estamos jugando y se presiona la tecla para comenzar
		{
			enJuego = true; 

			transform.SetParent (null); // para que no tenga padre

			rig.isKinematic = false; // quita el Is Kinematic

			rig.AddForce (new Vector3 (velocidadInicial*Random.Range(-1, 1), velocidadInicial, 0)); // activa una fuerza en la direccion del Vector3 
		}
	}

    void OnTriggerEnter(Collider other)
    {
        // Cuando la bola toque el suelo
        if (other.gameObject.tag.Equals("Suelo"))
        {
            // Debug.Log("La bola ha muerto oops");
            barra2.Reset();
            Reset();
            OnBallDie();
        }
    }
}
