using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour{
    public float Damgae = 1000f;

    private void OntriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("player")) return;

        if (playerController.PlayerInstance != null)
        {
            playerController.Health -= Damage * Time.deltaTime;
        }
    }
}
