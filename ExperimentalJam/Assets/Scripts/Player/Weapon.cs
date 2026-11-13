using System;
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private Stats _stats;

    public void Attack(Transform playerTransform, Vector2 direction)
    {
        float angle = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);


        for(int i = 1; i <= _stats.GetStat(StatModifier.COUNT); i++)
        {
            Projectile projectile = Instantiate(_projectilePrefab, playerTransform.position, rotation);
            projectile.SetupProjectile(Mathf.RoundToInt(_stats.GetStat(StatModifier.DAMAGE)),
                                        _stats.GetStat(StatModifier.SPEED),
                                        _stats.GetStat(StatModifier.SIZE),
                                        _stats.GetStat(StatModifier.DURATION));

            switch(i)
            {
                case 1:
                projectile.SetDirection(direction);
                    break;
                case 2:
                projectile.SetDirection(direction * -1);
                    break;
                case 3:
                projectile.SetDirection(new Vector2(-direction.y, direction.x));
                    break;
                case 4:
                projectile.SetDirection(new Vector2(direction.y, -direction.x));
                    break;
            }    

            // {1,0}; Right
            // {0,1}; Up
            // {-1,0}; Left
            // {0,-1}; Down   

            // Player's direction
            // {1,0}; Right
            // Opposite = *-1
            // {-1,0}; Left           
        }
    }





}
