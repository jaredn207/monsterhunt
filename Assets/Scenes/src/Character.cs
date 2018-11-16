﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public int currentX { set; get; }
    public int currentY { set; get; }
    public bool isAlly;

    //used to depricate the health bar
    public GameObject health_bar;

    public float max_health = 10;
    public float hp = 10;

    public int moveDistance;

    public void Start()
    {
        hp = max_health;
    }

    public void setPosition(int x, int y)
    {
        currentX = x;
        currentY = y;
    }

    public virtual bool[,] possibleMove()
    {
        return new bool[BoardManager.boardSize, BoardManager.boardSize];
    }

    //attaches health bar to unit
    public void attachHealthBar(GameObject newHealthBar)
    {
        health_bar = newHealthBar;
    }

    public void takeDamage(float damage)
    {

        hp -= damage;
        if(hp <= 0)
            {
                hp = 0;
                die();
            }

        //sends hp/max_health to setHealth function, as long as health bar exists
        if(health_bar != null)
        {
            health_bar.SendMessage("setHealth", hp / max_health);
        }
    }

    //removes unit from the board when hp reaches 0
    public void die()
    {
        Destroy(gameObject);
    }
}
