using System;
using System.Runtime.CompilerServices;

namespace PatternFactoryMethod
{
	class Program
	{
		static void Main(string[] args)
		{
			BaseUser TestAdmin = new Admin("Alex","Android");
			Speech TestSpeech = TestAdmin.Create();

			BaseUser TestUser = new User("Android");
			Speech TestSpeech2 = TestUser.Create();
		}
	}

	// База класс Доклад
	abstract class Speech
	{}

	// Доклад с темой
	class SpeechWithAuthor: Speech
	{
		private readonly String Author;
		private readonly String Theme;
		public SpeechWithAuthor(String a, String t)
		{
			this.Author = a;
			this.Theme = t;
			Console.WriteLine($"This Speech has Author {Author} \n Theme is {Theme}");
		}
	}
	
	// Доклад без темы
	class SpeechNoAuthor: Speech
	{
		private readonly String Author;
		private readonly String Theme;
		public SpeechNoAuthor(String t)
		{
			this.Theme = t;
			Console.WriteLine($"This Speech doesn't have any Author \n Theme is {Theme}");
		}
	}

	// База класс Пользователь
	abstract class BaseUser
	{
		
		public BaseUser ()
		{
			
		}
		abstract public Speech Create();
	}

	class User : BaseUser
	{
		private String Theme;
		public User(String theme)
		{ 
			this.Theme = theme; 
		}
		

		public override Speech Create()
		{
			return new SpeechNoAuthor(Theme);
		}

	}

	class Admin : BaseUser
	{
		private String Theme;
		private String Name;
		public Admin (String n, String theme)
		{
			this.Theme = theme;
			this.Name = n;
		}

		public override Speech Create()
		{
			return new SpeechWithAuthor(Name, Theme);
		}
	}
}
