using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    
    public void setTowerDamage(float value) {
        PlayerPrefs.SetFloat("tower_damage", value);
    }
    public void setBaseHp(float value)
    {
        PlayerPrefs.SetFloat("base_hp", value);
    }
    public void setShootingSpeed(float value)
    { 
        PlayerPrefs.SetFloat("reload", 10/value);
    }
    public void setEnemyHp(float value)
    {
        PlayerPrefs.SetFloat("enemy_hp", value);
    }

}
