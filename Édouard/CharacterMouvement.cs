C#
Copy code
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMouvement : MonoBehaviour
{
    public float speed = 5f; // la vitesse du personnage
    public float jumpForce = 7f; // la force du saut du personnage
    public bool isGrounded; // variable qui stocke si le personnage touche le sol

    // fonction appelée à chaque image
    void Update()
    {
        // récupère la valeur de l'axe horizontal (-1, 0 ou 1) et stocke le résultat dans une variable
        float horizontalInput = Input.GetAxis("Horizontal");

        // crée un vecteur de mouvement en utilisant la valeur d'entrée de l'axe horizontal et 0 pour l'axe y
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);

        // déplace le personnage selon le vecteur de mouvement et la vitesse
        transform.position += movement * speed * Time.deltaTime;

        // détecte si le personnage touche le sol
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.0f);

        // si le joueur appuie sur la touche de saut et que le personnage touche le sol
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // ajoute une force de saut au personnage
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}

