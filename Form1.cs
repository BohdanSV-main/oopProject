using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using GameAssistant;

namespace GameAssistant
{
    // Інтерфейс IRoleAction визначає метод PerformRoleAction, який мають реалізувати всі класи, що його імплементують.
    // Це приклад інтерфейсу
    public interface IRoleAction
    {
        void PerformRoleAction();
    }

    // Абстрактний клас General_Props є базовим класом для всіх ролей у грі.
    // Це приклад абстрактного класу та динамічного поліморфізму (через перевизначення методів).
    public abstract class General_Props : IRoleAction
    {
        protected string votedFor;
        protected bool isNominated;
        protected bool isAlive;
        protected string role;

        public string VotedFor { get => votedFor; set => votedFor = value; }
        public bool IsNominated { get => isNominated; set => isNominated = value; }
        public bool IsAlive { get => isAlive; set => isAlive = value; }
        public bool IsActiveRole => Role == "Шериф" || Role == "Лікар" || Role == "Мафія" || Role == "Дон";
        public string Role { get => role; set => role = value; }

        // Це приклад **абстрактного методу** та **динамічного поліморфізму**.
        public abstract void PerformRoleAction();

        // Це приклад **віртуального методу** та **динамічного поліморфізму**.
        public virtual void DisplayStatus()
        {
            Console.WriteLine($"Роль: {Role}, Живий: {IsAlive}, Виставлений: {IsNominated}, Голосував за: {VotedFor}");
        }
    }

    // Клас Civilian успадковує General_Props і реалізує метод PerformRoleAction.
    // Це приклад **наслідування** та **динамічного поліморфізму**
    public class Civilian : General_Props
    {
        public Civilian()
        {
            Role = "Мирний";
            IsAlive = true;
            IsNominated = false;
            VotedFor = "";
        }

        // Перевизначення абстрактного методу PerformRoleAction.
        public override void PerformRoleAction()
        {
            Console.WriteLine("Мирний житель не має активної дії.");
        }
    }

    // Клас Doctor успадковує Civilian і додає нову функціональність (метод HealPlayer).
    // Це приклад **наслідування**
    public class Doctor : Civilian
    {
        public Doctor() : base()
        {
            Role = "Лікар";
        }

        // Новий метод HealPlayer, який дозволяє лікарю лікувати гравців.
        public void HealPlayer(General_Props player)
        {
            if (!player.IsAlive)
            {
                player.IsAlive = true;
                Console.WriteLine($"Лікар врятував гравця {player.Role}!");
            }
            else
            {
                Console.WriteLine("Гравець уже живий, лікування не потрібне.");
            }
        }

        // Перевизначення методу PerformRoleAction для лікаря.
        public override void PerformRoleAction()
        {
            Console.WriteLine("Лікар може врятувати одного гравця за ніч.");
        }
    }

    // Клас Mafia успадковує General_Props і реалізує метод PerformRoleAction.
    public class Mafia : General_Props
    {
        public bool IsMafia { get; private set; }

        public Mafia()
        {
            Role = "Мафія";
            IsAlive = true;
            IsNominated = false;
            VotedFor = "";
            IsMafia = true;
        }

        // Статичний поліморфізм (перевантаження методу KillPlayer)
        public void KillPlayer(General_Props player)
        {
            if (player.IsAlive)
            {
                player.IsAlive = false;
                Console.WriteLine($"Мафія вбила гравця {player.Role}!");
            }
            else
            {
                Console.WriteLine("Гравець уже мертвий.");
            }
        }

        public void KillPlayer(General_Props player, string reason)
        {
            if (player.IsAlive)
            {
                player.IsAlive = false;
                Console.WriteLine($"Мафія вбила гравця {player.Role}! Причина: {reason}");
            }
            else
            {
                Console.WriteLine("Гравець уже мертвий.");
            }
        }

        // Статичний поліморфізм (перевантаження методу LeaveComment)
        public void LeaveComment(string comment)
        {
            Console.WriteLine($"Мафія залишила коментар: {comment}");
        }

        public void LeaveComment(General_Props player, string comment)
        {
            Console.WriteLine($"Мафія залишила коментар про {player.Role}: {comment}");
        }

        public override void PerformRoleAction()
        {
            Console.WriteLine("Мафія може вбити одного гравця за ніч.");
        }
    }

    // Клас GameMaster керує(буде) гравцями та їх діями.
    public class GameMaster
    {
        public List<General_Props> Players { get; private set; }

        public GameMaster()
        {
            Players = new List<General_Props>();
        }

        // Метод для додавання(буде) гравця до списку.
        public void AddPlayer(General_Props player)
        {
            Players.Add(player);
        }

        // Метод для позначення голосу гравця.
        public void MarkVote(General_Props player, string target)
        {
            player.VotedFor = target;
            Console.WriteLine($"{player.Role} проголосував за {target}");
        }

        // Метод для виставлення гравця на голосування.
        public void NominateForVoting(General_Props player)
        {
            player.IsNominated = true;
            Console.WriteLine($"{player.Role} виставлений на голосування!");
        }
    }

    // Інтерфейс IRepository<T> визначає основні методи CRUD.
    public interface IRepository<T>
    {
        void Add(T item);
        void Remove(T item);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Update(T item);
    }

    // Клас реалізує інтерфейс IRepository<T>.
    public class Repository<T> : IRepository<T> where T : class
    {
        private List<T> _items = new List<T>();

        // Додає елемент до репозиторію.
        public void Add(T item)
        {
            _items.Add(item);
        }

        // Видаляє елемент з репозиторію.
        public void Remove(T item)
        {
            _items.Remove(item);
        }

        // Отримує елемент за ID.
        public T GetById(int id)
        {
            var item = _items.FirstOrDefault(i => (int)i.GetType().GetProperty("Id").GetValue(i) == id);
            return item;
        }

        // Отримує всі елементи з репозиторію.
        public IEnumerable<T> GetAll()
        {
            return _items;
        }

        // Оновлює елемент у репозиторії.
        public void Update(T item)
        {
            var existingItem = _items.FirstOrDefault(i => i == item);
            if (existingItem != null)
            {
                _items[_items.IndexOf(existingItem)] = item;
            }
        }

        // Сортує елементи за вказаним ключем.
        public IEnumerable<T> SortBy(Func<T, object> keySelector)
        {
            return _items.OrderBy(keySelector).ToList();
        }

        // Сортує елементи за користувацьким компаратором.
        public IEnumerable<T> SortByCustom(Func<T, T, int> comparer)
        {
            List<T> sortedList = new List<T>(_items);
            sortedList.Sort((a, b) => comparer(a, b));
            return sortedList;
        }

        // Відображає поточний стан репозиторію.
        public void ShowRepositoryState()
        {
            foreach (var item in _items)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }

    // Клас PlayerRepository успадковує Repository<General_Props> і додає метод для отримання живих гравців.
    public class PlayerRepository : Repository<General_Props>
    {
        public IEnumerable<General_Props> GetAlivePlayers()
        {
            return GetAll().Where(p => p.IsAlive).ToList();
        }
    }

    // Клас RoleRepository успадковує Repository<string> і додає метод для отримання активних ролей.
    public class RoleRepository : Repository<string>
    {
        public IEnumerable<string> GetActiveRoles()
        {
            return GetAll().Where(r => r == "Шериф" || r == "Лікар" || r == "Мафія" || r == "Дон").ToList();
        }
    }

    // Головна форма програми.
    public partial class MainForm : Form
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

        public MainForm()
        {
            InitializeComponent();
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
    }

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