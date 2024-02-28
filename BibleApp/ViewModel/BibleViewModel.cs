using BibleApp.BaseNotifyProperty;
using BibleApp.Command;
using BibleApp.Lookup;
using BibleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace BibleApp.ViewModel
{
    public class BibleViewModel : BaseViewModel
	{
		#region Fields
		public string _selectedBible;
		public string _selectedTestament;
		public string _selectedBook;
		public int _selectedChapter;
		public string _selectedVerse;
		string _chapterMaxNumber;
		public string _chapterContent;
		ICommand _addChapter;
		ICommand _lessChapter;

		#endregion

		#region Property

		public string Title { get; set; } = "";
		public ObservableCollection<CommandViewModel> ListOfBooks { get; set; } = new ObservableCollection<CommandViewModel>();
		public ObservableCollection<CommandViewModel> Testaments { get; set; } = new ObservableCollection<CommandViewModel>();
		public ObservableCollection<string> ListBookChapters { get; set; } = new ObservableCollection<string>();
		public ObservableCollection<string> ListTestaments { get; set; } = new ObservableCollection<string>();
		public Bible BibleData { get; set; }
		FlowDocumentReader _pageContent;
		FlowDocument _flowDocument;

		public string SelectedTestament
		{
			get { 
					if(string.IsNullOrEmpty(_selectedTestament))
					{
						return _selectedTestament = "Ancien Testament";
					}

					return _selectedTestament; 
			}
			set { _selectedTestament = value; OnPropertyChanged(); }
		}
		public string SelectedBook
		{
			get {
				if (string.IsNullOrEmpty(_selectedBook))
				{
					return _selectedBook = "Genèse";
				}
				return _selectedBook; 
			}
			set { _selectedBook = value; OnPropertyChanged(); }
		}
		public int SelectedChapter
		{
			get 
			{
				if (_selectedChapter == 0 || _selectedChapter == null)
				{
					return _selectedChapter = 1;
				}

				return _selectedChapter; 
			}

			set { 
				_selectedChapter = value;
				OnPropertyChanged();
				LoadChapter();
			}
		}
		public string SelectedVerse
		{
			get {
				if (string.IsNullOrEmpty(_selectedVerse))
				{
					return _selectedVerse = "1";
				}
				return _selectedVerse; }
			set { _selectedVerse = value; OnPropertyChanged(); }
		}

		public string ChapterContent
		{
			get {
				if (string.IsNullOrEmpty(_chapterContent))
				{
					return _chapterContent = "Contenu Vide";
				}
				return _chapterContent; }
			set { _chapterContent = value; OnPropertyChanged(); }
		}

		public FlowDocumentReader PageContent
		{
			get { 
				if (_pageContent == null)
				{
					_pageContent = new FlowDocumentReader();
					_pageContent.ViewingMode = FlowDocumentReaderViewingMode.Scroll;
				}

				return _pageContent; 
			}
			set { _pageContent = value; OnPropertyChanged(); }
		}

		#endregion

		#region Constructor
		public BibleViewModel()
		{
			//string jsonData2 = AppDomain.CurrentDomain.BaseDirectory + "Lookup\\BibleLS.json";

			// Get the base directory of the application
			string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

			// Navigate to the "Lookup" folder relative to the base directory
			string lookupFolderPath = Path.Combine(baseDirectory, "..", "..","..", "Lookup");

			// Combine the path to the data.json file
			string bibleFullPath = Path.Combine(lookupFolderPath, "BibleLSFull3.json");

			//string path = @"C:\Users\lenovo\Documents\Own\BibleFull.json"; // Your JSON data here
			//string BibleData = File.ReadAllText(path);

			//Dictionary<string, Bible> BibleData = new Dictionary<string, Bible>();
			BibleData = new Bible();

			// Deserialize JSON data
			//BibleData = JsonConvert.DeserializeObject<Dictionary<string, Bible>>(jsonData);

			// Créez un lecteur JSON à partir du fichier
			using (StreamReader file = File.OpenText(bibleFullPath))
			{
				// Créez un désérialiseur JSON
				JsonSerializer serializer = new JsonSerializer();

				// Utilisez JsonTextReader pour lire les données JSON à partir du fichier
				using (JsonTextReader reader = new JsonTextReader(file))
				{
					// Désérialisez les données en utilisant le lecteur JSON
					//BibleData BibleData = serializer.Deserialize<BibleData>(reader);
					BibleData = serializer.Deserialize<Bible>(reader);
					InitData();
				}
			}
		}
		#endregion

		#region Commands

		public ICommand AddChapterCommand
		{
			get
			{
				if (_addChapter == null)
				_addChapter = new RelayCommand(doexe => ChangedChapterNumber("Add"));
		     	return _addChapter;
			}
		}

		public ICommand LessChapterCommand
		{
			get
			{
				if (_lessChapter == null)
				_lessChapter = new RelayCommand(doexe => ChangedChapterNumber("Less"));
		     	return _lessChapter;
			}
		}

		//public RelayCommand clientnavcommand
		//{
		//	get
		//	{
		//		if (_clientnavcommand == null)
		//			_clientnavcommand = new relaycommand(doexe => { activeusercontrol = clientv; });
		//		return _clientnavcommand;
		//	}
		//	set { _clientnavcommand = value; onpropertychanged(); }
		//}
		#endregion

		#region Methods
		public void InitData()
		{
			// Example: Request data for "_numeroChapitre=2" and "NumeroVerset=1" from the first translation (Louis Segond)

			// Find the translation
			var translation = BibleData.Traduction;

			if (translation != null)
			{
				// Find the book
				var books = BibleData.ContenuBible.FirstOrDefault(c => c.Titre == SelectedTestament).Livres.ToList();

				//Get Testaments from DeserializedData
				var localTestaments = BibleData.ContenuBible;

				//Load Testement Books and commands
				foreach (var item in localTestaments)
				{
					var itemTestament = new CommandViewModel
					{
						DisplayName = item.Titre,
						Icon = null,
						Command = new RelayCommand(param => LoadTestamentBooks(item.Titre)),
						IsChecked = (item.Titre == "Ancien Testament") ? true : false,
					};

					Testaments.Add(itemTestament);
				}

				//Get book chapter Numbers
				var chapters = BibleData.ContenuBible.FirstOrDefault(c => c.Titre == SelectedTestament).Livres.FirstOrDefault(liv => liv.NomLivre == SelectedBook).ContenuChapitre;
				foreach (var item in chapters)
				{
					ListBookChapters.Add(item.NumeroChapitre.ToString());
				}

				//Get All books chapter Number for the Menu
				foreach (var item in books)
				{
					var itemBookMenu = new CommandViewModel
					{
						DisplayName = item.NomLivre,
						Icon = null,
						Command = new RelayCommand(param => ChangedBook(item.NomLivre)),
						IsChecked = (item.NomLivre == SelectedBook) ? true : false,
					};

					ListOfBooks.Add(itemBookMenu);
				}

				LoadChapter();
			}
		}

		public void ChangedBook(string i_bookName)
		{
			SelectedBook = i_bookName;

			var books = BibleData.ContenuBible.FirstOrDefault(c => c.Titre == SelectedTestament).Livres.ToList();

			//Get book chapter Numbers
			var chapters = BibleData.ContenuBible.FirstOrDefault(c => c.Titre == SelectedTestament).Livres.FirstOrDefault(liv => liv.NomLivre == SelectedBook).ContenuChapitre;
			
			ListBookChapters.Clear();
			foreach (var item in chapters)
			{
				ListBookChapters.Add(item.NumeroChapitre.ToString());
			}

			SelectedChapter = 1;
			LoadChapter();
		}

		public void LoadChapter()
		{
			var book = BibleData.ContenuBible.FirstOrDefault(c => c.Titre == SelectedTestament).Livres.FirstOrDefault(liv => liv.NomLivre == SelectedBook).ContenuChapitre.FirstOrDefault(ch => ch.NumeroChapitre == SelectedChapter.ToString());
			if (book != null)
			{
				//Chapter content
				string BibleWords = "";

				// Create a FlowDocument
				_flowDocument = new FlowDocument();

				foreach (var item in book.ContenuVersets)
				{
					//BibleWords = BibleWords + "[" + item.NumeroVerset + "]" + item.Verset.Replace("\r\n", "");
					var verset = "[" + item.NumeroVerset + "]" + item.Verset.Replace("\r\n", "");
					CheckJesusWords(verset);
				}
				//_flowDocument.PagePadding = new Thickness(0);
				//Sent to the View
				_flowDocument.FontFamily = new FontFamily("Arial");
				PageContent.Document = _flowDocument;

				//ChapterContent = BibleWords;

				// Find the verse
				//var verse = book.ContenuVersets.FirstOrDefault(v => v.NumeroVerset.ToString() == SelectedVerse);

			}

		}

		public void ChangedChapterNumber(string i_action)
		{
			if(i_action == "Add")
			{
				if(ListBookChapters.Select(int.Parse).Max() > SelectedChapter)
				SelectedChapter++;
			}
			else
			{
				if(SelectedChapter >= 1) 
				{
					SelectedChapter--;
				}
			}
		}

		public void LoadTestamentBooks(string i_testament)
		{
			if (i_testament == "Ancien Testament")
			{
				SelectedBook = "Genèse";
			}
			else
			{
				SelectedBook = "Matthieu";
			}

			SelectedTestament = i_testament;

			var books = BibleData.ContenuBible.FirstOrDefault(c => c.Titre == SelectedTestament).Livres.ToList();

			//Get book chapter Numbers
			ListBookChapters.Clear();
			var chapters = BibleData.ContenuBible.FirstOrDefault(c => c.Titre == SelectedTestament).Livres.FirstOrDefault(liv => liv.NomLivre == SelectedBook).ContenuChapitre;
			foreach (var item in chapters)
			{
				ListBookChapters.Add(item.NumeroChapitre.ToString());
			}

			//Get All books chapter Number for the Menu
			ListOfBooks.Clear();
			foreach (var item in books)
			{				
				var itemBookMenu = new CommandViewModel
				{
					DisplayName = item.NomLivre,
					Icon = null,
					Command = new RelayCommand(param => ChangedBook(item.NomLivre)),
					IsChecked = (item.NomLivre==SelectedBook)? true : false,
				};

				ListOfBooks.Add(itemBookMenu);
			}
			LoadChapter();
		}


		//IL FAUT AJOUTER DANS LE FICHEIR JSON LES BALISES DE LA PPAROLE DE JESUS AU NIVEAU
		//DES CHAPITRES SUIVANTS : 1 à 4, 16 et 22
		public void CheckJesusWords(string i_verset)
		{
			string[] parts = i_verset.Split(new string[] { "#", "#" }, StringSplitOptions.None);
			Paragraph paragraph = new Paragraph();
			foreach (string part in parts)
			{
				Run run;
				Span span = new Span();
				string verse = part;

				//Verifie Jesus words
				if (verse.Contains("</j>"))
				{
					// Supprimer les balises de <j>
					string Jword = verse.Replace("<j>", "").Replace("</j>", "");

					//Mettre le text en rouge
					run = new Run(Jword);
					run.Foreground = Brushes.Red;
				}
				else
				{
					run = new Run(verse);
					run.Foreground = new SolidColorBrush(Color.FromRgb(83, 83, 83));
				}

				// Ajout dans le paragraph
				paragraph.Inlines.Add(run);
			}
			//Suppression des margins
			paragraph.Margin = new Thickness(0);

			// Add the Paragraph to the FlowDocument
			_flowDocument.Blocks.Add(paragraph);

		}

		#endregion
	}
}
