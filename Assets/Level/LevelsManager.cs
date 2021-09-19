using UnityEngine;
using UnityEngine.SceneManagement;

namespace NowakArtur97.IntergalacticRacing.Core
{
    public class LevelsManager : MonoBehaviour
    {
        public void ReplayLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
