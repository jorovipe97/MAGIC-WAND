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
}
