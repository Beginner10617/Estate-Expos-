using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Knife : MonoBehaviour
{
    int currentSceneIndex;
    SpriteRenderer sprite;
    bool removing = false;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("GameOver");
            SceneManager.LoadScene(currentSceneIndex + 2);
        }
        if(!other.gameObject.CompareTag("Respawn"))
        {
            removing = true;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(removing)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a - Time.deltaTime);
            if(sprite.color.a <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
