using System;
using System.Collections.Generic;

// Пространство имён приложения
namespace SpaceConquest
{
    // Класс Главного космического штаба (Singleton)
    public class SpaceHeadquarters
    {
        // Приватное статическое поле для хранения единственного экземпляра
        private static SpaceHeadquarters _instance;
        // Объект для синхронизации потоков (потокобезопасность)
        private static readonly object _lock = new object();
        // Список планет
        private List<Planet> _planets;

        // Приватный конструктор для предотвращения создания экземпляров извне
        private SpaceHeadquarters()
        {
            _planets = new List<Planet>(); // Инициализация списка планет
        }

        // Публичный метод для получения экземпляра Singleton
        public static SpaceHeadquarters Instance
        {
            get
            {
                // Потокобезопасная инициализация
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new SpaceHeadquarters();
                    }
                    return _instance;
                }
            }
        }

        // Метод для захвата планеты
        public void CapturePlanet(string planetName)
        {
            // Проверка на null или пустую строку
            if (string.IsNullOrWhiteSpace(planetName))
            {
                throw new ArgumentException("Название планеты не может быть пустым.");
            }

            // Поиск планеты по имени (регистронезависимый)
            var planet = _planets.Find(p => p.Name.Equals(planetName, StringComparison.OrdinalIgnoreCase));

            if (planet == null)
            {
                // Создание новой планеты, если не найдена
                planet = new Planet(planetName);
                _planets.Add(planet);
            }

            // Захват планеты
            planet.Capture();
        }

        // Метод для получения статуса планеты
        public string GetPlanetStatus(string planetName)
        {
            // Проверка на null или пустую строку
            if (string.IsNullOrWhiteSpace(planetName))
            {
                throw new ArgumentException("Название планеты не может быть пустым.");
            }

            // Поиск планеты
            var planet = _planets.Find(p => p.Name.Equals(planetName, StringComparison.OrdinalIgnoreCase));
            if (planet == null)
            {
                return $"Планета {planetName} ещё не обнаружена.";
            }
            return $"Планета {planetName}: {(planet.IsCaptured ? "Захвачена" : "Не захвачена")}";
        }

        // Метод для получения отчёта о всех планетах
        public string GetReport()
        {
            if (_planets.Count == 0)
            {
                return "Нет данных о планетах.";
            }

            // Формирование отчёта
            var report = "Отчёт Главного космического штаба:\n";
            foreach (var planet in _planets)
            {
                report += $"Планета {planet.Name}: {(planet.IsCaptured ? "Захвачена" : "Не захвачена")}\n";
            }
            return report;
        }
    }
}