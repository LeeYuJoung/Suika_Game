using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    public bool isGround = false;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ceiling"))
        {
            Debug.Log("Game Over");
            Time.timeScale = 0;
            return;
        }

        if (collision.collider.CompareTag("Wall") || isGround)
        {
            return;
        }

        isGround = true;
        GameObject.Find("SpawnPosition").GetComponent<PlanetController>().SpawnPlanet();
    }
}
