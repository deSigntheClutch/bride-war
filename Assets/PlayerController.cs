using UnityEngine;
using PRINCESS.Movement;
using PRINCESS.Fight;
using PRINCESS.Core;

namespace PRINCESS.Controller
{
    public class PlayerController : MonoBehaviour
    {
        Health health;
        private void Start()
        {
            health = GetComponent<Health>();
        }
        private void Update()
        {
            if (health.IsDead()) return;
            if (Fight()) return;
            if(Movement()) return;
        }

        private bool Fight()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetRay());
            foreach (RaycastHit hit in hits)
            {
                FightTarget target = hit.transform.GetComponent<FightTarget>();
                if (target == null) continue;
                if (!GetComponent<Fighter>().ShouldAttack(target.gameObject)) continue;
                if (Input.GetMouseButton(0)) { 
                   GetComponent<Fighter>().Attack(target.gameObject);
            }
                return true;
            }
            return false;
        }

        private bool Movement()
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetRay(), out hit);
            if (hasHit)
            {
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Move>().StartMove(hit.point);
                }
                return true;
            }
            return false;
        }

        private static Ray GetRay() {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}    

