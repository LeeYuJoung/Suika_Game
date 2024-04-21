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
            // 오브젝트 x값을 마우스 x값으로 
            PlanetMove();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            // 오브젝트 떨어지게 하기
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
        // Screen 좌표계인 mousePosition을 World 좌표계로 변경
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // 오브젝트는 X로만 움직여야 하기에 y 고정
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
        // 마우스 버튼을 때면 gravity scale 값을 넣어 아래로 떨어지게 하기
        planet.GetComponent<Rigidbody2D>().gravityScale = 2;
    }
}
