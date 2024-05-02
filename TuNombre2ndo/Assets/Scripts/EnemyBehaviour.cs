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
        parent = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
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
