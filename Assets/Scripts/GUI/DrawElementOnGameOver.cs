using UnityEngine;
using System.Collections;

public class DrawElementOnGameOver : MonoBehaviour {

    public GameObject[] elementsToDraw;

	// Use this for initialization
	void Start () {
        Vidas2.OnNoMoreLifes += DrawElements;
	}

    public void DrawElements()
    {
        foreach (GameObject go in elementsToDraw)
        {
            go.SetActive(true);
        }
    }
}
