using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Vector3 rawInput;
    [SerializeField] float speed = 4f;
    Vector2 minBounds, maxBounds;
    [Header("Padding")]
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingLeft;
    Shooter shooter;

    void Start()
    {
        InitBounds();
        shooter = GetComponent<Shooter>();
    }
    void Update()
    {
        Move();
    }
    void OnFire(InputValue value)
    {
        shooter.isFiring = value.isPressed;;
    }
    void Move()
    {
        Vector2 newPos = transform.position + rawInput * speed * Time.deltaTime;
        newPos.x = Mathf.Clamp(newPos.x, minBounds.x, maxBounds.x);
        newPos.y = Mathf.Clamp(newPos.y, minBounds.y, maxBounds.y);
        transform.position = newPos;
    }
    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }
    void InitBounds()
    {
        minBounds = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        minBounds = new Vector2(minBounds.x + paddingLeft, minBounds.y + paddingBottom);
        maxBounds = new Vector2(maxBounds.x - paddingRight, maxBounds.y - paddingTop);
    }
}
