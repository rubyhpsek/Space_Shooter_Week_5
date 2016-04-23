using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

    public float missileSpeed = 10f;

    // Use this for initialization
    void Start () {	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.right* missileSpeed * Time.deltaTime);
        if (transform.position.x >= 10.0f)
        {
            Destroy(gameObject);
        }
    }
}
