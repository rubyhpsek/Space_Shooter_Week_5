using UnityEngine;

public class Enemy : MonoBehaviour {


    private float enemySpeed;
    AudioSource explodeSound;

    GameManager gm;

    // Use this for initialization
    void Start () {       
        ResetEnemyObject();
        explodeSound = GetComponent<AudioSource>();
        gm = GameObject.Find ("GameManager").GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.left * enemySpeed * Time.deltaTime);
        if (transform.position.x <= -9.4f)
        {            
            ResetEnemyObject();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Missile")
        {
            explodeSound.Play();
            gm.AddScore(1);
            ResetEnemyObject();
            Destroy(other.gameObject);            
        }

        if (other.transform.tag == "Player")
        {
            explodeSound.Play();
            gm.SubtractScore(1);
            ResetEnemyObject();
            //other.transform.position = new Vector2(-8.0f, -0.0f);            
        }

        //if (other.transform.tag == "Player")
        //{
        //    Application.LoadLevel("ShooterGame_1");
        //}
    }

    void ResetEnemyObject()
    {
        enemySpeed = Random.Range(3f, 6f);
        transform.position = new Vector2(Random.Range(11.0f, 20.0f), Random.Range(4.2f, -4.2f));
    }

}
