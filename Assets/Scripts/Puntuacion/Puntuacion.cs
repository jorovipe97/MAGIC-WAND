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

    void OnDestroy()
    {
        // Dado que los eventos a los que nos subscribimos son estaticos
        // es decir, pertenecen a la clase y no a la instancia, cuando la escena
        // finaliza la instancia se destruye y este codigo va a intentar 
        // seguir accediendo al mismo evento aunque ya ha sido destruido
        // para evitar esto y hacer que se actualice en cada escena
        // es necesario desubscribirme de los eventos estaticos cuando la escena finaliza
        ContadorBloques.OnBloqueDestroy -= SubirPuntaje;
        ContadorBloques.OnZeroBloques -= ZeroBloques;
    }
}
