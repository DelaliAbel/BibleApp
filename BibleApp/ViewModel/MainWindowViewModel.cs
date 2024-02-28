using BibleApp.BaseNotifyProperty;
using BibleApp.Command;
using BibleApp.Lookup;
using BibleApp.Models;
using BibleApp.Views;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BibleApp.ViewModel
{
    internal class MainWindowViewModel : BaseOnPropertyChanged
	{
        #region Fields
        private ObservableCollection<CommandViewModel> _menuBarNavigation;
        private ObservableCollection<CommandViewModel> _windowStateButton;
        private ObservableCollection<CommandViewModel> _studentNavControl;
        UserControl _workPanel;
        private BibleView _bibleView  = new BibleView();
        private HomeView _homeView = new HomeView();
        private PlanView _planView = new PlanView();
        private GrecHebreuxView _grecHebreuxView = new GrecHebreuxView();
        private AudioView _audioView = new AudioView();
        private SettingView _settingView = new SettingView();
        private string _windowState;
        private string _downloadLink;
        private string _downloadAppLink;
        private string _infoAboutUpdate;
		ICommand _closeInfoCommand;
		ICommand _closeAboutCommand;
		ICommand _openAboutCommand;
		ICommand _checkCommand;
		ICommand _downloadNewVersionCommand;
        Visibility _isAboutVisible = Visibility.Collapsed;
        Visibility _isInfos = Visibility.Collapsed;
        Visibility _isLoading = Visibility.Collapsed;
        Visibility _isNotLoading = Visibility.Visible;

		#endregion

		#region Properties
		[DllImport("wininet.dll")]
		private extern static bool InternetGetConnectedState(out int description, int reservedValue);

		public string InfoAboutUpdate
		{
			get { return _infoAboutUpdate; }
			private set
			{
				_infoAboutUpdate = value;
				OnPropertyChanged();
			}
		}
		public string DownloadLink
		{
			get { return _downloadLink; }
			private set
			{
				_downloadLink = value;
				OnPropertyChanged();
			}
		}

		public string DownloadAppLink
		{
			get { return _downloadAppLink; }
			private set
			{
				_downloadAppLink = value;
				OnPropertyChanged();
			}
		}

		public ObservableCollection<CommandViewModel> MenuBarNavigation
        {
            get {
                if (_menuBarNavigation == null)
                {
                    _menuBarNavigation = new ObservableCollection<CommandViewModel>()
                    {
                        ////Dashboard
                        //new CommandViewModel
                        //{
                        //    DisplayName = "Accueil",
                        //    Icon = IconData.DashboardIcon,
                        //    Command = new RelayCommand(param => LoadView("home")),
                        //    IsChecked = false
                        //},
                        //Lire la Bible
                        new CommandViewModel
                        {
                            DisplayName = "Lire la Bible",
                            Icon = IconData.SymbolIcon,
                            Command = new RelayCommand(param => LoadView("bible")),
                            IsChecked = true
                        },
                        //Audio
                        //new CommandViewModel
                        //{
                        //    DisplayName = "Ecouter la Bible",
                        //    Icon = IconData.AudioIcon,
                        //    Command = new RelayCommand(param => LoadView("audio")),
                        //    IsChecked = false
                        //},
                        ////Strong Grec
                        //new CommandViewModel
                        //{
                        //    DisplayName = "Strong Grec et Hébreu",
                        //    Icon = IconData.BookIcon,
                        //    Command = new RelayCommand(param => LoadView("strong")),
                        //    IsChecked = false
                        //},
                        //////Verset du Jour
                        //new CommandViewModel
                        //{
                        //    DisplayName = "Verset du jour",
                        //    Icon = IconData.NotifIcon,
                        //    Command = new RelayCommand(param => LoadView("verset")),
                        //    IsChecked = false
                        //},
                        //////Parametre
                        //new CommandViewModel
                        //{
                        //    DisplayName = "Parametre",
                        //    Icon = IconData.SettingIcon,
                        //    Command = new RelayCommand(param => LoadView("setting")),
                        //    IsChecked = false
                        //},
                    };
                }

                return _menuBarNavigation; 
            }
            private set { }
        }
        public UserControl WorkPanel {
            get { return _workPanel; }
            private set
            {
                _workPanel = value;
                OnPropertyChanged("WorkPanel");
            }
        }

        public Visibility IsAboutVisible
		{
            get { if(_isAboutVisible == null)
                {
                    _isAboutVisible = Visibility.Collapsed;
                }
                return _isAboutVisible; }
            private set
            {
				_isAboutVisible = value;
                OnPropertyChanged();
            }
        }
        public Visibility IsInfos
		{
            get { if(_isInfos == null)
                {
					_isInfos = Visibility.Collapsed;
                }
                return _isInfos; }
            private set
            {
				_isInfos = value;
                OnPropertyChanged();
            }
        }
        public Visibility IsLoading
		{
            get { if(_isLoading == null)
                {
					_isLoading = Visibility.Collapsed;
                }
                return _isLoading; }
            private set
            {
				_isLoading = value;
                OnPropertyChanged();
            }
        }
        public Visibility IsNotLoading
		{
            get { if(_isNotLoading == null)
                {
					_isNotLoading = Visibility.Visible;
                }
                return _isNotLoading; }
            private set
            {
				_isNotLoading = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<CommandViewModel> WindowStateButtons
        {
            get {
                if (_windowStateButton == null)
                {
                    _windowStateButton = new ObservableCollection<CommandViewModel>()
                    {
                        //Minimize
                        new CommandViewModel
                        {
                            DisplayName = "Minimize",
                            Icon = IconData.DashboardIcon,
                            Command = new RelayCommand(param => WindowStateAction("Minimize")),
                            IsChecked = true
                        },
                        //Maximize
                        new CommandViewModel
                        {
                            DisplayName = "Maximize",
                            Icon = IconData.SymbolIcon,
                            Command = new RelayCommand(param => WindowStateAction("Maximize")),
                            IsChecked = false
                        },
                        //Close
                        new CommandViewModel
                        {
                            DisplayName = "Close",
                            Icon = IconData.AudioIcon,
                            Command = new RelayCommand(param => WindowStateAction("Close")),
                            IsChecked = false
                        },
                    };
                }
                return _windowStateButton; 
            }
            set { _windowStateButton = value;}
        }
        public string WindowState
        {
            get { return _windowState; }
            set { _windowState = value;
                OnPropertyChanged("WindowState");
            }
        }
		#endregion

		#region Command
		public ICommand CloseAboutCommand
		{
			get
			{
				if (_closeInfoCommand == null)
					_closeInfoCommand = new RelayCommand(doexe => ChangeAboutViewState(Visibility.Collapsed));
				return _closeInfoCommand;
			}
		}
		public ICommand CloseInfoCommand
		{
			get
			{
				if (_closeAboutCommand == null)
					_closeAboutCommand = new RelayCommand(doexe => ChangeInfoViewState(Visibility.Collapsed));
				return _closeAboutCommand;
			}
		}
		public ICommand DownloadNewVersionCommand
		{
			get
			{
				if (_downloadNewVersionCommand == null)
					_downloadNewVersionCommand = new RelayCommand(doexe => DownloadNewVersion());
				return _downloadNewVersionCommand;
			}
		}
		public ICommand CheckCommand
		{
			get
			{
                if (_checkCommand == null)
					_checkCommand = new RelayCommand(doexe => {
						IsLoading = Visibility.Visible;
						IsNotLoading = Visibility.Collapsed;
						CheckUpdate(); 
					});
				return _checkCommand;
			}
		}
		public ICommand OpenAboutCommand
		{
			get
			{
				if (_openAboutCommand == null)
					_openAboutCommand = new RelayCommand(doexe => ChangeAboutViewState(Visibility.Visible));
				return _openAboutCommand;
			}
		}
		#endregion

		#region Construtor
		public MainWindowViewModel()
        {
            WorkPanel = _bibleView;
			CheckUpdate();
		}
		#endregion

		#region Methodes

		public async Task GetLink()
		{
            //Recuperation du lien
            string html;

			using (HttpClient client = new HttpClient())
            {
				string i_link = "https://github.com/DelaliAbel/BibleApp/releases/tag/doc";
				html = await client.GetStringAsync(i_link);
			}

			HtmlDocument docHtml = new HtmlDocument();
			docHtml.LoadHtml(html);

			foreach (var link in docHtml.DocumentNode.SelectNodes("//a[@href]")) //" //ul[@class='nostyle']
			{
				string href = link.Attributes["href"].Value.ToString();

                if(href.Contains("InfoUpdate"))
                {
                    DownloadLink = href;
                }
			}
		}

		public static bool IsInternetAvailable()
		{
			int description;
			return InternetGetConnectedState(out description, 0);
		}

		public async Task CheckUpdate()
		{
            if(IsInternetAvailable())
            {
                try
                {
                    await GetLink();

                    if(DownloadLink != null)
                    {
						string url = DownloadLink;

						using (HttpClient client = new HttpClient())
						{
							string contenu = await client.GetStringAsync(url);
							Update appVersion = new Update();

							appVersion = JsonConvert.DeserializeObject<Update>(contenu);

							if (appVersion.Version != StringData.Version)
							{
								InfoAboutUpdate = appVersion.Infos;
								DownloadAppLink = appVersion.DownloadAppLink;
								IsInfos = Visibility.Visible;
							}
							else
							{
                                //Le message ne se déclenche que lorsque c'est depuis la fenetre About sur clique du bouton
								if (IsAboutVisible == Visibility.Visible)
									MessageBox.Show("Votre version est déja à jour !");
							}
						}

						IsNotLoading = Visibility.Visible;
						IsLoading = Visibility.Collapsed;
						IsAboutVisible = Visibility.Collapsed;
					}
				}
				catch (Exception e)
                {
                    MessageBox.Show(e.Message);
					IsNotLoading = Visibility.Visible;
					IsLoading = Visibility.Collapsed;

				}
			}
            else
            {
                //N'affichier le message que si l'utilisateur à cliquer depuis la fenetre About ouverte
                if(IsAboutVisible == Visibility.Visible)
                {
					IsNotLoading = Visibility.Visible;
					IsLoading = Visibility.Collapsed;
					MessageBox.Show("Pas d'accès à internet !");
				}
			}
		}

		private void LoadView(string i_userControl)
        {
            switch(i_userControl)
            {
                case "home":
                    WorkPanel = _homeView;
                    break;
                case "bible":
                    WorkPanel = _bibleView;
                    break;
                case "strong":
                    WorkPanel = _grecHebreuxView;
                    break;
                case "audio":
                    WorkPanel = _audioView;
                    break;
                case "verset":
                    WorkPanel = _planView;
                    break;
                case "setting":
                    WorkPanel = _settingView;
                    break;
            }
        }

        private async void DownloadNewVersion()
        {
            try
            {
                IsInfos = Visibility.Collapsed;
				using (var client = new WebClient())
				{
					await client.DownloadFileTaskAsync(DownloadAppLink, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Downloadfile.txt"));
				}

                MessageBox.Show("Téléchargement réussi avec succès !\n Dans le dossier : " + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
			}
			catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
		}


		private void WindowStateAction(string i_state)
        {
            WindowState = i_state;
        }

        public void ChangeAboutViewState(Visibility state)
        {
            IsAboutVisible = state;
        }

        public void ChangeInfoViewState(Visibility state)
        {
			IsInfos = state;
        }
		#endregion
	}
}
