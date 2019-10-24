using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovableBall : MonoBehaviour {

    private Vector3 moveFrom;
    private Vector3 moveTo;

    float speed = 3.5f;

    Rigidbody2D rigidBodyCache;

    void Start ()
    {
        rigidBodyCache = GetComponent<Rigidbody2D>();
        rigidBodyCache.constraints = true ? RigidbodyConstraints2D.FreezeRotation : RigidbodyConstraints2D.FreezeAll;
    }

    void FixedUpdate ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // if(gameObject.GetComponent<Rigidbody2D>() == null) 
            //     if(RayCheck(ray))
            //     {
            //         Debug.Log("RayCheck(" + ray + ")");
            //         MouseFrom();
            //     }
            // else
                if(RayCheck2D(ray))
                {
                    Debug.Log("RayCheck2D(" + ray + ")");
                    MouseFrom();
                }
        }

        if (Input.GetMouseButtonUp(0))
        {
            MouseTo();
            Move();
        }
    }

    /// <summary>
    /// Check Raycast for 3D GameObject
    /// </summary>
    private bool RayCheck(Ray ray)
    {
        RaycastHit hit = new RaycastHit();
        var raycast = Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity);
        if (raycast && hit.collider == gameObject.GetComponent<Collider>())
            return true;

        return false;
    }

    /// <summary>
    /// Check Raycast for 2D GameObject
    /// </summary>
    private bool RayCheck2D(Ray ray)
    {
        var raycast = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
        Debug.Log("raycast: " + raycast);
        Debug.Log("raycast.collider: " + raycast.collider);
        if (raycast && raycast.collider == gameObject.GetComponent<CircleCollider2D>())
            return true;

        return false;
    }

    /// <summary>
    /// Start Mouse Position
    /// </summary>
    void MouseFrom()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = - Camera.main.transform.position.z;
        moveFrom = Camera.main.ScreenToWorldPoint(mousePos);
    }

    /// <summary>
    /// Moving Mouse Position
    /// </summary>
    void MouseTo()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = - Camera.main.transform.position.z;
        moveTo = Camera.main.ScreenToWorldPoint(mousePos);
    }

    /// <summary>
    /// Update GameObject Position
    /// </summary>
    void Move()
    {
        var diff = moveTo - moveFrom;
        var magnitudeLimit = 50f;
        var magnitudeLimitRatio = magnitudeLimit / Mathf.Max(diff.magnitude, magnitudeLimit);

        Debug.Log("rigidBodyCache.velocity: " + rigidBodyCache.velocity);
        rigidBodyCache.velocity = (-diff * magnitudeLimitRatio * speed);
        Debug.Log("rigidBodyCache.velocity: " + rigidBodyCache.velocity);
        // transform.position = moveTo;
    }
    void Update()
    {
        if(transform.position.y < -20)
        {
            SceneManager.LoadScene("GameScene");
        }
        if(transform.position.y > 350)
        {
            SceneManager.LoadScene("GameScene");
        }
        if(transform.position.x < -170)
        {
            SceneManager.LoadScene("GameScene");
        }
         if(transform.position.x > 180)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

}