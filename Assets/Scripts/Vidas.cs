using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Vidas : MonoBehaviour {

	public  static int vidas = 4 ;

	public pelota pelota ; 

	public Barra barra;

	public Text textoVidas ; // para inicializar las la referencia al texto vidas. 

	public GameObject gameOver;

	public SiguienteNivel SiguienteNivel; 

	public SonidosFinPartida sonidosFinPartida;

	void Star()
	{
		ActualizarMarcadorVidas ();
	}

	void ActualizarMarcadorVidas()
	{
		textoVidas.text = "Vidas : " + Vidas.vidas; 
	}

	public void PerderVida()
	{

		if (vidas <= 0) return; 

		Vidas.vidas --;
		ActualizarMarcadorVidas (); 


		if (vidas <= 0) {

			sonidosFinPartida.GameOver ();
			//Mostrar GameOver
			gameOver.SetActive(true);

			pelota.DetenerMovimiento ();
			barra.enabled = false; 

			SiguienteNivel.nivelAlCargar = "MainMenu";
			SiguienteNivel.ActivarCarga ();

		} else {
			barra.Reset ();
			pelota.Reset (); 
		}
	}


}
