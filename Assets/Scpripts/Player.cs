using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float offsetFromWall = 0.01f;
    private bool isMoving;
    private Vector2 direction;
    private float screenHalfWidth;
    private float screenHalfHeight;
    private Camera mainCamera;
    private float playerHalfWidth;
    private float playerHalfHeight;

    private void Start()
    {
        mainCamera = Camera.main;
        screenHalfWidth = mainCamera.orthographicSize * mainCamera.aspect;
        screenHalfHeight = mainCamera.orthographicSize;
        
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        if (renderer == null) return;
        playerHalfWidth = renderer.bounds.size.x / 2;
        playerHalfHeight = renderer.bounds.size.y / 2;
    }

    private void Update()
    {
        if (!isMoving) return;
        CheckScreenBounds();
        MovePlayer();
    }

    public void StartMoving()
    {
        isMoving = true;
        direction = GetRandomDirection();
    }

    public void StopMoving()
    {
        isMoving = false;
    }

    private void MovePlayer()
    {
        transform.Translate(direction * (playerSpeed * Time.deltaTime));
    }

    private Vector2 GetRandomDirection()
    {
        Vector2[] directions = { Vector2.left, Vector2.right, Vector2.up, Vector2.down };
        return directions[UnityEngine.Random.Range(0, directions.Length)];
    }
    
    private void CheckScreenBounds()
    {
        Vector2 playerPosition = transform.position;

        if (playerPosition.x - playerHalfWidth < -screenHalfWidth || 
            playerPosition.x + playerHalfWidth > screenHalfWidth ||
            playerPosition.y - playerHalfHeight < -screenHalfHeight || 
            playerPosition.y + playerHalfHeight > screenHalfHeight)
        {
            StopMoving();
            transform.Translate(direction * offsetFromWall);
            StartMoving();
        }
    }
}
