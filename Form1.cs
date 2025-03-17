// Form1.cs
using System;
using System.Windows.Forms;
using System.Data;

namespace GameAssistant
{
    // Головна форма програми.
    public partial class Form1 : Form
    {
        private GameMaster gameMaster;
        private DataGridView dgv;
        private Button btnVote;
        private Button btnNominate;
        private Button btnHeal;
        private Button btnShowState;
        private Button btnSortByRole;
        private Button btnClearRole;  // Нова кнопка для очищення ролі
        private PlayerRepository playerRepository;

        public Form1()
        {
            gameMaster = new GameMaster();
            playerRepository = new PlayerRepository();
            SetupUI();
        }

        // Метод для налаштування графічного інтерфейсу.
        private void SetupUI()
        {
            dgv = new DataGridView
            {
                Dock = DockStyle.Top,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = true,
                AllowUserToDeleteRows = true,
                Height = 200
            };

            dgv.Columns.Add("Number", "Номер");
            dgv.Columns.Add("Player", "Гравець");

            // Змінено: Додаємо налаштування для комбобокса, щоб початково вказувалась роль "Немає"
            DataGridViewComboBoxColumn roleColumn = new DataGridViewComboBoxColumn
            {
                Name = "Role",
                HeaderText = "Роль",
                DataSource = new string[] { "Немає", "Мирний", "Шериф", "Лікар", "Мафія", "Дон" },
                DefaultCellStyle = new DataGridViewCellStyle { NullValue = "Немає" }
            };
            dgv.Columns.Add(roleColumn);

            // Налаштування події для нових рядків, щоб роль за замовчуванням була "Немає"
            dgv.DefaultValuesNeeded += (sender, e) =>
            {
                e.Row.Cells["Role"].Value = "Немає";
            };

            dgv.Columns.Add("Comment", "Коментар");
            dgv.Columns.Add("Votes", "Голоси");
            dgv.Columns.Add("Alive", "Живий");

            // Додано нову кнопку для очищення ролі
            btnClearRole = new Button { Text = "Прибрати роль", Dock = DockStyle.Bottom };
            btnClearRole.Click += BtnClearRole_Click;

            btnVote = new Button { Text = "Проголосувати", Dock = DockStyle.Bottom };
            btnVote.Click += BtnVote_Click;

            btnNominate = new Button { Text = "Виставити на голосування", Dock = DockStyle.Bottom };
            btnNominate.Click += BtnNominate_Click;

            btnHeal = new Button { Text = "Лікувати", Dock = DockStyle.Bottom };
            btnHeal.Click += BtnHeal_Click;

            btnShowState = new Button { Text = "Показати стан репозиторію", Dock = DockStyle.Bottom };
            btnShowState.Click += BtnShowState_Click;

            btnSortByRole = new Button { Text = "Сортувати за ролями", Dock = DockStyle.Bottom };
            btnSortByRole.Click += BtnSortByRole_Click;

            Controls.Add(dgv);
            Controls.Add(btnClearRole);
            Controls.Add(btnVote);
            Controls.Add(btnNominate);
            Controls.Add(btnHeal);
            Controls.Add(btnShowState);
            Controls.Add(btnSortByRole);
        }

        // Додано новий обробник події для кнопки "Прибрати роль"
        private void BtnClearRole_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgv.SelectedRows)
                {
                    // Встановлюємо значення "Немає" для вибраних рядків
                    row.Cells["Role"].Value = "Немає";
                }
            }
            else if (dgv.SelectedCells.Count > 0)
            {
                int rowIndex = dgv.SelectedCells[0].RowIndex;
                dgv.Rows[rowIndex].Cells["Role"].Value = "Немає";
            }
        }

        // Оновлює статус "Живий" у таблиці.
        private void UpdateAliveStatus()
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["Alive"].Value != null)
                {
                    row.Cells["Alive"].Value = "Так";
                }
            }
        }

        // Обробник події для кнопки "Проголосувати".
        private void BtnVote_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                string playerName = dgv.SelectedRows[0].Cells["Player"].Value.ToString();
                gameMaster.MarkVote(new Civilian(), playerName);
            }
        }

        // Обробник події для кнопки "Виставити на голосування".
        private void BtnNominate_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                string playerName = dgv.SelectedRows[0].Cells["Player"].Value.ToString();
                gameMaster.NominateForVoting(new Civilian());
            }
        }

        // Обробник події для кнопки "Лікувати".
        private void BtnHeal_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                General_Props player = new Civilian();
                Doctor doctor = new Doctor();
                doctor.HealPlayer(player);
                UpdateAliveStatus();
            }
        }

        // Обробник події для кнопки "Показати стан репозиторію".
        private void BtnShowState_Click(object sender, EventArgs e)
        {
            // Оновлюємо дані в репозиторії з таблиці
            playerRepository = new PlayerRepository();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["Player"].Value != null &&
                    row.Cells["Role"].Value != null &&
                    row.Cells["Role"].Value.ToString() != "Немає")
                {
                    string role = row.Cells["Role"].Value.ToString();
                    bool isAlive = row.Cells["Alive"].Value != null &&
                                 row.Cells["Alive"].Value.ToString() == "Так";

                    General_Props player;
                    switch (role)
                    {
                        case "Лікар":
                            player = new Doctor();
                            break;
                        case "Мафія":
                            player = new Mafia();
                            break;
                        default:
                            player = new Civilian();
                            break;
                    }

                    player.Role = role;
                    player.IsAlive = isAlive;
                    player.IsNominated = false;

                    playerRepository.Add(player);
                }
            }

            FormShowState formShowState = new FormShowState(playerRepository);
            formShowState.ShowDialog();
        }

        // Обробник події для кнопки "Сортувати за ролями".
        private void BtnSortByRole_Click(object sender, EventArgs e)
        {
            // Оновлюємо дані в репозиторії з таблиці
            playerRepository = new PlayerRepository();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["Player"].Value != null &&
                    row.Cells["Role"].Value != null &&
                    row.Cells["Role"].Value.ToString() != "Немає")
                {
                    string role = row.Cells["Role"].Value.ToString();
                    bool isAlive = row.Cells["Alive"].Value != null &&
                                 row.Cells["Alive"].Value.ToString() == "Так";

                    General_Props player;
                    switch (role)
                    {
                        case "Лікар":
                            player = new Doctor();
                            break;
                        case "Мафія":
                            player = new Mafia();
                            break;
                        default:
                            player = new Civilian();
                            break;
                    }

                    player.Role = role;
                    player.IsAlive = isAlive;
                    player.IsNominated = false;

                    playerRepository.Add(player);
                }
            }

            FormSortByRole formSortByRole = new FormSortByRole(playerRepository);
            formSortByRole.ShowDialog();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}