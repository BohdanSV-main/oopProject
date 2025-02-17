# Mafia Tracker 

## 1️) Назва застосунку👻
**Mafia Tracker** — це застосунок, що допомагає ведучим та гравцям гри "Мафія" автоматизувати розподіл ролей, вести документацію гри, фіксувати ключові події та зручно управляти ходом гри.

## 2️) Мета проєкту🎓
Розробити додаток на мові програмування C#, що:
- допомагає оптимізувати етап підготовки до гри та її ведення;
- полегшує життя ведучого автоматизацією роздачі ролей та ведення нотатків;
- дозволяє гравцям вести особисті нотатки у відведеному місці;
- надає можливість зберігати історію гри та переглядати її.

## 3️) Користувачі та їх можливості👥

### **Ведучий**
- введення кількості гравців та їхніх імен (нікнеймів);
- управління ролями (можливість налаштовувати кількість мафій, додавати чи прибирати альтернативні ролі);
- автоматична генерація ролей;
- фіксація подій кожного ходу (нічні дії, голосування, вибування) за допомогою спеціального шаблонного поля;
- контроль статусу гравців (активний/вибув);
- керування таймером для чіткого відстеження фаз кожного етапу гри;
- управління журналом подій та перегляд історії гри.

### **Гравець**
- поле для особистих записів біля кожного гравця;
- встановлення персонального таймера для власного контролю часу під час голосування;
- перегляд функціоналу кожної ролі, наведеної у грі (*зроблено для улюбленого старости* 😊);
- власне поле з можливістю позначки підозрюваних ролей та відстеження ходу гри.

## 4️) Основні сутності (основні об'єкти, якими оперує застосунок, та їх поля)📚

#### **Ведучий**
- нікнейм або ім'я гравця;
- роль гравця у грі;
- статус у грі (активний чи вибув).

#### **Поле гри (версія для ведучого)**
- список усіх гравців;
- поточний раунд;
- поточна фаза;
- список дій у грі;
- таймер.

#### **Поле гравця**
- журнал нотаток;
- список усіх гравців (без відображення ролей);
- таймер;
- вікно підказок із правилами;
- список дій у грі.

## 5️) Можливості застосунку⏳
- Автоматичний розподіл ролей із можливістю редагування ведучим;
- Таймер фаз гри для контролю тривалості голосування та нічних дій;
-  Журнал подій для фіксації всіх важливих дій у грі;
-  Перегляд історії гри після завершення партії;
-  Поле для нотаток для гравців із можливістю збереження записів;
-  Фіксація голосувань ведучим із підрахунком вибутого гравця;
-  Персональні мітки підозрюваних у полі гравця;
-  Вбудовані підказки щодо ролей для нових гравців;
-  Можливість змінювати тему оформлення (світла/темна).

## 6️) Вибір технології UI 📈
#### **Windows Forms (WinForms)**
- Простий у реалізації.
- Гнучкий для створення кнопок, таймерів, вікон повідомлень.
- Дозволяє легко організувати управління грою через інтуїтивний інтерфейс.

## 7) Контрольні запитання❓
#### *1) Що таке CRUD і як він використовується у C#?*
**CRUD** – це чотири основні дії, що можна виконувати з даними у будь-якому застосунку:
+ Create  – додавання нових даних.
+ Read  – перегляд або отримання даних.
+ Update  – зміна існуючих даних.
+ Delete – видалення даних.
Зокрема у С# використовується для роботи з базами даних за допомогою Entity Framework (EF) або ADO.NET. Також CRUD можна реалізувати просто у списках, файлах або інших структурах даних.
#### *2) Як правильно визначати сутності та їх взаємозв’язки?*
----пропишіть, бо голова не варе ---------
#### *3) Яку технологію UI ви обрали та які вона має переваги?*
Windows Forms (WinForms) є простим у реалізації, гнучким для створення кнопок, таймерів і вікон повідомлень, а також дозволяє легко організувати управління грою через інтуїтивний інтерфейс.
#### *4) Що таке Git та які основні функції він виконує?*
-----------------------------------------------------
#### *5) Що таке commit, push, pull, merge та branch? Який повсякденний синтаксис використання зазначених команд?*
-----------------------------------------------------
