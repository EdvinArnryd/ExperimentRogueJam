using UnityEngine;

public class GameResultsManager : MonoBehaviour
{
    private float _xpGained = 0;
    private int _goldGained = 0;
    private int _monstersKilled = 0;
    
    public void GainXP(float xp)
    {
        _xpGained += xp;
    }
    
    public void GainGold(int gold)
    {
        _goldGained += gold;
    }
    
    public void MonsterKilled()
    {
        _monstersKilled++;
    }

    public float GetXPGained()
    {
        return _xpGained;
    }

    public int GetGoldGained()
    {
        return _goldGained;
    }
    
    public int GetMonsterKilled()
    {
        return _monstersKilled;
    }
}
