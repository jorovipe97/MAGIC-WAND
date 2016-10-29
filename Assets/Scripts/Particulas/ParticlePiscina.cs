using UnityEngine;
using System.Collections;

public class ParticlePiscina : MonoBehaviour {

    [SerializeField]
    private float lifeTime = 2.6f;

    private float initTime;
    private float deadTime;
	
	// Update is called once per frame
	void OnEnable () {
        initTime = Time.time;
        deadTime = initTime + lifeTime;
	}

    void Update()
    {
        if (Time.time > deadTime)
            gameObject.SetActive(false);
    }
}
