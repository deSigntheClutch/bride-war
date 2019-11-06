using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessHealth : MonoBehaviour
{
    [SerializeField]float health = 100f;
        bool isDead = false;

        public void CauseDamage (float damage) {
            health = Mathf.Max(health - damage, 0);
           if (health == 0) {
                Die();
           }
        }
        private void Die() {
            if (isDead) return;
            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
            // GetComponent<ActionScheduler>().CancelCurrentAction();
        }
        public bool IsDead() {
            return isDead;
        }
        public float getHealth() {
            return health;
        }
}
