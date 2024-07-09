using UnityEngine;

public class Player : Entity
{
    public PlayerConfig playerConfig;
    
    //здоровье
    public EntityView view;
    public int maxHp = 5;
    public int hp = 5;
    [Space] //передвижение
    public float moveSpeed = 1;
    private int moveSpeedMod = 1;
    [Space] //пауза
    public bool isPaused = false;

    [Space]
    public bool isMoving = false;
    public Vector3 faceDirection;
    
    private void Start()
    {
        hp = maxHp;
        view.ChangeHpText(hp,maxHp);
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, vertical, 0);
        Vector3 movement = direction * (moveSpeed * moveSpeedMod * Time.deltaTime);
        
        Move(movement);
        
        isMoving = direction.magnitude > 0.1;
        faceDirection = direction;

        
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
