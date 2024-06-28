using UnityEngine;

public class Player : Entity
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
    
    private void Start()
    {
        hp = maxHp;
        view.ChangeHpText(hp,maxHp);
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical"); //todo давай сделаем анимацию - спрайты есть в проекте

        Vector3 movement = new Vector3(horizontal, vertical, 0) * (moveSpeed * moveSpeedMod * Time.deltaTime);
        Move(movement);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TogglePause();
        }
    }
    
    public void TogglePause()
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
            Destroy(gameObject);
    }
}
