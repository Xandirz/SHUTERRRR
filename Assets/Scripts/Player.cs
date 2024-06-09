using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    //здоровье
    public EntityView view;
    public int maxHp = 5;
    public int hp = 5;
    [Space] //передвижение
    public float moveSpeed = 1;
    private int moveSpeedMod = 1;
    [Space] //пауза
    public bool isPaused = false;


    void Start()
    {
        hp = maxHp;
        view.ChangeHpText(hp,maxHp);
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, vertical, 0) * moveSpeed * moveSpeedMod *Time.deltaTime;
        transform.Translate(movement, Space.World);


        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TogglePause();
        }
    }
    
    private void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0; // Pause the game
        }
        else
        {
            Time.timeScale = 1; // Unpause the game
        }
    }
    
    public void TakeDamage(int damage)
    {
        hp -= damage;
        view.ChangeHpText(hp,maxHp);
        if (hp < 0)
        {
            Destroy(gameObject);
        }
    }
}
