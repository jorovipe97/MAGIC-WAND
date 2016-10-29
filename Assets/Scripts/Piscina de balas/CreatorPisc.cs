using UnityEngine;
using System.Collections;

public class CreatorPisc : MonoBehaviour {

    public KeyCode keyTrigger = KeyCode.Space;
    public GameObject bala;
    private GameObject[] balas;

    public int tamañoPiscina = 10;
    public float YPosPiscina = -3f;

    private Vector3 goPosition;
    private int contador = 0;

    void Start()
    {
        goPosition = gameObject.GetComponent<Transform>().position;

        balas = new GameObject[this.tamañoPiscina];
        for (int i = 0; i < this.tamañoPiscina; i++)
        {
            balas[i] = Instantiate(this.bala);
            balas[i].GetComponent<Rigidbody>().isKinematic = true;
            balas[i].GetComponent<Transform>().position = new Vector3(goPosition.x, this.YPosPiscina, goPosition.z + (i * 2));
        }
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyDown(this.keyTrigger))
        {
            if (contador >= this.tamañoPiscina)
            {
                contador = 0;
            }

            balas[contador].GetComponent<Transform>().position = new Vector3(goPosition.x, goPosition.y, goPosition.z);
            balas[contador].GetComponent<Rigidbody>().isKinematic = false;
            balas[contador].GetComponent<BalaDestroyerPisc>().SetBornTime();
            contador++;            
        }
    }

}
