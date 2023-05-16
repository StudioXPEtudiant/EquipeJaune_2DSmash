using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f; // la vitesse du personnage
    public float jumpForce = 10f; // la force du saut
    public Transform groundCheck; // l'objet de vérification du sol
    public LayerMask groundLayer; // le layer du sol

    private Rigidbody2D rb;
    private bool isGrounded = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // fonction appelée à chaque image
    void Update()
    {
        // récupère la valeur de l'axe horizontal (-1, 0 ou 1) et stocke le résultat dans une variable
        float horizontalInput = Input.GetAxis("Horizontal");

        // crée un vecteur de mouvement en utilisant la valeur d'entrée de l'axe horizontal et 0 pour l'axe y
        Vector2 movement = new Vector2(horizontalInput, 0f);

        // déplace le personnage selon le vecteur de mouvement et la vitesse
        transform.position += (Vector3)movement * speed * Time.deltaTime;

        // vérifie si le personnage est au sol en lançant un cercle de rayons à partir de l'objet de vérification du sol
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        // permet au personnage de sauter si celui-ci est au sol
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
