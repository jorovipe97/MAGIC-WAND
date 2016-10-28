using UnityEngine;
using System.Collections;

public class Puntuacion : MonoBehaviour {

    public delegate void PuntuacionEvents();
    public static event PuntuacionEvents OnLevelCompleted;

    private int _puntuacion = 0;
    public int puntuacion
    {
        get { return _puntuacion; }
    }

    void Start()
    {
        ContadorBloques.OnBloqueDestroy += SubirPuntaje;
        ContadorBloques.OnZeroBloques += ZeroBloques;
    }

	private void SubirPuntaje()
    {
        Debug.Log("Un bloque menos, mas puntos ahora.");
        _puntuacion++;
    }

    private void ZeroBloques()
    {
        // Debug.Log("Ya no hay mas bloques nivel completado");
        OnLevelCompleted();
    }
}
