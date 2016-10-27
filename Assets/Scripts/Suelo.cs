using UnityEngine;
using System.Collections;

public class Suelo : MonoBehaviour {

	public Vidas vidas; //Referencia al componente vidas

	void OnTriggerEnter()
	{
		vidas.PerderVida (); //llamar el componente de las vidas, perder vida.
	}


}
