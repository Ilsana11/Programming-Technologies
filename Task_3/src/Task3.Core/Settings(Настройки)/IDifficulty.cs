using Task3.Core.Settings;

namespace Task3.Core.Settings_Настройки_;
/// <summary>
/// Контракт для уровня сложности.
/// Каждый уровень сам знает свои параметры и умеет создавать настройки
/// </summary>
public interface IDifficulty
{
    /// <summary>
    /// Название уровня для отображения
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Короткое описание (диапазон и число попыток)
    /// </summary>
    string Description { get; }

    /// <summary>
    /// Создаёт настройки игры для этого уровня
    /// </summary>
    GameSettings CreateSettings();
}
