// FormShowState.cs
using System;
using System.Windows.Forms;

namespace GameAssistant
{
    // Форма для відображення стану репозиторію.
    public class FormShowState : Form
    {
        private PlayerRepository _playerRepository;
        private TextBox txtOutput;

        public FormShowState(PlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Стан репозиторію";
            this.Size = new System.Drawing.Size(400, 300);

            txtOutput = new TextBox
            {
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Dock = DockStyle.Fill,
                ReadOnly = true
            };

            this.Controls.Add(txtOutput);

            ShowRepositoryState();
        }

        // Відображає поточний стан репозиторію.
        private void ShowRepositoryState()
        {
            txtOutput.Clear();
            txtOutput.AppendText("Поточний стан репозиторію:\n");
            foreach (var player in _playerRepository.GetAll())
            {
                txtOutput.AppendText($"{player.Role} (Живий: {player.IsAlive}, Виставлений: {player.IsNominated})\n");
            }
        }
    }
}