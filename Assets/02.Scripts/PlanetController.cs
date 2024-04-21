using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public GameObject[] planetPrefabs;
    public Vector2[] planetPos;
    private GameObject planet;

    void Start()
    {
        SpawnPlanet();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            // ������Ʈ x���� ���콺 x������ 
            PlanetMove();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // ������Ʈ �������� �ϱ�
            PlanetDrop();
        }
    }

    public void SpawnPlanet()
    {
        int rdm = Random.Range(0, planetPrefabs.Length);
        planet = Instantiate(planetPrefabs[rdm], planetPos[rdm], Quaternion.identity);
    }

    public void PlanetMove()
    {
        // Screen ��ǥ���� mousePosition�� World ��ǥ��� ����
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // ������Ʈ�� X�θ� �������� �ϱ⿡ y ����
        mousePos.y = planet.transform.position.y;
        mousePos.z = 0;

        if(mousePos.x <= -2.5)
        {
            mousePos.x = -2.5f;
        }
        else if(mousePos.x >= 2.5)
        {
            mousePos.x = 2.5f;
        }

        planet.transform.position = mousePos;
    }

    public void PlanetDrop()
    {
        // ���콺 ��ư�� ���� gravity scale ���� �־� �Ʒ��� �������� �ϱ�
        planet.GetComponent<Rigidbody2D>().gravityScale = 2;
    }
}
