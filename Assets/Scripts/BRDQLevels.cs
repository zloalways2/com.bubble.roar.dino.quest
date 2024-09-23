using UnityEngine;
using UnityEngine.SceneManagement;

namespace BRDQ
{
    public class BRDQLevels : MonoBehaviour
    {
        [SerializeField] private BRDQLevelBtn[] _BRDQLevels;

        private void Start()
        {
            var brdqLevelPass = PlayerPrefs.GetInt("BRDQLevelPass", 1);
            
            for (var i = 0; i < _BRDQLevels.Length; i++)
            {
                var index = i;

                _BRDQLevels[index]._BRDQLevel.text = $"Level {index + 1}";
                _BRDQLevels[index].interactable = index < brdqLevelPass;
                
                _BRDQLevels[index].onClick.AddListener(() =>
                {
                    PlayerPrefs.SetInt("BRDQLevel", index + 1);
                    SceneManager.LoadScene("Game");
                });
            }
        }
    }
}