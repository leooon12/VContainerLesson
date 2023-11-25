using System;
using UnityEngine;
using VContainer;

public sealed class Player : MonoBehaviour
{
    public event Action<int> HealthChanged;

    public event Action Destroyed;

    public int Health => health;
    
    [SerializeField]
    private int health = 5;

    [SerializeField]
    private float speed = 10f;

    private CharacterController _characterController;
    
    [Inject]
    private void Construct(CharacterController characterController)
    {
        _characterController = characterController;
    }
    
    private void Update()
    {
        var movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        movement *= speed * Time.deltaTime;

        _characterController.Move(movement);
    }
    
    public void TakeDamage(int damage)
    {
        health = Mathf.Max(health - damage, 0);
        HealthChanged?.Invoke(health);

        if (health <= 0)
        {
            Destroy(gameObject);
            Destroyed?.Invoke();
        }
    }
}
