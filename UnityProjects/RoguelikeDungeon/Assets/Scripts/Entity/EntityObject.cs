using UnityEngine;

namespace Entity
{
    [System.Serializable]
    public class EntityObject : ScriptableObject
    {
        public float movespeed = 5;
        public int health = 100;
    
        public int attackDamage;
        public float attackSpeed;
        
    }
}