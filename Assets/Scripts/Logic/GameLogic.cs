using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{    
    public GameObject SpawnFunction(GameObject PrefabWhatToSpawn, Vector3 spawnPosition)
    {
        Vector3 position;
        position = spawnPosition;
        GameObject newObject = Instantiate(PrefabWhatToSpawn, new Vector3(spawnPosition.x, spawnPosition.y, 0f), Quaternion.identity);
        return newObject;
    }
    
    public EnemyUnit_Reaper Seed_fieldsForEnemy( GameObject enemyGameObject, GameObject copiedPlayerObject ,PlayerUnit copiedUnit)
    {
        EnemyUnit_Reaper createdUnit = enemyGameObject.GetComponent<EnemyUnit_Reaper>();
        createdUnit._playerUnit = copiedUnit;
        createdUnit._playerObject = copiedPlayerObject;
        return createdUnit;
    }

    public UIHealthBarPlayer Seed_fieldsForUIEnemy(GameObject enemyUIObject, EnemyUnit_Reaper enemyUnit)
    {
        UIHealthBarPlayer createdUI = enemyUIObject.GetComponentInChildren<UIHealthBarPlayer>();
        enemyUnit._enemyUI = enemyUIObject;
        createdUI._unit = enemyUnit;
        return createdUI;
    }

    public Vector2 GetEndPosition(GameObject playerObject, GameObject enemyObject, float distanceBetweenPlayerAndEnemy)
    {
        Vector2 endPosition;
        if (playerObject.transform.position.x > enemyObject.transform.position.x)
        {
             endPosition = new Vector2(playerObject.transform.position.x - distanceBetweenPlayerAndEnemy, playerObject.transform.position.y);
        }
        else
        {
            endPosition = new Vector2(playerObject.transform.position.x + distanceBetweenPlayerAndEnemy, playerObject.transform.position.y);
        }
        return endPosition;
    }

    public void TakeDamage(Unit victim, int damage, GameObject popUpDamagePrefab)
    {
        TextMesh _damageLabel;
        GameObject popupDamage;
        victim.CurrentHealth -= damage;
        popupDamage = SpawnFunction(popUpDamagePrefab, new Vector3(victim.transform.position.x, victim.transform.position.y, 0f));
        _damageLabel = popupDamage.GetComponent<TextMesh>();
        _damageLabel.text = $"{damage}";        
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
