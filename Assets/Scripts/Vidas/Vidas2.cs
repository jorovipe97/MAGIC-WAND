using UnityEngine;
using System.Collections;

public class Vidas2 : MonoBehaviour {

    public delegate void Vidas2Events();
    public static event Vidas2Events OnNoMoreLifes;
    public static event Vidas2Events OnPierdeVida;

    private static int _vidas = 4;
    public int vidas
    {
        get { return _vidas; }
    }

    void Start()
    {
        pelota.OnBallDie += DisminuirVidas;
    }

    void DisminuirVidas()
    {
        Debug.Log("Oh no, una vida menos");
        _vidas--;
        OnPierdeVida();

        if (_vidas == 0)
        {
            OnNoMoreLifes();
        }
    }

    void AumentarVidas(int aumentar = 1)
    {
        _vidas += aumentar;
    }
}
