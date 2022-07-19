﻿using BibleApp.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibleApp.ViewModel
{
    internal class MainWindowViewModel
    {
        #region Fields
        private ObservableCollection<CommandViewModel> _menuBarNavigation;
        private ObservableCollection<CommandViewModel> _windowStateButton;
        private ObservableCollection<CommandViewModel> _studentNavControl;
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
                            DisplayName = "Lire la Bible",
                            Icon = "M32.51,27.83A14.4,14.4,0,0,1,30,24.9a12.63,12.63,0,0,1-1.35-4.81V15.15A10.81,10.81,0,0,0,19.21,4.4V3.11a1.33,1.33,0,1,0-2.67,0V4.42A10.81,10.81,0,0,0,7.21,15.15v4.94A12.63,12.63,0,0,1,5.86,24.9a14.4,14.4,0,0,1-2.47,2.93,1,1,0,0,0-.34.75v1.36a1,1,0,0,0,1,1h27.8a1,1,0,0,0,1-1V28.58A1,1,0,0,0,32.51,27.83ZM5.13,28.94a16.17,16.17,0,0,0,2.44-3,14.24,14.24,0,0,0,1.65-5.85V15.15a8.74,8.74,0,1,1,17.47,0v4.94a14.24,14.24,0,0,0,1.65,5.85,16.17,16.17,0,0,0,2.44,3Z M18,34.28A2.67,2.67,0,0,0,20.58,32H15.32A2.67,2.67,0,0,0,18,34.28Z",
                            Command = new RelayCommand(param => TestMethode()),
                            IsChecked = true
                        },
                        //Student
                        new CommandViewModel
                        {
                            DisplayName = "Ecouter la Bible",
                            Icon = "M32.51,27.83A14.4,14.4,0,0,1,30,24.9a12.63,12.63,0,0,1-1.35-4.81V15.15A10.81,10.81,0,0,0,19.21,4.4V3.11a1.33,1.33,0,1,0-2.67,0V4.42A10.81,10.81,0,0,0,7.21,15.15v4.94A12.63,12.63,0,0,1,5.86,24.9a14.4,14.4,0,0,1-2.47,2.93,1,1,0,0,0-.34.75v1.36a1,1,0,0,0,1,1h27.8a1,1,0,0,0,1-1V28.58A1,1,0,0,0,32.51,27.83ZM5.13,28.94a16.17,16.17,0,0,0,2.44-3,14.24,14.24,0,0,0,1.65-5.85V15.15a8.74,8.74,0,1,1,17.47,0v4.94a14.24,14.24,0,0,0,1.65,5.85,16.17,16.17,0,0,0,2.44,3Z M18,34.28A2.67,2.67,0,0,0,20.58,32H15.32A2.67,2.67,0,0,0,18,34.28Z",
                            Command = new RelayCommand(param => TestMethode()),
                            IsChecked = false
                        },
                        //Teacher
                        //new CommandViewModel
                        //{
                        //    IconData = System.Windows.Media.Geometry.Parse(IconLookup.TeacherIcon),
                        //    DisplayName = StringLookup.TeacherStr,
                        //    Command = new RelayCommand(param => TestMethode()),
                        //    IsCheck = false
                        //},
                        ////Exam
                        //new CommandViewModel
                        //{
                        //    IconData = System.Windows.Media.Geometry.Parse(IconLookup.ExamIcon),
                        //    DisplayName = StringLookup.ExamStr,
                        //    Command = new RelayCommand(param => TestMethode()),
                        //    IsCheck = false
                        //},
                        ////Assiduity
                        //new CommandViewModel
                        //{
                        //    IconData = System.Windows.Media.Geometry.Parse(IconLookup.AssiduityIcon),
                        //    DisplayName = StringLookup.AssiduityStr,
                        //    Command = new RelayCommand(param => TestMethode()),
                        //    IsCheck = false
                        //},
                    };
                }

                return _menuBarNavigation; 
            }
            private set { }
        }
        #endregion

        #region Construtor
        public MainWindowViewModel()
        {

        }
        #endregion

        #region Methodes
        private void TestMethode()
        {
            //SwithView("Dashboard");
        }
        #endregion
    }
}
