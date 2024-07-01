using System;
using System.Collections.Generic;
using _Project.Scripts.Inventory.Item.CombineItem.Types;
using Inventory;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField] private Sprite[] headSprites;
    [SerializeField] private Sprite[] bodySprites;
    [SerializeField] private Sprite[] weaponSprites;
    [SerializeField] public Sprite[] upgradeSprites;
    [SerializeField] private Sprite[] scrollSprites;
 [SerializeField] private Sprite[] spellScrollSprites;
    [SerializeField] private Sprite[] spellBookSprites;

    private int GetChance()
    {
        return Random.Range(0, 101);
    }

    private ItemSlotType CreateRandomType()
    {
        ItemSlotType[] arrayOfTypes = (ItemSlotType[])Enum.GetValues(typeof(ItemSlotType));

       // return arrayOfTypes[2];
        return arrayOfTypes[Random.Range(0, arrayOfTypes.Length)];
    }

    private ItemRarity CreateRandomRarity()
    {
        ItemRarity[] arrayOfRarities = (ItemRarity[])Enum.GetValues(typeof(ItemRarity));
        
        int rarityChance = Random.Range(0, 100);
        int myRarity;

        if (rarityChance < 30) //todo можно ли тут сделать лучше логику?
            myRarity = 0;
        else if (rarityChance < 60)
            myRarity = 1;
        else if (rarityChance < 0) //невозможно сейчас
            myRarity = 2;
        else
            myRarity = 3;

        
        return arrayOfRarities[myRarity];
    }
    
    private ItemPerk CreateRandomPerk(ItemRarity rarity)
    {
        ItemPerk[] arrayOfPerks = (ItemPerk[])Enum.GetValues(typeof(ItemPerk));
        
        var perk = arrayOfPerks[0];

        if(rarity == ItemRarity.Legendary)
            perk = arrayOfPerks[Random.Range(1, arrayOfPerks.Length)]; //если легендарная рарити

        return perk;
    }

    private Item CreateAppleItem()
    {
        var rarity = CreateRandomRarity();
        var icon = upgradeSprites[Random.Range(0, upgradeSprites.Length)];
        
        return new UpgradeItem(icon, icon.name, rarity, ItemStats.CreatRandomStats(ItemSlotType.Upgrade, rarity));
    }
    

    private Item CreateHead(ItemRarity rarity)
    {
        var type = ItemSlotType.Head;
        

        var perk = CreateRandomPerk(rarity);
        var icon = headSprites[Random.Range(0, headSprites.Length)];
        
 
        
        return new Item(icon, icon.name, type, rarity, ItemStats.CreatRandomStats(type, rarity), perk);
    }

    private Item CreateBody(ItemRarity rarity)
    {
        var type = ItemSlotType.Body;
        var perk = CreateRandomPerk(rarity);
        var icon = bodySprites[Random.Range(0, bodySprites.Length)];
        
        if (rarity == ItemRarity.Rare || rarity==ItemRarity.Legendary)
        {
            
        }

        return new Item(icon, icon.name, type, rarity, ItemStats.CreatRandomStats(type, rarity), perk);
    }

    private Item CreateUpgrade(ItemRarity rarity)
    {
        var icon = scrollSprites[Random.Range(0, scrollSprites.Length)];
        
        if (GetChance() < 50)
        {
            var templateApple = CreateAppleItem();
            return new ScrollItem(templateApple, icon, icon.name, rarity);
        }
        
        return CreateAppleItem();
    }

    public Item GenerateItem()
    {
        
        Debug.Log("1");
        var type = CreateRandomType();
        var rarity = CreateRandomRarity();
        
        switch (type)
        {
            case ItemSlotType.Body:
                return CreateBody(rarity);
            case ItemSlotType.Head:
                return CreateHead(rarity);
        }
        
        return CreateUpgrade(rarity);
    }




}