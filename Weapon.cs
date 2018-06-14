using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Weapons
{

    [CreateAssetMenu(menuName = ("RPG/Weapon"))]
    public class Weapon : ScriptableObject
    {
        public Transform GripTransform;

        [SerializeField] GameObject weaponPrefab;
        [SerializeField] AnimationClip atackAnimation;

        public GameObject GetWeaponPrefab()
        {
            return weaponPrefab;
        }

        public AnimationClip GetAtackAnimClip()
        {
            RemoveAnimationEvents();
            return atackAnimation;
        }

        private void RemoveAnimationEvents()
        {
            atackAnimation.events = new AnimationEvent[0];
        }
    }
}