using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private ParticleSystem _particleSystem;
    [SerializeField]
    private ParticleSystem scoreEff;


    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + (_speed * Time.deltaTime), transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            ParticleSystem dieEffect = Instantiate(_particleSystem, transform.position, Quaternion.identity);
            ParticleSystem scoreEffect = Instantiate(scoreEff, transform.position, Quaternion.identity);
            ScoreManager.Instance.AddScore(100);
            dieEffect.Play();
            scoreEffect.Play();
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

}
