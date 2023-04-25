using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMouvement : MonoBehaviour
{
    public float speed = 5f; // la vitesse du personnage

    // fonction appelée à chaque image
    void Update()
    {
        // récupère la valeur de l'axe horizontal (-1, 0 ou 1) et stocke le résultat dans une variable
        float horizontalInput = Input.GetAxis("Horizontal");

        // crée un vecteur de mouvement en utilisant la valeur d'entrée de l'axe horizontal et 0 pour l'axe y
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);

        // déplace le personnage selon le vecteur de mouvement et la vitesse
        transform.position += movement * speed * Time.deltaTime;
    }
}
