using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public InventoryManager Inventory; //=> Inventory.GameObject().GetComponent<InventoryManager>();
    public Transform RotatePoint;
    public Transform FrontPoint;
    public Transform BackPoint;
    public float RadiusAttack = 0.5f;
    public LayerMask EnemyesLayer;
    public LayerMask ResourseLayer;
    public void Attack()
    {
        Transform TransformPoint = CurrentPointTransform();
        Collider2D[] hitedEnemyes = Physics2D.OverlapCircleAll(TransformPoint.position, RadiusAttack, EnemyesLayer);
        foreach (Collider2D enemy in hitedEnemyes)
            enemy.GetComponent<Enemy>().Damage(Movement.Dammage);
    }

    public void Take()
    {
        Transform TransformPoint = CurrentPointTransform();
        Collider2D[] TakenItems = Physics2D.OverlapCircleAll(TransformPoint.position, RadiusAttack, ResourseLayer);
        foreach (Collider2D item in TakenItems)
            if (Inventory.TryAddItem(item.GetComponent<Item>().ItemData))
                item.gameObject.SetActive(false);
    }

    private Transform CurrentPointTransform()
    {
        if (Movement.DirectionStatic.y > 0)
            return BackPoint;
        if (Movement.DirectionStatic.x == 0)
            return FrontPoint;
        return RotatePoint;
    }
    //private void OnDrawGizmosSelected()
    //{
    //    if (TransformPoint == null)
    //        return;
    //    Gizmos.DrawSphere(TransformPoint.position, RadiusAttack);
    //}
}
