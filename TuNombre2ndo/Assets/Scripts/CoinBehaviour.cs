using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehaviour : MonoBehaviour {

    private int value = 10;

    void Start() {

    }

    void Update() {

    }
    private void OnCollisionEnter2D(Collision2D collision) {

        //sirve que si el jugador choca con la moneda , llamo a los puntos , los agrega , lo destruye antes y me sale el mensaje 

        if (collision.gameObject.CompareTag("Player")) {
            PoinstManager.Instance.addPoints(value);
            Destroy(gameObject);
        }
    }
}
