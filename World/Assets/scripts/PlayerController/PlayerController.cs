using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public Joystick joystick;
    private Vector2 Direction;

    void FixedUpdate()
    {
        Direction = joystick.Direction * speed * Time.fixedDeltaTime;
        transform.position += new Vector3(Direction.x , Direction.y);

        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += new Vector3(0, speed * Time.fixedDeltaTime);
            //body.AddForce(new Vector2(0, speed * Time.fixedDeltaTime));
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position += new Vector3(0, -speed * Time.fixedDeltaTime);

        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += new Vector3(-speed * Time.fixedDeltaTime, 0);

        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += new Vector3(speed * Time.fixedDeltaTime, 0);

        }
    }
}
