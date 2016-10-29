using UnityEngine;
using System.Collections;

public class BalaDestroyerPisc : MonoBehaviour {
    
    [Tooltip("El tiempo de vida de la bala en segundos")]
    public float lifeTime = 10f;

    private float initTime;
    private float deadTime;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = gameObject.GetComponent<Transform>().position;
        if (Time.time > deadTime)
        {
            gameObject.GetComponent<Transform>().position = new Vector3(pos.x, -3f, pos.y);
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    public void SetBornTime()
    {
        initTime = Time.time;
        deadTime = initTime + lifeTime;
    }

}
