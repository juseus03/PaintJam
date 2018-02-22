using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeCtrl : MonoBehaviour {

    public float spawnTime = 1f;
    public GameObject tail;
    public List<GameObject> parts;


    Vector3 direction;
    Vector3 oldDirection;

	// Use this for initialization
	void Start ()
    {
        direction = Vector2.right;
        oldDirection = direction;
        Invoke("Move",spawnTime);
	}
	
	// Update is called once per frame
	void Update ()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if(horizontal != vertical)
        {
            Vector3 newDirection = Vector3.right * horizontal + Vector3.up * vertical;
            if (newDirection != Vector3.zero && newDirection != direction * -1f && direction != newDirection)
            {
                oldDirection = direction;
                direction = newDirection;
            }
                
        }
        
	}

    void Move()
    {
        for(int i = parts.Count-1; i>0;i--)
        {
            parts[i].transform.position = parts[i - 1].transform.position;
            parts[i].transform.right = parts[i - 1].transform.right;
        }

        parts[0].transform.position += direction;
        if (oldDirection != direction)
            parts[0].transform.right = direction;

        Invoke("Move", spawnTime);
    }

    public void RemoveTail()
    {
        if(parts.Count >0)
        {
            Destroy(parts[parts.Count - 1]);
            parts.RemoveAt(parts.Count - 1);
        }
        else
        {
            Destroy(parts[0]);
            parts.RemoveAt(0);
        }
    }

    public void AddTail()
    {
        var position = parts[parts.Count - 1].transform.position;
        var rotation = parts[parts.Count - 1].transform.rotation;

        GameObject newTail = Instantiate(tail,position,rotation) as GameObject;
        newTail.transform.parent = transform;
        parts.Add(newTail);
    }

    
}
