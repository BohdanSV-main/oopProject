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
- створення нових ролей з шаблонів;
- збереження розкладів ігор;
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

## 7) Контрольні запитання ЛР1
#### *1) Що таке CRUD і як він використовується у C#?*
**CRUD** – це чотири основні дії, що можна виконувати з даними у будь-якому застосунку:
+ Create  – додавання нових даних.
+ Read  – перегляд або отримання даних.
+ Update  – зміна існуючих даних.
+ Delete – видалення даних.
Зокрема у С# використовується для роботи з базами даних за допомогою Entity Framework (EF) або ADO.NET. Також CRUD можна реалізувати просто у списках, файлах або інших структурах даних.
#### *2) Як правильно визначати сутності та їх взаємозв’язки?*
Визначення сутностей та їх взаємозв’язків є ключовим етапом при проєктуванні бази даних або об'єктно-орієнтованої моделі. Основні кроки:
+ Аналіз предметної області – дослідження вимог та бізнес-процесів для виявлення основних об'єктів (сутностей), які потрібно моделювати.
+ Визначення сутностей – кожна сутність представляє об'єкт або концепцію з реального світу, що має значення для системи.
+ Визначення атрибутів – кожна сутність має характеристики, які її описують.
+ Визначення взаємозв’язків – встановлення зв'язків між сутностями, таких як "один до одного", "один до багатьох" або "багато до багатьох".
+ Створення діаграм – використання діаграм "сутність-зв'язок" (ERD) для візуалізації сутностей та їх взаємозв’язків, що допомагає краще зрозуміти структуру даних та забезпечити правильне проєктування системи.
#### *3) Яку технологію UI ви обрали та які вона має переваги?*
Windows Forms (WinForms) є простим у реалізації, гнучким для створення кнопок, таймерів і вікон повідомлень, а також дозволяє легко організувати управління грою через інтуїтивний інтерфейс.
#### *4) Що таке Git та які основні функції він виконує?*
**Git** — це розподілена система контролю версій, розроблена для відстеження змін у файлах та координації роботи між кількома розробниками. Вона дозволяє зберігати історію змін, працювати з різними гілками розробки та забезпечує інструменти для об'єднання змін.
Основні функції Git:
+ Відстеження змін – Git зберігає історію всіх змін, що дозволяє розробникам переглядати, коли і які зміни були внесені, а також повертатися до попередніх версій файлів за потреби.
+ Розподілена розробка – кожен розробник має повну копію репозиторію, включно з усією історією змін, що дозволяє працювати автономно та синхронізувати зміни з іншими.
+ Паралельна розробка – Git дозволяє створювати та працювати з гілками, що сприяє ізольованій розробці нових функцій або виправленню помилок без впливу на основну кодову базу.
+ Злиття змін – після завершення роботи в окремій гілці Git надає інструменти для об'єднання цих змін з основною гілкою, забезпечуючи інтеграцію нових функцій або виправлень.
+ Спільна робота – Git полегшує співпрацю між розробниками, дозволяючи їм працювати над різними частинами проєкту одночасно.
#### *5) Що таке commit, push, pull, merge та branch? Який повсякденний синтаксис використання зазначених команд?*
У Git існує кілька ключових команд, які забезпечують ефективне управління версіями та спільну розробку:
+ **commit** – фіксує зміни в локальному репозиторії.

  Синтаксис: git commit -m "Опис змін"

   Призначення: Зберігає знімок поточного стану проєкту з описом внесених змін.
+ **push** – відправляє зафіксовані зміни з локального репозиторію до віддаленого.

   Синтаксис: git push origin <назва_гілки>

   Призначення: Синхронізує локальні зміни з віддаленим репозиторієм, роблячи їх доступними для інших.
+ **pull** – отримує та інтегрує зміни з віддаленого репозиторію до локального.

   Синтаксис: git pull origin <назва_гілки>

  Призначення: Оновлює локальний репозиторій останніми змінами з віддаленого, об'єднуючи їх з поточними.
+ **merge** – об'єднує зміни з однієї гілки в іншу.

  Синтаксис: git merge <назва_гілки>

  Призначення: Інтегрує зміни з вказаної гілки до поточної, об'єднуючи історії комітів.
+ **branch** – керує гілками в репозиторії.

   Синтаксис для створення гілки: git branch <назва_гілки>

   Синтаксис для перегляду гілок: git branch

   Призначення: Дозволяє створювати, переглядати та видаляти гілки, що сприяє організації роботи над різними функціональностями або виправленнями.



## 8) Контрольні запитання ЛР2
#### *1) Що таке ООП та які його основні принципи?*

**Об’єктно-орієнтоване програмування (ООП)** – це методологія програмування, заснована на концепції об'єктів, які взаємодіють між собою. Програма розглядається як сукупність об'єктів, кожен із яких має певний стан (поля) та поведінку (методи).

Основні принципи ООП:

+ Інкапсуляція – це приховування внутрішньої реалізації об'єкта та надання доступу до нього лише через визначений інтерфейс. Наприклад, доступ до змінних класу може здійснюватися тільки через гетери й сетери.

+ Наслідування – це механізм, що дозволяє одному класу (дочірньому) отримувати властивості та методи іншого класу (батьківського). Це сприяє повторному використанню коду та спрощує його розширення.

+ Поліморфізм – це здатність об'єкта приймати різні форми, тобто викликати методи з однаковим ім'ям, але з різною реалізацією. Це дозволяє використовувати загальний інтерфейс для роботи з різними типами об'єктів.

+ Абстракція – це процес виділення суттєвих характеристик об'єкта та приховування несуттєвих деталей. Це допомагає створювати моделі реального світу в програмуванні.

#### *2) У чому різниця між абстрактним класом і звичайним класом?**

**Звичайний клас** є шаблоном для створення об'єктів і може містити як реалізовані методи, так і змінні. Він дозволяє створювати екземпляри цього класу.
**Абстрактний клас** є загальною концепцією, яка не призначена для створення об'єктів. Він використовується для того, щоб забезпечити базову реалізацію для похідних класів. Абстрактний клас може містити як реалізовані, так і абстрактні методи (методи без реалізації, які обов'язково мають бути перевизначені в похідних класах).

#### *3) Які модифікатори доступу існують?*

Модифікатори доступу визначають рівень доступу до полів, методів і класів.

+ public – доступний усім.

+ private – доступний лише в межах поточного класу.

+ protected – доступний у поточному класі та його нащадках.

+ internal – доступний лише в межах поточного збірки (assembly).

+ protected internal – доступний у поточному класі, його нащадках та в межах збірки.

+ private protected – доступний у поточному класі та в його нащадках у тій самій збірці.

#### *4) Чим відрізняється абстрактний метод від віртуального методу?*

Абстрактний метод не має реалізації і обов’язково має бути перевизначений у похідному класі. Він може бути тільки в абстрактному класі. Віртуальний метод має реалізацію за замовчуванням, але може бути перевизначений у похідному класі. Абстрактні методи змушують похідні класи реалізувати певний функціонал, а віртуальні методи надають базову реалізацію, яку можна змінювати.

#### *5) Що таке інтерфейс у C#?*

**Інтерфейс** – це набір методів та властивостей без реалізації, який клас повинен реалізувати. Інтерфейси використовуються для досягнення поліморфізму та визначення поведінки класів без обмеження їхньої ієрархії.

#### *6) У чому відмінність інтерфейсу від абстрактного класу?*

Інтерфейс визначає лише сигнатури методів і не містить реалізації (до C# 8.0). Абстрактний клас може містити як реалізовані, так і абстрактні методи.

Основні відмінності:

+ Інтерфейси використовуються для забезпечення загального контракту, тоді як абстрактні класи дозволяють створювати спільну поведінку.

+ Клас може наслідувати лише один абстрактний клас, але реалізовувати кілька інтерфейсів.

#### *7) Чи може клас реалізовувати кілька інтерфейсів одночасно?*

Так, клас може реалізовувати кілька інтерфейсів, що дозволяє об'єднувати різні типи поведінки в одному класі. Це можливо тому, що інтерфейси не містять реалізації, тому немає конфліктів, які можуть виникати при множинному успадкуванні класів.
