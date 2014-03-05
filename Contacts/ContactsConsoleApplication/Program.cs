using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Contacts.Core;
using Contacts.Core.Models;
using Contacts.Core.Services;

namespace ContactsConsoleApplication
{
	class Program
	{

		static void Main(string[] args)
		{
			//programNomeSobrenome();
			//programTestArray();
			//programCreateObjectContact();
			ContactsService ContactsServiceInstance = ContactsService.Instance;
			Console.ReadKey();
			ContactsServiceInstance.PrintListToConsole();
			Console.ReadKey();
		}

		private static void programNomeSobrenome()
		{
			Console.WriteLine("Teste Contatos Console");
			String nome;
			String sobrenome;
			Console.Write("Nome: ");
			nome = Console.ReadLine();
			Console.Write("Sobrenome: ");
			sobrenome = Console.ReadLine();

			Console.WriteLine();
			Console.WriteLine(nome + " " + sobrenome);
			Console.WriteLine("{0} {1}", nome, sobrenome);
		}

		private static void programTestArray()
		{
			string[] nomes = {"Renan", "Veloso"};
			var list = nomes.ToList();
			list.Add("Silva");
			nomes = list.ToArray();

			Console.WriteLine("Quantidade de nomes: {0}", nomes.Count().ToString());

			foreach (string n in nomes) {
				Console.WriteLine("Nome {0} é {1}", Array.IndexOf(nomes, n), n);
			}
		}

		private static void programCreateObjectContact()
		{
			var contato = new ContactsModel();
			contato.FirstName = "Renan";
			contato.LastName = "Silva";
		}
	}
}
