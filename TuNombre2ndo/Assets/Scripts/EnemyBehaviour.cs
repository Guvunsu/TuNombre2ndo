using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private int points = 15;
    private GameObject parent;
    [SerializeField] bool activatedCoins = false;
    public GameObject coinsToSpawn;
    void Start()
    {
        // hago que el objeto que lleve este script sea padre de algun otro objeto  

        parent = gameObject.transform.parent.gameObject;
    }

  
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision) {

        // hago que el enemigo sea el padre de las monedas , si muere el padre , aparecen las monedas en el mapa, si no ,no y accedo a los puntos 

        if (collision.gameObject.CompareTag("Enemy"))
        {

            parent.SetActive(false);
            PoinstManager.Instance.addPoints(points);
            if (activatedCoins)
            {
                coinsToSpawn.SetActive(true);
            }
        }
    }
}
