using is_code_development_6._1;
using System;
using System.Windows.Forms;


namespace SpaceConquest
{
    //запуск приложения
    static class Program
    {
        // Атрибут, указывающий на использование однопоточной модели STA
        [STAThread]
        static void Main()
        {
            // Включение визуальных стилей для современного вида элементов управления
            Application.EnableVisualStyles();
            // Установка совместимости рендеринга текста
            Application.SetCompatibleTextRenderingDefault(false);
            // Запуск приложения с созданием главной формы
            Application.Run(new Form1());
        }
    }
}