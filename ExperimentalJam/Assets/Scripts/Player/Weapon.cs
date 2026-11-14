using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private Stats _stats;

    public void Attack(Transform playerTransform, Vector2 direction)
    {
        for(int i = 1; i <= _stats.GetStat(StatModifier.COUNT); i++)
        {
            switch(i)
            {
                case 1:
                InitializeProjectile(playerTransform, direction);
                    break;
                case 2:
                InitializeProjectile(playerTransform, direction * -1);
                    break;
                case 3:
                InitializeProjectile(playerTransform, new Vector2(-direction.y, direction.x));
                    break;
                case 4:
                InitializeProjectile(playerTransform, new Vector2(direction.y, -direction.x));
                    break;
            }            
        }        
        
    }

    private void InitializeProjectile(Transform playerTransform, Vector2 direction)
    {
        float angle = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        Projectile projectile = Instantiate(_projectilePrefab, playerTransform.position, rotation);
            projectile.SetupProjectile(Mathf.RoundToInt(_stats.GetStat(StatModifier.DAMAGE)),
                                        _stats.GetStat(StatModifier.SPEED),
                                        _stats.GetStat(StatModifier.SIZE),
                                        _stats.GetStat(StatModifier.DURATION));

        projectile.SetDirection(direction);
    }





}
