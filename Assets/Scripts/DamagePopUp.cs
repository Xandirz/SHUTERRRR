using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class DamagePopUp : MonoBehaviour
{
    private TextMeshPro textMesh;
    private Color textColor;
    private float dissapearTimer = 1f;

    public Color fireDamageColor;
    public Color acidDamageColor;
    public Color impulseDamageColor;
    public Color iceDamageColor;
    public Color electricDamageColor;
    public Color missDamageColor;
    public Color demonicDamageColor;
    public Color poisonDamageColor;
    // Start is called before the first frame update

    public static DamagePopUp Create(Vector3 position, int DamageAmount, bool isCriticalHit, bool isHeal, string damageType)
    {
        Vector3 offset = new Vector2(Random.Range(-0.2F,0.2f), Random.Range(-0.2F,0.2f));
        return GameAssets.Instance.DamageBox(position + offset, DamageAmount, isCriticalHit, isHeal, damageType);
    }

    void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    public void SetUp(int damageAmount, bool isCriticalHit, bool isHeal, string damageType)
    {
        if (damageType == "miss")
        {
            textMesh.SetText("miss");

        }
        else
        {
            textMesh.SetText(damageAmount.ToString());

        }
        if (isCriticalHit)
        {
            textMesh.fontSize += 2;
            textColor = Color.red;

        } 
        else if (isHeal)
        {
            textColor = Color.green;
        }
        else
        {
            textColor = textMesh.color;
        }

        textColor = damageType switch
        {
            "fire" => fireDamageColor,
            "acid" => acidDamageColor,
            "impulse" => impulseDamageColor,
            "ice" => iceDamageColor,
            "electric" => electricDamageColor,
            "miss" => missDamageColor,
            "demonic" => demonicDamageColor,
            "poison" => poisonDamageColor,

            _ => textColor
        };

        textMesh.color = textColor;
    }

    private void Update()
    {
        float moveYspeed = 1f;
        transform.position += new Vector3(0, moveYspeed) * Time.deltaTime;
        dissapearTimer -= Time.deltaTime;
        if (dissapearTimer < 0)
        {
            float dissapearSpeed = 3f;
            textColor.a -= dissapearSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
    
    public static DamagePopUp CreateMessage(Vector3 position, string text)
    {
        Vector3 offset = new Vector2(Random.Range(-0.2F,0.2f), Random.Range(-0.2F,0.2f));
        return GameAssets.Instance.Message(position + offset, text);
    }
    
    public void SetUpMessage(string text)
    {
      
            textMesh.SetText(text);
            textColor = textMesh.color;
            textMesh.color = textColor;
    }
    
    
}
