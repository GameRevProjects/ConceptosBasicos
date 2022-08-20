using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour, IInteractable
{
    public AudioSource audioSource;
    public void Interact(PlayerMovement player)
    {
        player.ActivatePowerUp();
        audioSource.Play();
        GetComponent<MeshRenderer>().enabled = false;
        Destroy(this.gameObject, audioSource.clip.length);
    }
}
