using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(HeroMover))]
[RequireComponent(typeof(HeroJumper))]
public class HeroInput : MonoBehaviour
{
    private PlayerInput _input;
    private HeroMover _mover;
    private HeroJumper _jumper;
    private HeroAttacker _attacker;

    private void Awake()
    {
        _mover = GetComponent<HeroMover>();
        _jumper = GetComponent<HeroJumper>();
        _attacker = GetComponent<HeroAttacker>();
        _input = new PlayerInput();

        _input.Player.Jump.performed += ctx => _jumper.Jump();
        _input.Player.Attack.performed += ctx => _attacker.Attack();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }
    private void FixedUpdate()
    {
        float direction = _input.Player.Move.ReadValue<float>();

        _mover.Move(direction);

    }
}
