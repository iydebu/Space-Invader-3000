using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float Maxspeed = 4.0f;
    public float MinSpeed = 7.0f;
    public float destroyDistance = 12f;
    public GameObject DestroyEffect;
    public int score = 10;
    private float speed;
    private GameObject player;

    private void Start()
    {
        speed = Random.Range(MinSpeed, Maxspeed);
    }

    private void Update()
    {
        MoveTowardsPlayer();
        if (transform.position.z < destroyDistance)
        {
            Destroy(gameObject);
        }
    }

    void MoveTowardsPlayer()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Bullet"));
        {
            PlayerController.instance.UpdateScore(score);
            Instantiate(DestroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);        // Destroy this enemy
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController.instance.Damage();   
            Instantiate(DestroyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);        // Destroy this enemy
        }
    }
}
