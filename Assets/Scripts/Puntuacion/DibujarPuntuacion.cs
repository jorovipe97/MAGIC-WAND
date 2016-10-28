using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DibujarPuntuacion : MonoBehaviour {

    public Puntuacion puntuacionCtrl;
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Text>().text = "Puntos: " + puntuacionCtrl.puntuacion;
	}
}
