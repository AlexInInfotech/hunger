using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    private Vector2 PointToGo = new Vector2();
    public static float OffsetX = 2f;
    public static float OffsetY = 1f;
    public float AttitudeToGo = 20f;
    public float MaxWaitTime = 5f;
    public float speed = 10f;
    public float health = 10;
    private Vector3 direction;
    private float WaitTime = 0f;
    public void Damage(float dammage)
    {
        health -= dammage;
        if (health <= 0)
            Debug.Log("Died");
    }
    private void GoRandom()
    {
        PointToGo.x = transform.position.x + Random.Range(-AttitudeToGo, AttitudeToGo);
        PointToGo.y = transform.position.y + Random.Range(-AttitudeToGo, AttitudeToGo);
    }
    private void FixedUpdate()
    {
        if (WaitTime > 0)
        {
            Debug.Log("Wait " + WaitTime);
            WaitTime -= Time.deltaTime;
            return;
        }
        if (PointToGo == new Vector2())
            GoRandom();
        direction = Movement.DirectToPoint(PointToGo, transform.position, OffsetX, OffsetY);
        Debug.Log("Direction " + direction);
        if (direction == new Vector3())
            WaitTime = Random.Range(0f, MaxWaitTime) / MaxWaitTime;
        transform.position += direction * speed * Time.fixedDeltaTime;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Enter");
        if(collision.gameObject.tag == "Player")
            PointToGo = collision.gameObject.transform.position;
    }
}
