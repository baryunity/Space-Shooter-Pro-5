﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8f;
    private bool _isEnemyLaser = false;

    void Update()
    {
        if (!_isEnemyLaser || true)    //FOO Disable Enemy lasers
            MoveUp();
        else
            MoveDown();
    }

    void MoveUp()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.up);
        if (transform.position.y > 8f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }
    void MoveDown()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.down);
        if (transform.position.y < -8f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }

    public void AssignEnemyLaser()
    {
        _isEnemyLaser = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && _isEnemyLaser)
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
                player.Damage();
        }
    }
}
