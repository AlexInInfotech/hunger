using UnityEngine;

public class Item : MonoBehaviour
{
    public BaseItem ItemData;

    private void OnMouseEnter()
    {
        Debug.Log("Enterer");
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Movement.Point = transform.position;
            Debug.Log("Go to " + transform.position);
        }
    }
}
