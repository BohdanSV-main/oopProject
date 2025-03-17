// FormSortByRole.cs
using System;
using System.Linq;
using System.Windows.Forms;

namespace GameAssistant
{
    // Форма для відображення відсортованих гравців за ролями.
    public class FormSortByRole : Form
    {
        private PlayerRepository _playerRepository;
        private TextBox txtOutput;

        public FormSortByRole(PlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Сортування за ролями";
            this.Size = new System.Drawing.Size(400, 300);

            txtOutput = new TextBox
            {
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Dock = DockStyle.Fill,
                ReadOnly = true
            };

            this.Controls.Add(txtOutput);

            ShowSortedPlayers();
        }

        // Відображає відсортованих гравців за ролями.
        private void ShowSortedPlayers()
        {
            txtOutput.Clear();

            // Сортування гравців за пріоритетом ролі
            var sortedPlayers = _playerRepository.GetAll().OrderBy(p => GetRolePriority(p.Role));

            txtOutput.AppendText("Гравці, відсортовані за ролями:\n");
            foreach (var player in sortedPlayers)
            {
                txtOutput.AppendText($"{player.Role} (Живий: {player.IsAlive})\n");
            }
        }

        // Метод для визначення пріоритету ролі для сортування
        private int GetRolePriority(string role)
        {
            switch (role)
            {
                case "Дон":
                    return 1;
                case "Мафія":
                    return 2;
                case "Шериф":
                    return 3;
                case "Лікар":
                    return 4;
                case "Мирний":
                    return 5;
                default:
                    return 6; // Інші ролі будуть в кінці
            }
        }
    }
}