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

#### *8) Що таке virtual, override та як працює new у C#? Яка між ними різниця?*
+ **virtual** – оголошує метод у базовому класі, який можна перевизначити.
  
+ **override** – перевизначає virtual метод у похідному класі, забезпечує поліморфізм.
  
+ **new** – приховує метод базового класу, але не перевизначає його (не працює з поліморфізмом).

Різниця між virtual/override та new:
  
 **virtual/override**: якщо потрібно замінити метод і зберегти поліморфізм.
  
**new**: якщо потрібно приховати метод без поліморфізму.

#### *9) Як працює base у конструкторах?*
У C# base(...) у конструкторах викликає конструктор базового класу перед виконанням конструктора похідного класу. 

Це потрібно, коли базовий клас має конструктори з параметрами або коли треба ініціалізувати поля базового класу.

Якщо базовий клас не має конструктора без параметрів, похідний клас обов'язково має викликати один із його конструкторів через base(...).

#### *10) Що буде, якщо в класі похідному від BaseClass створити метод із такою ж назвою, як у BaseClass, без override і без new?*
+ Код працюватиме, але компілятор покаже warning: *"BaseClass.Show() is hidden by DerivedClass.Show() without new."*
+ Щоб уникнути цього, треба додати new (для явного приховування) або override (для перевизначення, якщо метод virtual).

#### *11) Як створити нову гілку у Git?*
git branch <branch_name> - вводимо у консоль

#### *12) Як перемкнутися на іншу гілку?*
git switch <назва_гілки> - вводимо у консоль

#### *13) Як об’єднати гілку в main після завершення лабораторної роботи?*
1. Перейти на main: git checkout main  
2. Оновити main:git pull origin main  
3. Об'єднати гілку: git merge <назва_гілки>
4. Видалити гілку: git branch -d <назва_гілки>  
5. Відправити зміни на сервер: git push origin main


## 9) Контрольні запитання ЛР3


#### *1. Що таке колекції в C#? Які їх переваги порівняно з масивами?*

**Колекції** — це спеціалізовані структури даних, які виступають контейнерами для зберігання груп об'єктів. Їхня ключова особливість — здатність динамічно змінювати свій розмір під час виконання програми.
Переваги колекцій порівняно з масивами:
Динамічний розмір: колекції автоматично розширюються при додаванні елементів, тоді як масиви мають фіксований розмір, визначений при створенні
Багатий набір методів: колекції надають численні вбудовані методи для маніпуляцій з даними (додавання, видалення, пошук, сортування тощо)
Підтримка LINQ: колекції повністю інтегруються з LINQ, що дозволяє писати виразні запити для фільтрації, сортування та перетворення даних


#### *2. Що таке List? Які основні методи для роботи зі списками?*

List<T> — це найпоширеніша узагальнена колекція в C#, яка представляє динамічний список елементів певного типу T. Вона забезпечує типобезпечне зберігання даних та ефективний доступ до елементів за індексом.
Основні методи для роботи з List:
+ Add(T item) — додає елемент у кінець списку
  
+ Remove(T item) — видаляє перше входження вказаного елемента

+ RemoveAt(int index) — видаляє елемент за вказаним індексом

+ Contains(T item) — перевіряє наявність елемента в списку

+ Sort() — сортує елементи списку за зростанням

+ Find(Predicate<T> match) — знаходить перший елемент, що відповідає заданій умові

Приклад використання методів List<T>

var animals = new List<string>();
animals.Add("Cat");                  // Adding an element
animals.Remove("Cat");               // Removing an element
bool contains = animals.Contains("Dog");  // Checking if contains
animals.Sort();                      // Sorting the list
var found = animals.Find(a => a.StartsWith("C"));  // Finding by condition


#### *3. Що таке Generics у C#? Чому вони важливі?*

**Generics** (узагальнення) — це потужний механізм C#, що дозволяє створювати класи, методи та інтерфейси, які працюють з будь-яким типом даних без втрати типобезпеки. Замість створення окремих реалізацій для кожного типу, ви можете створити одну узагальнену версію.

Важливість Generics:

+ Типобезпека: забезпечують перевірку типів на етапі компіляції, що допомагає виявляти помилки раніше

+ Уникнення дублювання коду: дозволяють писати код один раз і використовувати його з різними типами даних

+ Підвищена продуктивність: уникають операцій boxing/unboxing для типів-значень, що покращує швидкодію

+ Кращий дизайн: сприяють створенню більш чистого та підтримуваного коду


#### *4. Які обмеження можна накласти на Generics (where T : Animal)?*

При використанні узагальнень можна накладати обмеження на параметр типу T, щоб гарантувати, що він має певні характеристики:
where T : class — обмежує T лише посилальними типами (класами, інтерфейсами, делегатами)
where T : struct — обмежує T лише типами-значеннями (структурами, перерахуваннями)
where T : Animal — обмежує T типом Animal або його похідними класами
where T : new() — вимагає, щоб T мав публічний конструктор без параметрів
where T : IComparable<T> — вимагає, щоб T реалізовував вказаний інтерфейс

Приклад використання обмежень:

public class AnimalHandler<T> where T : Animal, new()
{
    public T CreateAnimal()
    {
        return new T();
    }
     public void FeedAnimal(T animal)
    {
      animal.Eat();
    }
}


#### *5. Що таке оператори is та as у C#? Наведіть приклади використання.*

Оператори is та as використовуються для безпечної роботи з типами та перевірки типів під час виконання:
Оператор is перевіряє, чи об'єкт належить до певного типу, і може одночасно конвертувати його (pattern matching):

Сучасний підхід з використанням шаблону

if (animal is Cat cat)
{
    Console.WriteLine($"This is a cat named {cat.Name}");
}
Оператор as намагається привести об'єкт до вказаного типу. Якщо приведення неможливе, повертає null:


Безпечне приведення типу
Dog dog = animal as Dog;
if (dog != null)
{
    Console.WriteLine($"The dog {dog.Name} is barking");
}


#### *6. Що таке LINQ? Які основні операції можна виконувати за допомогою LINQ?*

**LINQ** (Language Integrated Query) — це набір функцій в C#, що надає єдиний синтаксис для запитів до різних джерел даних (колекцій, XML, баз даних тощо). LINQ дозволяє писати декларативні запити безпосередньо в коді C#.
Основні операції LINQ:

+ Where() — фільтрація елементів за певною умовою

+ OrderBy(), OrderByDescending() — сортування елементів за зростанням або спаданням

+ Select() — проекція (перетворення) елементів у новий формат

+ FirstOrDefault(), Any(), Count() — пошук елементів та агрегація даних

+ GroupBy() — групування елементів за певною ознакою

Приклад LINQ-запиту:

var youngAnimals = animals
    .Where(a => a.Age < 5)
    .OrderBy(a => a.Name)
    .Select(a => new { a.Name, a.Age });

#### *7. Які є способи сортування списку в LINQ? Наведіть приклади.*

LINQ пропонує гнучкі можливості для сортування даних:

Сортування за зростанням

var byName = list.OrderBy(x => x.Name);

// Сортування за спаданням
var byAgeDescending = list.OrderByDescending(x => x.Age);

// Багаторівневе сортування
var complex = list
    .OrderBy(x => x.LastName)
    .ThenBy(x => x.FirstName);


#### *8. Що таке патерн Repository? Які його переваги?*

**Repository** — це шаблон проєктування, який створює рівень абстракції між бізнес-логікою програми та джерелом даних. Він інкапсулює логіку доступу до даних і надає інтерфейс для роботи з колекцією об'єктів.

Переваги патерну Repository:

+ Розділення відповідальності: відокремлює логіку доступу до даних від бізнес-логіки

+ Спрощене тестування: дозволяє легко підмінювати реальні сховища даних mock-об'єктами під час тестування

+ Централізація логіки доступу до даних: запобігає дублюванню коду для доступу до даних

+ Гнучкість: полегшує зміну джерела даних без впливу на бізнес-логіку


#### *9. Які основні методи повинен містити IRepository?*

Інтерфейс IRepository<T> зазвичай містить методи для базових операцій з даними:
   public interface IRepository<T> where T : class
{
    Отримання об'єкта за ідентифікатором
    T GetById(int id);
    
  Отримання всіх об'єктів
    List<T> GetAll();
    
  Додавання нового об'єкта
    void Add(T entity);
    
   Видалення об'єкта
    void Remove(T entity);
    
  Додатково: оновлення об'єкта
    void Update(T entity);
}


#### *10. Як реалізувати Generic Repository в C#?*

Ось приклад реалізації узагальненого репозиторію:
public class GenericRepository<T> : IRepository<T> where T : BaseEntity
{
    // Колекція для зберігання об'єктів
    protected List<T> _entities = new();

  // Додавання об'єкта
    public void Add(T entity) => _entities.Add(entity);
    
  // Видалення об'єкта
    public void Remove(T entity) => _entities.Remove(entity);
    
   // Пошук об'єкта за ідентифікатором
    public T GetById(int id) => _entities.FirstOrDefault(e => e.Id == id);
    
  // Отримання всіх об'єктів (створюємо копію для безпеки)
    public List<T> GetAll() => new List<T>(_entities);
    
   // Оновлення об'єкта
    public void Update(T entity)
    {
        var index = _entities.FindIndex(e => e.Id == entity.Id);
        if (index >= 0) _entities[index] = entity;
    }
}


#### *11. Що таке CRUD-операції? Як вони реалізуються в Repository?*

**CRUD** —  описує чотири основні операції, які виконуються з даними в інформаційних системах:

+ Create (створення) — додавання нових даних
  
+ Read (читання) — отримання існуючих даних

+ Update (оновлення) — зміна існуючих даних
  
+ Delete (видалення) — видалення даних
  
Реалізація CRUD-операцій в Repository:
Copy// Create - створення
public void Add(T entity) => _entities.Add(entity);

// Read - читання
public T GetById(int id) => _entities.FirstOrDefault(e => e.Id == id);
public List<T> GetAll() => new List<T>(_entities);

// Update - оновлення
public void Update(T entity)
{
    var index = _entities.FindIndex(e => e.Id == entity.Id);
    if (index >= 0) _entities[index] = entity;
}

// Delete - видалення
public void Remove(T entity) => _entities.Remove(entity);
Така реалізація Repository дозволяє стандартизувати доступ до даних та спростити взаємодію між різними шарами програми.


## 10) Контрольні запитання ЛР4


#### *1. Що таке делегат у C#? Яка його основна функція?*

**Делегат** — це тип, який представляє посилання на метод. Він дозволяє передавати методи як параметри, зберігати їх у змінних і викликати їх динамічно.
Основна функція делегата — забезпечити гнучкість виклику методів, зокрема для колбеків, подій і функціонального програмування.


#### *2. Як визначити делегат у C#? Наведіть приклад.*

Делегат визначається за допомогою ключового слова **delegate**. Він описує сигнатуру методів, на які може посилатися.

Приклад:

delegate void MyDelegate(string message); // Оголошення делегата

class Program
{
    static void ShowMessage(string msg)
    {
        Console.WriteLine(msg);
    }

   static void Main()
    {
        MyDelegate del = ShowMessage; // Присвоюємо метод делегату
        
   del("Привіт!"); // Виклик методу
    }
}


#### *3. У чому різниця між делегатом і звичайним методом?*

**Метод** — це блок коду, який виконує певну дію.

**Делегат** — це тип, який дозволяє посилатися на методи та викликати їх динамічно.

Головна різниця:
Делегати дають змогу передавати методи як параметри, викликати кілька методів одночасно (multicast), а також використовувати їх у подіях.


#### *4. Що таке делегат з кількома методами (multicast delegate)? Як він працює?*

**Multicast delegate** — це делегат, який може зберігати кілька методів і викликати їх послідовно. Це корисно для подій або коли потрібно виконати кілька дій. Це можливо завдяки операторам += (додавання методу) та -= (видалення методу).

Принцип роботи: 

+ Оголошуємо делегат

+ Додаємо кілька методів

+ Викликаємо делегат, і всі методи виконаються в порядку додавання


Приклад:

delegate void MyDelegate(string message);

class Program
{
    static void ShowMessage1(string msg) => Console.WriteLine("Message 1: " + msg);
    static void ShowMessage2(string msg) => Console.WriteLine("Message 2: " + msg);

   static void Main()
    {
        MyDelegate del = ShowMessage1;
        del += ShowMessage2; // Додаємо ще один метод
   
  del("Привіт!"); // Викликає обидва методи
    }
}

#### *5. Що таке анонімний метод і коли його використовують?*


**Анонімний метод** — це метод без імені, який можна визначити безпосередньо у виразі delegate. Він дозволяє створювати швидкі, одноразові методи без необхідності їх окремого оголошення. Анонімні методи корисні, коли метод використовується лише в одному місці. Також код стає коротшим і більш читабельним, оскільки немає потреби створювати зайві іменовані методи.


#### *6. Як відрізняються делегати, анонімні методи та лямбда-вирази?*

**Делегат** — це тип, який зберігає посилання на метод із певною сигнатурою. Його можна використовувати для передачі методів у якості аргументів або виклику кількох методів через multicast delegate.

**Анонімний метод** — це метод без імені, який визначається безпосередньо у виразі delegate. Він дозволяє створювати швидкі, одноразові методи.

**Лямбда-вираз** — це більш короткий спосіб запису анонімних методів. Вони дозволяють визначати функції у спрощеному синтаксисі та широко використовуються у LINQ та подіях.


#### *7. Що таке вбудовані делегати Func<T> , Action<T> і Predicate<T>? Чим вони корисні?*


C# має вбудовані делегати, які зменшують необхідність оголошення власних делегатів. Ці делегати спрощують код і часто використовуються з LINQ.

+ Action<T> — делегат для методів без повернення значення (void).

+ Func<T, TResult> — делегат для методів, що повертають значення.

+ Predicate<T> — делегат, що повертає bool.


#### *8. Що таке подія у C#? Чим вона відрізняється від делегата?*


**Подія** (event) — це механізм, що дозволяє класам взаємодіяти, не знаючи деталей реалізації один одного.

Різниця між делегатом і подією:

| Делегат | Подія | 
| -------- | -------- |
|Може викликатися з будь-якого місця    | Викликається тільки зсередини класу    |
| Може бути перезаписаний (=) | Додає і видаляє підписників (+=, -=) |
| Необов’язково використовується для подій | Використовується для зв'язку між об'єктами |

## 10) Контрольні запитання ЛР5
#### *1. У чому різниця між аутентифікацією та авторизацією?*
+ **Аутентифікація** — це процес перевірки особистості користувача (чи ти той, за кого себе видаєш?).
+ **Авторизація** — це перевірка прав доступу (чи маєш ти право щось робити після входу?).
*Приклад: ти заходиш у систему — це аутентифікація. Система дає тобі доступ лише до певних функцій — це авторизація.*

#### *2. Які основні методи аутентифікації використовуються в інформаційних системах?*
+ Парольна аутентифікація (логін + пароль);
+ Двофакторна аутентифікація (2FA) — додатковий код з SMS, пошти або додатку;
+ Біометрична (відбитки пальців, розпізнавання обличчя);
+ Сертифікатна (цифрові сертифікати);
+ OAuth / SSO — вхід через сторонні сервіси (Google, Facebook).

#### *3. Що таке хешування та для чого воно використовується?*
**Хешування** — це одностороннє перетворення вхідних даних у фіксований рядок символів (хеш).
Використовується для захищеного зберігання паролів, оскільки хеш складно (майже неможливо) обернути назад у початкове значення.

#### *4. Які ключові характеристики хеш-функцій?*
+ **Детермінованість** — один і той самий вхід завжди дає один і той самий хеш;
+ **Швидкість обчислення** (для загального хешування);
+ **Односторонність** — неможливо відновити оригінал із хешу;
+ **Стійкість до колізій** — складно знайти два різних входи з однаковим хешем;
+ **Стійкість до підбору** (preimage resistance).

#### *5. Чому небезпечно зберігати паролі у відкритому вигляді?*
Якщо база даних буде скомпрометована — зловмисник отримає доступ до всіх паролів, які можна одразу використовувати. Це пряме порушення безпеки й конфіденційності користувачів.

#### *6. Що таке сіль (salt)? Для чого вона використовується у хешуванні паролів?*
**Сіль** — це випадковий рядок, який додається до пароля перед хешуванням.
Використовується для того, щоб:
+ зробити кожен хеш унікальним;
+ запобігти атакам через rainbow tables (попередньо обчислені таблиці хешів).

#### *7. Чому двом однаковим паролям у базі повинні відповідати різні хеші?*
Щоб неможливо було здогадатися, що два користувачі мають однаковий пароль. Це досягається через індивідуальну сіль для кожного пароля.

#### *8. Що таке ітеративність у контексті хешування паролів? Чому збільшення кількості ітерацій ускладнює злам пароля?*
**Ітеративність** — це багаторазове застосування хеш-функції до одного й того ж пароля (наприклад, 1000 разів).
Більше ітерацій = більше часу на підбір = ускладнення Brute Force атак.

#### *9. У чому відмінність між BCrypt.HashPassword() та BCrypt.EnhancedHashPassword()?*
**HashPassword()** — стандартне хешування з вбудованою сіллю та ітераціями;
**EnhancedHashPassword()** — використовує покращену версію з додатковими параметрами захисту (включно з більшою стійкістю до side-channel атак та складнішими схемами сольового хешування).

#### *10. Як перевірити правильність пароля при вході?*
1. Отримати пароль, введений користувачем.
2. Застосувати той самий алгоритм хешування (використовуючи сіль, збережену разом із хешем).
3. Порівняти обчислений хеш із хешем у базі даних.
У випадку з BCrypt, зазвичай використовують:
*BCrypt.Verify(введенийПароль, збереженийХеш)*

#### *11. Що відбувається, коли користувач вводить неправильний пароль? Які механізми можна використати для захисту від Brute Force атак?*
+ Система повідомляє про помилку входу.
+ Механізми захисту:
++ Ліміт спроб входу (наприклад, не більше 5 разів);
++ Затримка між спробами (exponential backoff);
++ Captcha після кількох невдалих спроб;
++ Tarpitting — уповільнення відповіді сервера;
++ Блокування акаунту або IP-адреси на певний час.



