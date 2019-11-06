using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PRINCESS.Movement;
using PRINCESS.Core;
using System;
using Random = System.Random;

namespace PRINCESS.Fight
{
    public class BossFight : MonoBehaviour, CAction
    {
        [SerializeField] float fightRange = 2f;
        [SerializeField] float timeBetweenAttacks = 0.5f;
        [SerializeField] float weaponDamage = 5f;
        Health target;
        Random random = new Random();

        float timeFromLastAttack = Mathf.Infinity;

        public void Update()
        {
            timeFromLastAttack += Time.deltaTime;
            if (target == null) return;
            if (target.IsDead())
            {
                return;
            }
            bool isWithinRange = Vector3.Distance(transform.position, target.transform.position) < fightRange;
            if (target != null && !isWithinRange)
            {
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
            if (timeFromLastAttack > timeBetweenAttacks)
            {
                String[] arr = { "attack1", "attack2" };
                int index = random.Next(arr.Length);
                //Debug.Log(index);
                String newattack = arr[index];
                GetComponent<Animator>().ResetTrigger("stopAttack");
                GetComponent<Animator>().SetTrigger(newattack);
                Debug.Log(newattack);
                timeFromLastAttack = 0;
                Hit();
            }
        }
        public bool ShouldAttack(GameObject fightTarget)
        {
            if (fightTarget == null) return false;
            Health target = fightTarget.GetComponent<Health>();
            return target != null && !target.IsDead();
        }

        public void Attack(GameObject fightTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = fightTarget.GetComponent<Health>();
        }

        public void Cancel()
        {
            target = null;
            GetComponent<Animator>().SetTrigger("stopAttack");
            GetComponent<Animator>().ResetTrigger("attack1");
            GetComponent<Animator>().ResetTrigger("attack2");
            //GetComponent<Animator>().ResetTrigger("attack3");
        }

        // make damage to the enmey
        void Hit()
        {
            if (target == null) return;
            target.CauseDamage(weaponDamage);
            // print(target.getHealth());
        }
    }
}
