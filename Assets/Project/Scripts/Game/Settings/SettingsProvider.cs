using System.Threading.Tasks;
using UnityEngine;

namespace Project.Scripts.Game.Settings{
    public class SettingsProvider : ISettingsProvider{
        private GameSettings _gameSettings;
        public GameSettings GameSettings => _gameSettings;
        public ApplicationSettings ApplicationSettings{ get; }

        public SettingsProvider(){
            ApplicationSettings = Resources.Load<ApplicationSettings>("ApplicationSettings");
        }
        
        public Task<GameSettings> LoadGameSettings(){
            _gameSettings = Resources.Load<GameSettings>("GameSettings");
            
            return Task.FromResult(GameSettings);
        }
    }
}