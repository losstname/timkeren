using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerBase : MonoBehaviour
{
    private Text enemyLimitText;
    public int enemyLimit = 5;

    void Awake()
    {
        enemyLimitText = GameObject.Find("EnemyLimitText").GetComponent<Text>();
        enemyLimitText.text = enemyLimit.ToString();
    }

    public void AttackBase()
    {
        enemyLimit--;
        enemyLimitText.text = enemyLimit.ToString();
        if (enemyLimit <= 0)
        {
            enemyLimitText.text = "You Loseee";
            Time.timeScale = 0;
        }
    }

    public bool isAttackAble()
    {
        return enemyLimit > 0;
    }

    public void PlayerWin()
    {
        enemyLimitText = GameObject.Find("EnemyLimitText").GetComponent<Text>();
        enemyLimitText.text = "You Wiiiin";
        Time.timeScale = 0;
    }
}