using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class โปรเจ็กทายT2 : MonoBehaviour
{
    [SerializeField] Transform shootpoint;
    [SerializeField] GameObject target;
    [SerializeField] Rigidbody2D bulletprefab;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(Ray . origin, Ray.direction * 5f, Color.yellow , 5f);
            RaycastHit2D hit = Physics2D.GetRayIntersection(Ray,Mathf.Infinity);

            if (hit.collider != null)
            {
                target . transform.position = new Vector2(hit.point.x , hit.point.y);
                Debug.Log("hit" + hit.collider.name);
                Vector2 ProjectileVelocity = CalculateProjectileVelocity(shootpoint.position, hit.point,1f);
                Rigidbody2D shootBullrt = Instantiate(bulletprefab,shootpoint.position,Quaternion.identity,shootpoint);
                shootBullrt.linearVelocity = ProjectileVelocity;
                
            }
        }
    }

    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float time)
    {
        Vector2 distance = target - origin;
        float velocitX = distance.x / time;
        float velocityY = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y);
        
        Vector2 projectileVelocity = new Vector2(velocitX , velocityY);
        return projectileVelocity;
    }
}
