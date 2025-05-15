using System;

// Пространство имён приложения
namespace SpaceConquest
{
    // Класс - планета
    public class Planet
    {
        // Свойство для имени планеты (только для чтения извне)
        public string Name { get; private set; }
        // Свойство для статуса захвата (только для чтения извне)
        public bool IsCaptured { get; private set; }

        // Конструктор для создания планеты
        public Planet(string name)
        {
            Name = name;
            IsCaptured = false; // Изначально планета не захвачена
        }

        // Метод для захвата планеты
        public void Capture()
        {
            IsCaptured = true;
        }
    }
}