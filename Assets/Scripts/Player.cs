using System;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public sealed class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public event Action<int> HealthChanged;

    public event Action Destroyed;

    public int Health => health;
    
    [SerializeField]
    private int health = 5;

    [SerializeField]
    private float speed = 10f;

    private CharacterController _characterController;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;

            _characterController = GetComponentInChildren<CharacterController>();
        }
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
