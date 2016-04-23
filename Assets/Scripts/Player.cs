using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 5f;
    public GameObject missile;
    public Transform missileSpawn;

    AudioSource shootSound;
    
    // Use this for initialization
    void Start () {
        ResetPlayerObject();
        shootSound = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W) && transform.position.y < 4.2f)
        {
            transform.Translate (0 , speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x > -8.0f)
        {
            transform.Translate(-speed * Time.deltaTime , 0 , 0);
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y > -4.2f)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < 0f)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(missile,missileSpawn.position, missileSpawn.rotation);
            shootSound.Play();
        }
    }

    void ResetPlayerObject()
    {        
        transform.position = new Vector2(-8.0f, -0.0f);
    }
}
