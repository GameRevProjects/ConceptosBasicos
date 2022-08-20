using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Coin : MonoBehaviour, IInteractable
{
    private int amount;
    public AudioSource audioSource;

    private void Awake()
    {
        amount = Random.Range(1,3);
    }

    public void Interact(PlayerMovement player)
    {
        player.AddCoins(amount);
        audioSource.Play();
        GetComponent<MeshRenderer>().enabled = false;
        Destroy(this.gameObject, audioSource.clip.length);
    }
}
