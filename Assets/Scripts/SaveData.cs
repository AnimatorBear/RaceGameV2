using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SaveData : MonoBehaviour
{
    string moneyKey = "Money";
    string upgradeKey = "Upgrade";
    string carSkinKey = "CarSkin";
    public bool[] hasUpgrade = {false , false , false , false , false , false , false};
    public bool[] hasAchievement = { false, false };
    public float money { get; set; }
    public string upgrade { get; set; }
    public string carSkin { get; set; }
    public bool bool1 = false;
    MoneyManager moneyManager;
    private void Awake()
    {
        money = PlayerPrefs.GetFloat(moneyKey);
        upgrade = PlayerPrefs.GetString(upgradeKey);
        carSkin = PlayerPrefs.GetString(carSkinKey);
        bool1 = PlayerPrefs.GetInt("1Up") == 0;
    }
    private void Start()
    {
        moneyManager = FindObjectOfType<MoneyManager>();
        //for (int i)
        if (PlayerPrefs.GetInt("1Up") == 1)
        {
            hasUpgrade[0] = true;
            Debug.Log("Has 1");
        }
        if (PlayerPrefs.GetInt("2Up") == 1)
        {
            hasUpgrade[1] = true;
            Debug.Log("Has 2");
        }
        if (PlayerPrefs.GetInt("3Up") == 1)
        {
            hasUpgrade[2] = true;
            Debug.Log("Has 3");
        }
        if (PlayerPrefs.GetInt("4Up") == 1)
        {
            hasUpgrade[3] = true;
            Debug.Log("Has 4");
        }
        if (PlayerPrefs.GetInt("5Up") == 1)
        {
            hasUpgrade[4] = true;
            Debug.Log("Has 5");
        }
        if (PlayerPrefs.GetInt("6Up") == 1)
        {
            hasUpgrade[5] = true;
            Debug.Log("Has 6");
        }
        if (PlayerPrefs.GetInt("7Up") == 1)
        {
            hasUpgrade[6] = true;
            Debug.Log("Has 7");
        }
        CheckUpgradeAchievement();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SetMoney(0);
            PlayerPrefs.SetString(upgradeKey, "");
            for (int i = 0; i < hasUpgrade.Length + 1; i++)
            {
                PlayerPrefs.SetInt(i + "Up", false ? 1 : 0);
            }
            for (int i = 0; i < hasAchievement.Length + 1; i++)
            {
                PlayerPrefs.SetInt(i + "Ach", false ? 1 : 0);
            }
            PlayerPrefs.SetInt("1Ach", false ? 1 : 0);
            PlayerPrefs.SetString(carSkinKey, "");
            for (int x = 0; x < hasUpgrade.Length; x++)
            {
                hasUpgrade[x] = false;
            }
                Debug.Log("Reset Shit");
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (PlayerPrefs.GetInt("1Up") == 0)
            {
                //false
                Debug.Log("is 0");
            } else if (PlayerPrefs.GetInt("1Up") == 1)
            {
                //true
                Debug.Log("is 1");
            }
            PlayerPrefs.SetInt("1Up" , true ? 1 : 0);
        }
    }
    public void SetMoney(float money)
    {
        moneyManager.money = money;
        PlayerPrefs.SetFloat(moneyKey, money);
    }
    public void SetUpgrade(string Upgrade)
    {
        upgrade = Upgrade;
        PlayerPrefs.SetString(upgradeKey, Upgrade);
        CheckUpgradeAchievement();
    }
    public bool CheckUpgrade(int upgrade)
    {
        bool hasUpgrade = false;
        if (PlayerPrefs.GetInt(upgrade + "Up") == 1)
        {
            hasUpgrade = true;
        }
        else if(PlayerPrefs.GetInt(upgrade + "Up") == 0)
        {
            hasUpgrade = false;
        }
        return hasUpgrade;
    }
    public void SetUpgrade(int upgrade)
    {
        if (upgrade != 0)
        {
            hasUpgrade[upgrade - 1] = true;
            PlayerPrefs.SetInt(upgrade + "Up", true ? 1 : 0);
        }
    }
    public void AchieveSomething(int achievement)
    {
        PlayerPrefs.SetInt(achievement + "Ach", true ? 1 : 0);
    }
    public bool CheckAchievement(int achievement)
    {
        bool hasAchievement = false;
        if (PlayerPrefs.GetInt(achievement + "Ach") == 1)
        {
            hasAchievement = true;
        }
        else if (PlayerPrefs.GetInt(achievement + "Ach") == 0)
        {
            hasAchievement = false;
        }
        return hasAchievement;
    }
    public void CheckUpgradeAchievement()
    {
        if (hasUpgrade[0] == true && hasUpgrade[1] == true && hasUpgrade[2] == true && hasUpgrade[3] == true && hasUpgrade[4] == true && hasUpgrade[5] == true && hasUpgrade[6] == true)
        {
            AchieveSomething(1);
        }
    }
    public void SetCarSkin(string skin)
    {
        PlayerPrefs.SetString(carSkinKey, skin);
    }
}
