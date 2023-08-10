using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    private void Awake()
    {
        instance = GetComponent<PlayerController>();
    }

    public Joystick joystick;
    public int life = 3;
    public int score = 0;
    public float ClampZUp;
    public float ClampZDown;
    public float TeleportX;
    public float speed = 10f;
    public GameObject bulletPrefab;
    public Transform[] bulletSpawnPoint;
    public float fireRate = 0.5f;
    public GameObject DieEffect;
    public float tiltAmount = 20f; // How much the ship should tilt when moving left or right
    public float tiltSpeed = 2f;  // How quickly the ship should reach the desired tilt angle
    private float nextFire = 0.0f;
    

    private void Update()
    {
        HandleMovement();
        HandleShooting();
        ClampPosition();
        Teleport();
    }

    private void HandleMovement()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        Vector3 movement = new Vector3(horizontal, 0,vertical);
        transform.position += movement * speed * Time.deltaTime;

        float desiredRotataion = horizontal * tiltAmount;
        Quaternion targetRotation = Quaternion.Euler(0, 0, -desiredRotataion);
        transform.rotation = Quaternion.Lerp(transform.rotation,targetRotation ,tiltSpeed * Time.deltaTime);
    }

    private void HandleShooting()
    {
        if ((Input.GetButton("Fire1") || Input.GetKey(KeyCode.Space))&& Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            foreach (Transform spwanPoint in bulletSpawnPoint) {
                Instantiate(bulletPrefab, spwanPoint.position, spwanPoint.rotation);
            }
        }
    }
    private void Teleport()
    {

        if(transform.position.x < -TeleportX)
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
        }
        else if(transform.position.x > TeleportX)
        {
            transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
        }
    }

    private void ClampPosition()
    {
       if(transform.position.z > ClampZUp)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, ClampZUp);
        }
       else if(transform.position.z < ClampZDown)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, ClampZDown);
        }
    }
    public void UpdateScore(int scoreValue)
    {
        score += scoreValue;
        UImanager.instance.UpdateScore(score);
    }

    public void Damage()
    {
        if(life < 1)
        {
            SpawnManager.instance.StopSpawning();
            Instantiate(DieEffect, transform.position, Quaternion.identity);
            UImanager.instance.GameOver();
        }
        else
        {
            life--;
            UImanager.instance.UpdateLife();
        }
    }
}

