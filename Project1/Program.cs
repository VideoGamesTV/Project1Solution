using System;
using System.Globalization;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Timers;
using System.Xml.Serialization;

class SentenceGame
{
	static void Main(string[] strings)
	{
		bool exitMenu = false;

		while (!exitMenu)
		{
			Console.Clear();
			MainMenu();
			string choise = Console.ReadLine();
			switch (choise)
			{
				case "1":
					NameMenu();
					break;
				case "2":
					Console.WriteLine("Выход из программы...");
					exitMenu = true;
					break;
				default:
					Console.WriteLine("Неправильный выбор!");
					Console.ReadKey();
					break;
			}

		}
	}
	static void MainMenu()
	{
		Console.WriteLine("Привет! Это мой первый проект на C#!");
		Console.WriteLine("Тебе нужно будет запомнить предложение за 5 секунд,\nА потом написать его по памяти");
		Console.WriteLine("После написания своего варианта в конце,\nБудет показан оригинал и ваш примеры");
		Console.WriteLine("Авторы: VideoGamesTV");
		Console.WriteLine("Контакты по сотрудничеству: ir1941044@gmail.com");
		Console.WriteLine("Контакты по сотрудничеству: t.me/Video_Games_TV");
		Console.WriteLine("1. Зайти в игру");
		Console.WriteLine("2. Выход на рабочий стол");
		Console.Write("Выберите: ");
	}
	static void NameMenu()
	{
		bool exitName = false;
		while (!exitName)
		{
			Console.Clear();
			//string sureName;
			Console.WriteLine("Придумайте никнейм или имя");
			Console.Write("Мой никнейм/Имя: ");
			string nickName = Console.ReadLine();
			bool nickNameEmptyOrNo = string.IsNullOrEmpty(nickName);
			if (nickNameEmptyOrNo)
			{
				NameSure(nickName);
				break;
			}
		}
	}
	static void GameMenu(string nickName)
	{
		bool exitGame = false;
		while (!exitGame)
		{
			Console.Clear();
			Console.WriteLine($"Привет {nickName}!\nВот правила игры: \nУ тебя есть 5 секунд что бы запомнить предложение,\nПотом тебе его нужно будет написать,\nА потом уже сверяй что правильно а что нет.");
			Console.WriteLine("1. Начать игру");
			Console.WriteLine("2. Вернутся");
			Console.Write("Выберите: ");
			string choice = Console.ReadLine();
			switch (choice)
			{
				case "1":
					Game(nickName);
					break;
				case "2":
					exitGame = true;
					break;
				default:
					Console.WriteLine("Неправильный выбор!");
					Console.ReadKey();
					break;
			}
		}
	}
	static void NameSure(string nickName)
	{
		bool exitSure = false;
		while (!exitSure)
		{
			bool nickNameEmptyOrNo = string.IsNullOrEmpty(nickName);
			Console.Clear();
			Console.WriteLine($"Вы правильно выбрали никнейм/имя?: {nickName}");
			Console.WriteLine("1. Да");
			Console.WriteLine("2. Нет");
			Console.Write("Выберите: ");
			string choice = Console.ReadLine();
			switch (choice)
			{
				case "1":
					if (!nickNameEmptyOrNo == true)
					{
						GameMenu(nickName);
					}
					else
					{
						Console.WriteLine("Вы неприваильно набрали имя/никнейм!");
						Console.ReadKey();
					}
					break;
				case "2":
					NameMenu();
					break;
				default:
					Console.WriteLine("Неправильный выбор!");
					Console.ReadKey();
					break;
			}
		}
	}
	static Random random = new Random();
	static void Game(string nickName)
	{



		string[] sentences = { "Собака шла по улице.", "Весеннее утро разбудило город первыми лучами солнца.", "Маленький котёнок ловко запрыгнул на подоконник и принялся наблюдать за птицами.",
		"В старом доме на окраине города тикали часы, которым было больше ста лет.", "Космический корабль медленно приближался к загадочной планете.",
		"Дети весело играли в прятки на зелёной лужайке.","Грозовые тучи стремительно надвигались с запада.","Аромат свежей выпечки наполнил всю пекарню.", "Учёные обнаружили новый вид морских существ на глубине океана.",
		"Старый дуб гордо возвышался над лесом.","Мелодичное пение птиц создавало волшебную атмосферу утра.","Весеннее утро разбудило город первыми лучами солнца, окрасив небо в нежные розовые тона.",
		"Маленький котёнок, играя с клубком, случайно запутался в нитках и смешно пытался освободиться.","Космический корабль медленно приближался к загадочной планете, окутанной таинственными облаками.",
		"В старом доме на окраине деревни тикали часы, которым было уже больше ста лет.","Учёные обнаружили новый вид морских существ на глубине океана.",
		"Дети весело смеялись, катаясь на карусели в парке аттракционов.","Первый снег покрыл землю белоснежным одеялом, превратив мир в сказку.",
		"Опытный повар создавал кулинарные шедевры, используя только свежие продукты.","Ветер шелестел листвой деревьев, создавая неповторимую мелодию природы.",
		"Путешественники преодолели сложный горный маршрут и достигли вершины к закату.","Фиолетовый бегемот грациозно танцевал танго на ржавой крыше сарая.",
		"Вчера утром все чайники в городе внезапно заговорили на древнегреческом.","Её воспоминания были упакованы в старые картонные коробки и задвинуты в самый дальний угол чердака.",
		"Космонавт, забытый в открытом космосе, пел песни своей бабушки про рябину.","Дождь из конфетти шёл ровно сорок минут, после чего асфальт стал скользким и праздничным.",
		"Он коллекционировал тишину разных марок и разливал её по хрустальным графинам.","Соседская кошка, оказывается, прекрасно играет в шахматы и всегда применяет защиту Каро-Канн.",
		"Зимой сосульки под окном звенят, как хрустальные колокольчики, если до них дотронуться варежкой.","Внутри старого пианино мы нашли карту, ведущую к острову, которого нет ни в одном атласе.",
		"Его новый бизнес-план заключался в продаже закатов в стеклянных банках.","Все облака сегодня имеют чёткую геометрическую форму – только треугольники и квадраты.",
		"Случайная встреча в лифте с незнакомцем в зелёном шарфе перевернула всё её представление о времени.","Глобальное потепление удалось остановить с помощью гигантских вентиляторов, работающих на энергии смеха.",
		"Последний поезд в никуда отправлялся с платформы номер три ровно в полночь.","Улицы этого города были вымощены не булыжником, а страницами из старых романов.","Он понял, что пора менять жизнь, когда его кактус зацвёл оранжевыми гвоздиками.",
		"В библиотеке можно взять не только книгу, но и чей-нибудь сон на одну ночь.","Фотограф специализировался на съёмке теней, ушедших от своих хозяев.","В реке вместо рыбы плавали серебряные ложки с загадочными гравировками.",
		"Дверь в подвал была заперта на семь висячих замков, каждый из которых молчал на своём языке.","Иногда лучший совет – это свежеиспечённый хлеб и банка домашнего варенья.",
		"Все часы в мире однажды решили пойти вспять, просто чтобы посмотреть, что из этого выйдет.","Она писала письма не чернилами, а ароматом жасмина и вкусом спелой черешни.",
		"На Марсе нашли заброшенную оранжерею, где росли синие кактусы, поющие под лунный свет.","Его храбрость сбежала от него вчера вечером, захватив с собой зонтик и пару носков.",
		"Завтрак должен состоять из омлета, тостов и одной небольшой, но важной тайны.","Почтальон принёс конверт, от которого пахло океаном и далёкими портами.",
		"В полночь все памятники в городе тихо сползают со своих постаментов и играют в прятки.","Её смех был похож на звук разбивающегося хрусталя, смешанного с колокольчиком.",
		"Он выращивал на подоконнике не растения, а миниатюрные разноцветные молнии.","Картина в музее менялась каждый раз, когда в зал заходил кто-то одинокий.",
		"В лесу за домом тропинка, вымощенная изумрудными мхами, вела к дому самого Времени.","Кот учёного разработал теорию относительности, удобную для дневного сна.","Ветер сегодня принёс с собой обрывки чужих разговоров и запах жареных каштанов.",
		"Он носил с собой чемодан, полный забытых мелодий, и раздавал их прохожим.","Луна в эту ночь была не круглая, а в форме идеального куба.","Снег шёл только над её домом, и это было самое красивое и грустное явление в городе."

		};




		string randomSentences = sentences[random.Next(sentences.Length)];

		Console.Clear();
		System.Threading.Thread.Sleep(1000); //пауза на 1 секунду
		Console.WriteLine("1!");
		System.Threading.Thread.Sleep(1000); //снова пауза на 1 секунду
		Console.WriteLine("2!!");
		System.Threading.Thread.Sleep(1000); //последний цикл паузы на 1 секунду
		Console.WriteLine("3!!!");
		Console.Clear();
		bool EndGame = false;
		while (!EndGame)
		{

			Console.WriteLine("Игра началась!");
			Console.WriteLine("Твоё предложение:")
				;
			System.Threading.Thread.Sleep(500);
			Console.WriteLine("Генерируется.");

			System.Threading.Thread.Sleep(500);
			Console.WriteLine("Генерируется..");

			System.Threading.Thread.Sleep(500);
			Console.WriteLine("Генерируется...");

			System.Threading.Thread.Sleep(500);
			Console.WriteLine("Генерируется.");

			System.Threading.Thread.Sleep(500);
			Console.WriteLine("Генерируется..");

			System.Threading.Thread.Sleep(500);
			Console.WriteLine("Генерируется...");

			System.Threading.Thread.Sleep(500);
			Console.WriteLine("Успешно сгенерировано!");
			int sec = 10;

			System.Threading.Thread.Sleep(500);
			while (sec > 0)
			{
				Console.Clear();
				Console.WriteLine($"{randomSentences}\nОсталось {sec} секунд... Запоминай!");

				System.Threading.Thread.Sleep(1000);

				sec--;

			}

			Console.Clear();
			int countLetters = randomSentences.Length;
			char sentenceForPlayer = '*';
			string resultSentenceForPlayer = string.Concat(Enumerable.Repeat(sentenceForPlayer, countLetters));

			Console.WriteLine($"Время писать!\nСкрытое предложение: {resultSentenceForPlayer}");
			Console.Write("Предложение: ");

			string playerSintance = Console.ReadLine();




			if (playerSintance == randomSentences)
			{

				Victory(nickName, randomSentences, playerSintance);
			}
			else
			{

				GameOver(nickName, randomSentences, playerSintance);
			}
		}


	}
	static void Victory(string nickName, string randomSentences, string playerSintance)
	{
		Console.Clear();
		bool retry = false;
		while (!retry)
		{
			Console.WriteLine($"{nickName}, Я тебя поздравляю ты победил в этой игре!");
			Console.WriteLine($"Настоящее предложение: {randomSentences}");
			Console.WriteLine($"Твоё предложение: {playerSintance}");
			Console.WriteLine("1. Играть снова");
			Console.WriteLine("2. Выйти в меню");
			Console.Write("Выберите: ");

			string choice = Console.ReadLine();
			switch (choice)
			{
				case "1":
					Game(nickName);
					break;
				case "2":
					GameMenu(nickName);
					break;
				default:
					Console.WriteLine("Неправильный выбор!");
					Console.ReadKey();
					break;
			}
		}
	}
	static void GameOver(string nickName, string randomSentences, string playerSintance)
	{
		Console.Clear();
		bool retry1 = false;
		while (!retry1)
		{
			Console.WriteLine($"{nickName}, Игра окончена!");
			Console.WriteLine($"Правильное предложение: {randomSentences}");
			Console.WriteLine($"Твоё предложение: {playerSintance}");
			Console.WriteLine("1. Играть снова");
			Console.WriteLine("2. Выйти в меню");
			Console.Write("Выберите: ");

			string choice = Console.ReadLine();
			switch (choice)
			{
				case "1":
					Game(nickName);
					break;
				case "2":
					GameMenu(nickName);
					break;
				default:
					Console.WriteLine("Неправильный выбор!");
					Console.ReadKey();
					break;
			}

		}

	}

}
