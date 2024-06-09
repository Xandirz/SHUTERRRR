using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EntityView : MonoBehaviour
{
    public TextMeshPro hpText;

    public void ChangeHpText(int hp, int maxHp)
    {
        hpText.text = hp + "/" + maxHp;
    }
}
