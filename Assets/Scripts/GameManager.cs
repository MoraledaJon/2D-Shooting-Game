using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private bool canClick = true;
    public float cooldownTime = 1.0f;
    private bool spacePressed = false;

    public void StartGame()
    {
        if (canClick && !spacePressed) 
        {
            StartCoroutine(StartCR());

            // Start the cooldown
            StartCoroutine(ButtonCooldown());
        }

    }

    IEnumerator StartCR()
    {
        SpawnPlayer.Instance.SpawnThePlayer();

        ScoreManager.Instance.anim.SetTrigger("startGame");

        yield return new WaitForSeconds(1f);

        SpawnManager.Instance.Spawn(true);
    }

    public void RestartGame()
    {
        if (canClick && !spacePressed)
        {
            StartCoroutine(RestartCR());

            // Start the cooldown
            StartCoroutine(ButtonCooldown());
        }

    }


    IEnumerator RestartCR()
    {
        ScoreManager.Instance.ResetScore();

        GameObject world = GameObject.Find("World");

        world.GetComponent<ParticleSystem>().Clear();
        world.GetComponent<ParticleSystem>().Play();

        SpawnPlayer.Instance.SpawnThePlayer();

        yield return new WaitForSeconds(1f);

         
        SpawnManager.Instance.Spawn(true);
    }

    private IEnumerator ButtonCooldown()
    {
        canClick = false;
        yield return new WaitForSeconds(cooldownTime);
        canClick = true;
    }
}
