using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PRINCESS.Movement;
using PRINCESS.Core;

namespace PRINCESS.Fight
{
    public class Fighter : MonoBehaviour, CAction
    {
        [SerializeField] float fightRange = 2f;
        [SerializeField] float timeBetweenAttacks = 0.5f;
        [SerializeField] float weaponDamage = 5f;
        Health target;

        float timeFromLastAttack = Mathf.Infinity;

        public void Update() {
            timeFromLastAttack += Time.deltaTime;
            if (target == null) return;
            if (target.IsDead())
            {
                return;
            }
            bool isWithinRange = Vector3.Distance(transform.position, target.transform.position) < fightRange;
            if (target != null && !isWithinRange) {
                GetComponent<Move>().MoveTo(target.transform.position);
            }
            else
            {
                GetComponent<Move>().Cancel();
                AttackAnimation();
            }
        }

        // display attack animation 
        private void AttackAnimation()
        {
            transform.LookAt(target.transform);
            if (timeFromLastAttack > timeBetweenAttacks) {
                GetComponent<Animator>().ResetTrigger("stopAttack");
                GetComponent<Animator>().SetTrigger("attack");
                timeFromLastAttack = 0;
                Hit();
            }
        }
        public bool ShouldAttack(GameObject fightTarget) {
            if (fightTarget == null) return false;
            Health target = fightTarget.GetComponent<Health>();
            return target != null && !target.IsDead();
        }

        public void Attack(GameObject fightTarget) {
            GetComponent<ActionScheduler>().StartAction(this);
            target = fightTarget.GetComponent<Health>();
        }

        public void Cancel() {
            target = null;
            GetComponent<Animator>().SetTrigger("stopAttack");
            GetComponent<Animator>().ResetTrigger("attack");
        }

        // make damage to the enmey
        void Hit() {
            if (target == null) return;
            target.CauseDamage(weaponDamage);
            // print(target.getHealth());
        }
    }
}

