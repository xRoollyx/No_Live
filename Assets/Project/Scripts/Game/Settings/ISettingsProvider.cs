using System.Threading.Tasks;

namespace Project.Scripts.Game.Settings{
    public interface ISettingsProvider{
        GameSettings GameSettings {get;}
        ApplicationSettings ApplicationSettings {get;}
        
        Task<GameSettings> LoadGameSettings();
    }
}