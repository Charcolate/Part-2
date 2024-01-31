using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    public float newpoinyThreshold = 0.2f;
    Vector2 lastPosition;
    LineRenderer lineRenderer;
    Vector2 currentPosition;
    Rigidbody2D rb;
    public float speed = 1;
    public AnimationCurve landing;
    float landingTimer;

    Vector3 randomPosition;
    float randomRoation;
    public List<Sprite> sprite;
    SpriteRenderer spriteRenderer;


    void Start()
    {
        randomPosition.x = Random.Range(-5, 5);
        randomPosition.y = Random.Range(-5, 5);
        randomPosition.z = 0;
        randomRoation = Random.Range(0, 360);
        speed = Random.Range(1f, 3f);


        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);

        rb = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite[Random.Range(0, sprite.Count)];
        transform.position = randomPosition;
        transform.rotation = Quaternion.Euler(0, 0, randomRoation);
    }

    void FixedUpdate()
    {
        currentPosition = transform.position;
        if (points.Count > 0 )
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rb.rotation = -angle;
        }
        rb.MovePosition(rb.position + (Vector2)transform.up * speed * Time.deltaTime);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            landingTimer += 0.1f * Time.deltaTime;
            float interpolation = landing.Evaluate(landingTimer);
            if (transform.localScale.z < 0.1f)
            {
                Destroy(gameObject);
            }
            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, interpolation);
        }

        lineRenderer.SetPosition(0, transform.position);
        if (points.Count > 0 )
        {
            if (Vector2.Distance(currentPosition, points[0]) < newpoinyThreshold)
            {
                points.RemoveAt(0);

                for(int i = 0; i < lineRenderer.positionCount - 2; i++)
                {
                    lineRenderer.SetPosition (i, lineRenderer.GetPosition(i + 1));
                }
                lineRenderer.positionCount--;
            }
        }

        Vector2 screenPosition = Camera.main.WorldToScreenPoint (transform.position);
        if(screenPosition.y>Screen.height || screenPosition.y < 0)
        {
            Destroy (gameObject);
        }
    }

    void OnMouseDown()
    {
        points = new List<Vector2>();
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Add(newPosition);
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);
    }

    void OnMouseDrag()
    {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(lastPosition, newPosition) > newpoinyThreshold)
        {
            points.Add(newPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPosition);
            lastPosition = newPosition;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.red;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        float dist = Vector3.Distance(currentPosition, collision.transform.position);
        if (dist <= 5)
        {
            Destroy(gameObject);
            Debug.Log("Bam!");
        }
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.white;
        }
    }
}
