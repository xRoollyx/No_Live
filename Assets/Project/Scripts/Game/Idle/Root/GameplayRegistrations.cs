using System;
using System.Linq;
using Project.Scripts.DI;
using Project.Scripts.Game.Common;
using Project.Scripts.Game.GameState.Cmd;
using Project.Scripts.Game.GameState.Providers;
using Project.Scripts.Game.Idle.Cheats;
using Project.Scripts.Game.Idle.Commands;
using Project.Scripts.Game.Idle.Commands.Handlers;
using Project.Scripts.Game.Idle.Services;
using Project.Scripts.Game.Settings;
using R3;

namespace Project.Scripts.Game.Idle.Root{
    public static class GameplayRegistrations
    {
        private static GameState.Root.GameState _state;
        public static void Register(DiContainer container, GameplayEnterParams gameplayEnterParams){
            var gameStateProvider = container.Resolve<IGameStateProvider>();
            var gameState = gameStateProvider.GameState;
            var settingsProvider =  container.Resolve<ISettingsProvider>();
            var gameSettings = settingsProvider.GameSettings;
            
            container.RegisterInstance(AppConstants.EXIT_SCENE_REQUEST_TAG, new Subject<Unit>());
            
            var cmd = new CommandProcessor(gameStateProvider);
            cmd.RegisterHandler(new CmdPlaceEntityHandler(gameState));
            cmd.RegisterHandler(new CmdCreateMapHandler(gameState,gameSettings));
            cmd.RegisterHandler(new CmdResourcesAddHandler(gameState));
            cmd.RegisterHandler(new CmdResourcesSpendHandler(gameState));
            
            
            container.RegisterInstance<ICommandProcessor>(cmd);
            
            var loadingMapId = gameplayEnterParams.MapId;
            var loadingMap = gameState.Maps.FirstOrDefault(map => map.Id == loadingMapId);
            if (loadingMap == null){
                var command = new CmdCreateMap(loadingMapId);
                var success = cmd.Process(command);
                if (!success){
                    throw new Exception($"Can't create map {loadingMapId}");
                }
                loadingMap = gameState.Maps.First(map => map.Id == loadingMapId);
            }
            
            container.RegisterFactory(c => new BuildingsService(
                loadingMap.Entities, 
                gameSettings.EntitiesSettings, 
                cmd,
                c.Resolve<ResourcesService>()
                )).AsSingle();
            container.RegisterFactory(_=> new ResourcesService(gameState.Resources, cmd)).AsSingle();
            
            
            
            //container.RegisterFactory(_=> new ResourcesService(_state.Resources, new CommandProcessor(new PlayerPrefsGameStateProvider())));
            
            // TODO обвешать решетками что бы не попало в релиз
            container.RegisterFactory(c => new CheatsService(c.Resolve<BuildingsService>())).AsSingle();
        }
    }
}