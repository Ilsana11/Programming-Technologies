namespace Task3.Core.Settings;
/// <summary>
/// Контракт для получения настроек от пользователя
/// Принцип DIP
/// </summary>
public interface ISettingsProvider
{
    /// <summary>
    /// Возвращает готовые настройки игры. Если null - значит игрок вышел из игры
    /// </summary>
    GameSettings? GetSettings();
}
