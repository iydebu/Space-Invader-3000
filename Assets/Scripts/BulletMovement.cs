using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 10f;
    public float destroyDistance = 12f;

    void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;

        if (transform.position.z > destroyDistance)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}