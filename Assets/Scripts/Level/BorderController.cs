using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderController : MonoBehaviour
{
    void Awake()
    {
        // Get or add a BoxCollider2D component to the GameObject
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        if (box == null)
        {
            box = gameObject.AddComponent<BoxCollider2D>();
        }

        // Calculate the corner points of the box collider
        Vector2 min = box.bounds.min;
        Vector2 max = box.bounds.max;
        Vector2 bottomLeft = new Vector2(min.x, min.y);
        Vector2 topLeft = new Vector2(min.x, max.y);
        Vector2 topRight = new Vector2(max.x, max.y);
        Vector2 bottomRight = new Vector2(max.x, min.y);

        // Create an array of points for the edge collider
        Vector2[] points = new Vector2[] { bottomLeft, topLeft, topRight, bottomRight, bottomLeft };

        // Add an EdgeCollider2D component to the GameObject
        EdgeCollider2D edge = gameObject.GetComponent<EdgeCollider2D>();
        if (edge != null)
            Destroy(edge);
        edge = gameObject.AddComponent<EdgeCollider2D>();

        // Assign the points to the EdgeCollider2D
        edge.points = points;

        // Destroy the original BoxCollider2D component
        Destroy(box);
    }
}

// Reference: https://www.youtube.com/watch?v=NbvcfMjAlQ4
