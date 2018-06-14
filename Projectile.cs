using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Core;

namespace RPG.Weapons
{

    public class Projectile : MonoBehaviour
    {

        [SerializeField] float projectileSpeed; // Note other classes can set
        [SerializeField] GameObject shooter;
        float damageCaused;
        const float DESTROY_DELAY = 0.01f;
        public void SetShooter(GameObject shooter)
        {
            this.shooter = shooter;
        }
        public float GetDefaultLaunchSpeed()
        {
            return projectileSpeed;
        }
        public void SetDamage(float damage)
        {
            damageCaused = damage;
        }

        void OnCollisionEnter(Collision collision)
        {
            var LayerCollidedWith = collision.gameObject.layer;

            if (shooter && LayerCollidedWith != shooter.layer)
            {
                DamageIfDamagable(collision);
            }
        }

        private void DamageIfDamagable(Collision collision)
        {
            Component damagableComponent = collision.gameObject.GetComponent(typeof(IDamageable));
            if (damagableComponent)
            {
                (damagableComponent as IDamageable).TakeDamage(damageCaused);
            }
            Destroy(gameObject, DESTROY_DELAY);
        }
    }
}
