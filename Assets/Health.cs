using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PRINCESS.Core 
{
    public class Health : MonoBehaviour
    {
        [SerializeField]float health = 100f;
        bool isDead = false;
        [SerializeField]
        private UnityEvent onDied;

        public UnityEvent DiedEvent {
            get { return this.onDied; }
        }

        private void OnDiedEvent()
        {
            var handler = this.onDied;
            if (handler != null) {
                handler.Invoke();
            }
        }

        public void CauseDamage (float damage) {
            health = Mathf.Max(health - damage, 0);
            GetComponent<Animator>().SetTrigger("hurt");
           if (health == 0) {
                Die();
           }
        }
        private void Die() {
            if (isDead) return;
            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
            if (GetComponent<ActionScheduler>() != null) {
                GetComponent<ActionScheduler>().CancelCurrentAction();
            }

            // enemy died
            if (transform.GetComponent<PRINCESS.Fight.FightTarget>() != null) {
                Destroy(transform.GetComponent<PRINCESS.Fight.FightTarget>().gameObject);
                this.OnDiedEvent();
                GameController.numEnemies -= 1;
            }
        }
        public bool IsDead() {
            return isDead;
        }
        public float getHealth() {
            return health;
        }
    }
}

