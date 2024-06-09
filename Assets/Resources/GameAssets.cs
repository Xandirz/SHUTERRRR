using UnityEngine;

public class GameAssets : MonoBehaviour
{
    [SerializeField] private DamagePopUp _damagePopUp;
    
    private static GameAssets _instance;

    public static GameAssets Instance
    {
        get
        {
            if (_instance == null)
                _instance = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            
            return _instance;
        }
    }

    public DamagePopUp DamageBox(Vector3 position, int damageAmount, bool isCriticalHit, bool isHeal, string damageType)
    {
        var damagePopUp = Instantiate(_damagePopUp, position, Quaternion.identity);
        damagePopUp.SetUp(damageAmount, isCriticalHit, isHeal, damageType);

        return damagePopUp;
    }

    public DamagePopUp Message(Vector3 position, string message)
    {
        var damagePopUp = Instantiate(_damagePopUp, position, Quaternion.identity);
        damagePopUp.SetUpMessage(message);

        return damagePopUp;
    }
}