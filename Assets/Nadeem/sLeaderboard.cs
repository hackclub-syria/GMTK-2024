using UnityEngine;
using TMPro;

// NOTE: Make sure to include the following namespace wherever you want to access Leaderboard Creator methods
using Dan.Main;

namespace LeaderboardCreator
{
    public class sLeaderboard : MonoBehaviour
    {
        [SerializeField] private TMP_Text[] _entryTextObjects;
        [SerializeField] private TMP_Text[] _entryRankObjects;
        [SerializeField] private TMP_Text[] _entryScoreObjects;
        [SerializeField] private TMP_InputField _usernameInputField;
        public GameObject MainMenu;
        public GameObject LeaderboardMenu;

        public void Back()
        {
            LeaderboardMenu.SetActive(false);
            MainMenu.SetActive(true);
        }

// Make changes to this section according to how you're storing the player's score:
// ------------------------------------------------------------
//        [SerializeField] private ExampleGame _exampleGame;
        
        private int Score => 69;
// ------------------------------------------------------------

        private void Start()
        {
            LoadEntries();
        }

        private void LoadEntries()
        {
        
            Leaderboards.Leaderboard.GetEntries(entries =>
            {
                foreach (var t in _entryRankObjects)
                    t.text = "";

                foreach (var t in _entryTextObjects)
                    t.text = "";

                foreach (var t in _entryScoreObjects)
                    t.text = "";

                var length = Mathf.Min(_entryTextObjects.Length, entries.Length);
                for (int i = 0; i < length; i++)
                    _entryRankObjects[i].text = $"{entries[i].Rank}.";

                for (int i = 0; i < length; i++)
                    _entryTextObjects[i].text = $" {entries[i].Username}";

                for (int i = 0; i < length; i++)
                    _entryScoreObjects[i].text = $"{entries[i].Score}";
            });
        }
        
        public void UploadEntry()
        {
            Leaderboards.Leaderboard.UploadNewEntry(_usernameInputField.text, Score, isSuccessful =>
            {
                if (isSuccessful)
                    LoadEntries();
            });
        }
    }
}
