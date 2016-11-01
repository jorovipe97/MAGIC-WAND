using UnityEngine;
using System.Collections;


public class ContadorBloques : MonoBehaviour {
    public delegate void ContadorDeBloques();
    public static event ContadorDeBloques OnBloqueDestroy;
    public static event ContadorDeBloques OnZeroBloques;

	private bool ContadorSonido = true;

    private int countInitialBloques;

	// Use this for initialization
	void Start () {
        countInitialBloques = gameObject.GetComponent<Transform>().childCount;
        Debug.Log(countInitialBloques);
	}
	
	// Update is called once per frame
	void Update () {
        int actualBloquesCount = gameObject.GetComponent<Transform>().childCount;
        if (actualBloquesCount < countInitialBloques)
        {
            countInitialBloques = gameObject.GetComponent<Transform>().childCount;
            //Debug.Log("Un bloque se destruyo");
            OnBloqueDestroy();
        }

		if (actualBloquesCount == 0 && ContadorSonido == true)
        {
            OnZeroBloques();

			ContadorSonido = false;
        }
	}
}
