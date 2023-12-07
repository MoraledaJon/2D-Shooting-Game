using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private Transform startingPos;
    [SerializeField]
    private GameObject missile;
    [SerializeField]
    private ParticleSystem shootingEffect;
    public bool canAttack = true;

    // Update is called once per frame
    void Update()
    {
        if(canAttack)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(missile, startingPos.position, missile.transform.rotation, null);
                shootingEffect.Play();
            }
        }

    }
}
