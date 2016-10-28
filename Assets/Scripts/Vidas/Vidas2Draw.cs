using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Vidas2Draw : MonoBehaviour {

    public Vidas2 vidas;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Text>().text = "Vidas: " + vidas.vidas;
	}
}
