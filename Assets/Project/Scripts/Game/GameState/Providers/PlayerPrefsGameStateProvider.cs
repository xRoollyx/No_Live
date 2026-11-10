using System.Collections.Generic;
using Newtonsoft.Json;
using Project.Scripts.Game.GameState.GameResources;
using Project.Scripts.Game.GameState.Maps;
using Project.Scripts.Game.GameState.Root;
using R3;
using UnityEngine;

namespace Project.Scripts.Game.GameState.Providers{
    public class PlayerPrefsGameStateProvider : IGameStateProvider{
        private const string GAME_STATE_KEY = nameof(GAME_STATE_KEY);
        
        public Root.GameState GameState{ get; private set; }
        private GameStateData _gameStateDataOrigin;
        
        public Observable<Root.GameState> LoadGameState(){
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings(){
                TypeNameHandling = TypeNameHandling.Auto,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
            };
            
            if (!PlayerPrefs.HasKey(GAME_STATE_KEY)){
                GameState = CreateGameStateFromSettings();

                Debug.Log("Game State Created from Settings" + JsonConvert.SerializeObject(_gameStateDataOrigin, Formatting.Indented));
                SaveGameState();
            }
            else{
                var json = PlayerPrefs.GetString(GAME_STATE_KEY);
                _gameStateDataOrigin = JsonConvert.DeserializeObject<GameStateData>(json);
                GameState = new Root.GameState(_gameStateDataOrigin);
                
                Debug.Log("Game State loaded" + json);
            }

            return Observable.Return(GameState);
        }

        public Observable<bool> SaveGameState(){
            var json = JsonConvert.SerializeObject(_gameStateDataOrigin, Formatting.Indented);
            PlayerPrefs.SetString(GAME_STATE_KEY, json);

            return Observable.Return(true);
        }

        public Observable<bool> ResetGameState(){
            GameState = CreateGameStateFromSettings();
            SaveGameState();
            
            return Observable.Return(true);
        }

        private Root.GameState CreateGameStateFromSettings(){
            _gameStateDataOrigin = new GameStateData{
                Maps = new List<MapData>(),
                Resources = new List<ResourceData>{
                    new ResourceData{
                        ResourceType = ResourceType.SoftCurrency,
                        Amount = 0
                    },
                    new ResourceData{
                        ResourceType = ResourceType.HardCurrency,
                        Amount = 0
                    }
                }
            };
            var gameStateProxy  = new Root.GameState(_gameStateDataOrigin);
            return gameStateProxy;
        }
    }
}