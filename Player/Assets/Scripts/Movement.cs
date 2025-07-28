using UnityEngine;
public class Movement : MonoBehaviour
{
    public float speed;
    public static float Dammage = 1f;
    public Animator animator;
    public GameObject RotatePlayer;
    public GameObject FrontPlayer;
    public GameObject BackPlayer;

    private Vector3 DirectionVelocity;
    public static Vector3 DirectionStatic = new Vector3();
    public static Vector2 Point = new Vector2();
    public static float offsetX = 2f;
    public static float offsetY = 1f;
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        RotatePlayer.SetActive(false);

        BackPlayer.SetActive(false);
    }
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
            animator.SetTrigger("Attack");
        if (Input.GetKey(KeyCode.E))
            animator.SetTrigger("Collect");

        DirectionVelocity = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (DirectionVelocity == new Vector3() && Point != new Vector2())
            GoToPoint(ref DirectionVelocity);
        if (DirectionVelocity != new Vector3())
            DirectionStatic = DirectionVelocity;

        transform.position += DirectionVelocity * speed * Time.fixedDeltaTime;
        transform.rotation = (DirectionStatic.x < 0) ? new Quaternion(0, 180, 0, 0) : new Quaternion(0, 0, 0, 0);

        animator.SetBool("Run", DirectionVelocity != new Vector3());
        BackPlayer.SetActive(DirectionStatic.y > 0);
        FrontPlayer.SetActive(DirectionStatic.y < 0);
        RotatePlayer.SetActive(DirectionStatic.y == 0);
        animator.SetFloat("Vertical", DirectionStatic.y);
    }

    void GoToPoint(ref Vector3 direction)
    {
        direction = DirectToPoint(Point, transform.position, offsetX, offsetY);
        if (direction == new Vector3())
        {
            Point = new Vector2();
            animator.SetTrigger("Collect");
        }
    }
    public static Vector3 DirectToPoint(Vector2 Point, Vector3 Position, float offsetX, float offsetY)
    {
        Vector3 direction = new Vector3();
        if (Position.x < Point.x - offsetX)
            direction.x = 1;
        else if (Position.x > Point.x + offsetX)
            direction.x = -1;
        else
            Point.x = Position.x;
        if (Position.y < Point.y - offsetY)
            direction.y = 1;
        else if (Position.y > Point.y + offsetY)
            direction.y = -1;
        else if (Point.x - offsetX <= Position.x && Position.x <= Point.x + offsetX)
            return new Vector3();
        return direction;
    }
}

        // FrontPlayer.SetActive(direction == new Vector3() || direction.y < 0);
        //RotatePlayer.SetActive(direction.y == 0 && direction.x != 0);