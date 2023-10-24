using UnityEngine;
using UnityEngine.AI;

namespace CIC_Project_Object
{
    public class Monster : MonoBehaviour
    {
        private Character character;
        private NavMeshAgent agent;

        void Start()
        {
            character = GameObject.Find("Player").GetComponent<Character>();
            agent = GetComponent<NavMeshAgent>();

        }

        void Update()
        {
            ChasePlayer();
        }

        private void ChasePlayer()
        {
            if (character != null)
            {
                agent.SetDestination(character.transform.position);
            }
        }
    }
}