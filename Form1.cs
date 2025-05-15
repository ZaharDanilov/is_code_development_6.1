using SpaceConquest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace is_code_development_6._1
{
    // Класс главной формы, унаследованный от Form
    public partial class Form1 : Form
    {
        // Элементы управления формы
        private Label lblPlanetName; // Метка для поля ввода названия планеты
        private TextBox txtPlanetName; // Поле ввода названия планеты
        private Button btnCapture; // Кнопка для захвата планеты
        private Button btnCheckStatus; // Кнопка для проверки статуса
        private Button btnReport; // Кнопка для вывода отчёта
        private TextBox txtOutput; // Поле для вывода результатов
        private SpaceHeadquarters headquarters; // Экземпляр Singleton

        // Конструктор формы
        public Form1()
        {
            InitializeComponents();
            // Получение экземпляра Singleton
            headquarters = SpaceHeadquarters.Instance;
        }

        // Метод инициализации элементов управления
        private void InitializeComponents()
        {
            // Настройка формы
            this.Text = "Главный космический штаб"; // Заголовок окна
            this.Size = new System.Drawing.Size(500, 400); // Размер окна
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Фиксированный размер
            this.MaximizeBox = false; // Отключение кнопки разворачивания

            // Метка для поля ввода названия планеты
            lblPlanetName = new Label
            {
                Text = "Название планеты:",
                Location = new System.Drawing.Point(20, 20),
                Size = new System.Drawing.Size(120, 20)
            };

            // Поле ввода названия планеты
            txtPlanetName = new TextBox
            {
                Location = new System.Drawing.Point(150, 20),
                Size = new System.Drawing.Size(300, 20)
            };

            // Кнопка "Захватить планету"
            btnCapture = new Button
            {
                Text = "Захватить планету",
                Location = new System.Drawing.Point(20, 60),
                Size = new System.Drawing.Size(140, 30)
            };
            btnCapture.Click += BtnCapture_Click;

            // Кнопка "Проверить статус"
            btnCheckStatus = new Button
            {
                Text = "Проверить статус",
                Location = new System.Drawing.Point(170, 60),
                Size = new System.Drawing.Size(140, 30)
            };
            btnCheckStatus.Click += BtnCheckStatus_Click;

            // Кнопка "Вывести отчёт"
            btnReport = new Button
            {
                Text = "Вывести отчёт",
                Location = new System.Drawing.Point(320, 60),
                Size = new System.Drawing.Size(140, 30)
            };
            btnReport.Click += BtnReport_Click;

            // Поле для вывода результатов
            txtOutput = new TextBox
            {
                Location = new System.Drawing.Point(20, 100),
                Size = new System.Drawing.Size(440, 240),
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical
            };

            // Добавление элементов на форму
            this.Controls.AddRange(new Control[] { lblPlanetName, txtPlanetName, btnCapture, btnCheckStatus, btnReport, txtOutput });
        }

        // Обработчик нажатия кнопки "Захватить планету"
        private void BtnCapture_Click(object sender, EventArgs e)
        {
            try
            {
                // Захват планеты
                headquarters.CapturePlanet(txtPlanetName.Text);
                // Вывод сообщения об успехе
                txtOutput.AppendText($"Планета {txtPlanetName.Text} успешно захвачена!\r\n");
                // Очистка поля ввода
                txtPlanetName.Clear();
            }
            catch (ArgumentException ex)
            {
                // Обработка ошибки пустого ввода
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Обработка прочих ошибок
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик нажатия кнопки "Проверить статус"
        private void BtnCheckStatus_Click(object sender, EventArgs e)
        {
            try
            {
                // Получение статуса планеты
                string status = headquarters.GetPlanetStatus(txtPlanetName.Text);
                // Вывод статуса
                txtOutput.AppendText(status + "\r\n");
                // Очистка поля ввода
                txtPlanetName.Clear();
            }
            catch (ArgumentException ex)
            {
                // Обработка ошибки пустого ввода
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Обработка прочих ошибок
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик нажатия кнопки "Вывести отчёт"
        private void BtnReport_Click(object sender, EventArgs e)
        {
            try
            {
                // Получение и вывод отчёта
                string report = headquarters.GetReport();
                txtOutput.AppendText(report + "\r\n");
            }
            catch (Exception ex)
            {
                // Обработка ошибок
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
