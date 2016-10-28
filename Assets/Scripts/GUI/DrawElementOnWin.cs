using UnityEngine;
using System.Collections;

public class DrawElementOnWin : MonoBehaviour {

    public GameObject[] elementsToDraw;

    // Use this for initialization
    void Start () {
        Puntuacion.OnLevelCompleted += DrawElements;
	}

    void DrawElements()
    {
        foreach (GameObject go in elementsToDraw)
        {
            go.SetActive(true);
        }
    }
}
