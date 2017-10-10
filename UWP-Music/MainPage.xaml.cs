using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWP_Music.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace UWP_Music
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private const double MINI_MENU_WIDTH = 48;
        private const double MAX_MENU_WIDTH = 190;

        private ObservableCollection<MenuItem> menuItems;
        private ObservableCollection<MenuItem> musicItems;
        private ObservableCollection<MenuItem> myFavItems;
        private ObservableCollection<MenuItem> favItems;

        public MainPage()
        {
            this.InitializeComponent();
            Init();
        }

        private void Init()
        {
            InitTitleBar();
            InitMenu();
            InitMusic();
            InitMyFav();
            InitFav();
        }

        private void InitTitleBar()
        {
            var appTitleBar = ApplicationView.GetForCurrentView().TitleBar;
            appTitleBar.BackgroundColor = CustomColors.TitleBackGroundColor;
            appTitleBar.ButtonBackgroundColor = CustomColors.TitleBackGroundColor;

            appTitleBar.InactiveBackgroundColor = CustomColors.TitleInactiveColor;
            appTitleBar.ButtonInactiveBackgroundColor = CustomColors.TitleInactiveColor;
            appTitleBar.InactiveForegroundColor = Colors.White;
            appTitleBar.ButtonInactiveForegroundColor = Colors.White;

            appTitleBar.ButtonHoverBackgroundColor = CustomColors.TitleHoverBackgroundColor;
            appTitleBar.ButtonHoverForegroundColor = Colors.White;

            appTitleBar.ButtonPressedBackgroundColor = CustomColors.TitlePressedBackgroundColor;
            appTitleBar.ButtonPressedForegroundColor = Colors.White;
        }

        private void InitMenu()
        {
            menuItems = new ObservableCollection<MenuItem>()
            {
                new MenuItem() { Icon=Symbol.Find,Text="搜索"},
                new MenuItem() { Icon=Symbol.MusicInfo,Text="发现音乐",Selected = Visibility.Visible},
                new MenuItem() { Icon=Symbol.Play,Text="MV"},
                new MenuItem() { Icon=Symbol.People,Text="朋友"},
            };
            MaxMenuListView.ItemsSource = menuItems;
            MaxMenuListView.SelectedIndex = 1;
            MinMenuListView.ItemsSource = menuItems;
            MinMenuListView.SelectedIndex = 1;
        }

        private void InitMusic()
        {
            musicItems = new ObservableCollection<MenuItem>()
            {
                new MenuItem(){Icon = Symbol.Folder,Text="本地音乐"},
                new MenuItem(){Icon = Symbol.Download,Text="下载管理"},
                new MenuItem(){Icon = Symbol.Clock,Text="最近播放"},
                new MenuItem(){Icon = Symbol.Flag,Text="我的音乐云盘"},
                new MenuItem(){Icon = Symbol.Folder,Text="我的收藏"}
            };
            MusicListView.ItemsSource = musicItems;
        }

        private void InitMyFav()
        {
            myFavItems = new ObservableCollection<MenuItem>
            {
                new MenuItem(){Icon = Symbol.Admin,Text="我喜欢的音乐"},
                new MenuItem(){Icon = Symbol.Play,Text="要版权的"},
                new MenuItem(){Icon = Symbol.Play,Text="编码"},
                new MenuItem(){Icon = Symbol.Play,Text="Secret Garden 热门50单曲"}
            };
            MyFavListView.ItemsSource = myFavItems;
        }

        private void InitFav()
        {
            favItems = new ObservableCollection<MenuItem>
            {
                new MenuItem(){Icon = Symbol.Play,Text="50首传世英文金曲"},
                new MenuItem(){Icon = Symbol.Play,Text="【旋律控】超级好听的英文歌"}
            };
            FavListView.ItemsSource = favItems;
        }


        private void MenuBtnClick(object sender, RoutedEventArgs e)
        {
            mainSplitView.CompactPaneLength = mainSplitView.IsPaneOpen ? MINI_MENU_WIDTH : MAX_MENU_WIDTH;
            mainSplitView.IsPaneOpen = !mainSplitView.IsPaneOpen;
            MaxMenu.Visibility = mainSplitView.IsPaneOpen ? Visibility.Visible : Visibility.Collapsed;
            MinMenu.Visibility = mainSplitView.IsPaneOpen ? Visibility.Collapsed : Visibility.Visible;
            MaxUserStackPanel.Visibility = mainSplitView.IsPaneOpen ? Visibility.Visible : Visibility.Collapsed;
            MinUserStackPanel.Visibility = mainSplitView.IsPaneOpen ? Visibility.Collapsed : Visibility.Visible;
        }

        private void MenuListViewItemClick(object sender, ItemClickEventArgs e)
        {
            MaxMenuListView.SelectedIndex = -1;
            MinMenuListView.SelectedIndex = -1;
            MusicListView.SelectedIndex = -1;
            var item = menuItems.FirstOrDefault(t => t.Selected == Visibility.Visible);
            if (item != null)
                item.Selected = Visibility.Collapsed;
            else
            {
                item = musicItems.FirstOrDefault(t => t.Selected == Visibility.Visible);
                if (item != null)
                    item.Selected = Visibility.Collapsed;
            }
            (e.ClickedItem as MenuItem).Selected = Visibility.Visible;
        }

        private void ReMaxBtnClick(object sender, RoutedEventArgs e)
        {
            mainSplitView.CompactPaneLength = MAX_MENU_WIDTH;
            mainSplitView.IsPaneOpen = true;
            MaxMenu.Visibility = mainSplitView.IsPaneOpen ? Visibility.Visible : Visibility.Collapsed;
            MinMenu.Visibility = mainSplitView.IsPaneOpen ? Visibility.Collapsed : Visibility.Visible;
            MaxUserStackPanel.Visibility = mainSplitView.IsPaneOpen ? Visibility.Visible : Visibility.Collapsed;
            MinUserStackPanel.Visibility = mainSplitView.IsPaneOpen ? Visibility.Collapsed : Visibility.Visible;
        }
    }
}
