using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    public static SpawnPlayer Instance;

    public void Awake()
    {
        Instance = this;
    }

    public void SpawnThePlayer()
    {
        Instantiate(player, transform.position, transform.transform.rotation, transform);
    }
}
