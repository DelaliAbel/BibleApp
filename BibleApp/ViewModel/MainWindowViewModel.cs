using BibleApp.Command;
using BibleApp.Lookup;
using BibleApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BibleApp.ViewModel
{
    internal class MainWindowViewModel : INotifyObject
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
        #endregion

        #region Properties
        public ObservableCollection<CommandViewModel> MenuBarNavigation
        {
            get {
                if (_menuBarNavigation == null)
                {
                    _menuBarNavigation = new ObservableCollection<CommandViewModel>()
                    {
                        //Dashboard
                        new CommandViewModel
                        {
                            DisplayName = "Accueil",
                            Icon = IconData.DashboardIcon,
                            Command = new RelayCommand(param => LoadView("home")),
                            IsChecked = true
                        },
                        //Lire la Bible
                        new CommandViewModel
                        {
                            DisplayName = "Lire la Bible",
                            Icon = IconData.SymbolIcon,
                            Command = new RelayCommand(param => LoadView("bible")),
                            IsChecked = false
                        },
                        //Audio
                        new CommandViewModel
                        {
                            DisplayName = "Ecouter la Bible",
                            Icon = IconData.AudioIcon,
                            Command = new RelayCommand(param => LoadView("audio")),
                            IsChecked = false
                        },
                        //Strong Grec
                        new CommandViewModel
                        {
                            DisplayName = "Strong Grec et Hébreu",
                            Icon = IconData.BookIcon,
                            Command = new RelayCommand(param => LoadView("strong")),
                            IsChecked = false
                        },
                        ////Verset du Jour
                        new CommandViewModel
                        {
                            DisplayName = "Verset du jour",
                            Icon = IconData.NotifIcon,
                            Command = new RelayCommand(param => LoadView("verset")),
                            IsChecked = false
                        },
                        ////Parametre
                        new CommandViewModel
                        {
                            DisplayName = "Parametre",
                            Icon = IconData.SettingIcon,
                            Command = new RelayCommand(param => LoadView("setting")),
                            IsChecked = false
                        },
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

        #region Construtor
        public MainWindowViewModel()
        {
            WorkPanel = _homeView;
        }
        #endregion

        #region Methodes
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

        private void WindowStateAction(string i_state)
        {
            WindowState = i_state;
        }
        #endregion
    }
}
