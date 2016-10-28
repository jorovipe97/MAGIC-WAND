using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Puntos : MonoBehaviour {

	public static int puntos;

	public Text textoPuntos;

	public GameObject nivelCompletado;

	public GameObject juegoCompletado; 

	public SiguienteNivel siguienteNivel; 

	public pelota pelota; 

	public Transform contenedorBloques;

	public Barra barra;

	public SonidosFinPartida sonidosFinPartida;

	// Use this for initialization
	void Start () {
		
		ActualizarMarcadorPuntos (); 

	}

	void ActualizarMarcadorPuntos()
	{
		textoPuntos.text = "Puntos : " + Puntos.puntos;
	}

	public void GanarPunto ()
	{/*
		Puntos.puntos++; 
		ActualizarMarcadorPuntos (); */

		if (contenedorBloques.childCount <= 0) 
		{
			//pelota.DetenerMovimiento ();
			barra.enabled = false; 

			if (siguienteNivel.EsUltimoNivel ()) 
			{
				juegoCompletado.SetActive ( true);

			}
			else
			{
				nivelCompletado.SetActive ( true); 
			}
			sonidosFinPartida.NivelCompletado (); 
			siguienteNivel.ActivarCarga ();
		}
	}
}
