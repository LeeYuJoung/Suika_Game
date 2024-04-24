using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    public enum PLANET
    {
        Mercury,
        Venus,
        Earth,
        Mars,
        Jupiter,
        Saturn,
        Uranus,
        Neptune,
        Sun
    }
    public PLANET currentPlanet;

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

        if (collision.collider.CompareTag("Planet"))
        {
            if(currentPlanet == collision.collider.GetComponent<PlanetManager>().currentPlanet)
            {
                GameObject.Find("SpawnPosition").GetComponent<PlanetController>().UpgradePlanet(transform.position, (int)currentPlanet + 1);
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }

        isGround = true;
        GameObject.Find("SpawnPosition").GetComponent<PlanetController>().SpawnPlanet();
    }
}
