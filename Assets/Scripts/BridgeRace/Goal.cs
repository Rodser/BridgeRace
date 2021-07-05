using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace BridgeRace
{
    public class Goal : MonoBehaviour
    {
        public UnityEvent GoalEvent;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Spawn"))
            {
                GoalEvent.Invoke();

                StartCoroutine(ReloadScene());
                Destroy(other.gameObject);
            }
        }

        private IEnumerator ReloadScene()
        {
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}