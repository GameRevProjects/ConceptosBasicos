using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   public float speed = 5f;
   public float rotationSpeed = 50f;
   private int _coins = 0;
   
   public void AddCoins(int coins)
   {
      _coins += coins;
      Debug.Log("Total Coins: "+_coins);
   }

   void Update()
   {
      float horizontalInput = Input.GetAxis("Horizontal");
      float verticalInput = Input.GetAxis("Vertical");

      Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
      movementDirection.Normalize();

      transform.position = transform.position + movementDirection * (speed * Time.deltaTime);
      if (movementDirection != Vector3.zero)
         transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movementDirection), rotationSpeed * Time.deltaTime);
   }

   private void OnTriggerEnter(Collider other)
   {
      IInteractable interactable = other.GetComponent<IInteractable>();
      if (interactable != null)
      {
         interactable.Interact(this);
      }
   }

   public void ActivatePowerUp()
   {
      StartCoroutine(PowerUp());
   }

   private IEnumerator PowerUp()
   {
      Debug.Log("PowerUp: ON");
      speed = speed * 2;
      yield return new WaitForSeconds(2);
      speed = speed / 2;
      Debug.Log("PowerUp: OFF");
   }
}
