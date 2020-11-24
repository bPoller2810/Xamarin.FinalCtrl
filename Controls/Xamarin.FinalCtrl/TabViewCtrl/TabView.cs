using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Xamarin.FinalCtrl.TabViewCtrl
{
    public class TabView : Grid
    {

        #region private member
        private readonly Grid _tabGrid;
        private readonly ContentView _mainView;

        private readonly List<TabItem> _tabs;
        #endregion

        #region Bindable Property

        #region TabPosition
        public static readonly BindableProperty TabPositionProperty =
            BindableProperty.Create(nameof(TabPosition),
                typeof(ETabPosition),
                typeof(TabView),
                propertyChanged: HandleTabPositionChanged);
        public ETabPosition TabPosition
        {
            get => (ETabPosition)GetValue(TabPositionProperty);
            set
            {
                SetValue(TabPositionProperty, value);
                OnPropertyChanged();
            }
        }
        #endregion

        #region ContentTemplateSelector
        public static readonly BindableProperty ContentTemplateSelectorProperty =
            BindableProperty.Create(nameof(ContentTemplateSelector),
                typeof(DataTemplateSelector),
                typeof(TabView));
        public DataTemplateSelector ContentTemplateSelector
        {
            get => (DataTemplateSelector)GetValue(ContentTemplateSelectorProperty);
            set
            {
                SetValue(ContentTemplateSelectorProperty, value);
                OnPropertyChanged();
            }
        }
        #endregion

        #region TabTemplate
        public static readonly BindableProperty TabTemplateProperty =
            BindableProperty.Create(nameof(TabTemplate),
                typeof(DataTemplate),
                typeof(TabView));
        public DataTemplate TabTemplate
        {
            get => (DataTemplate)GetValue(TabTemplateProperty);
            set
            {
                SetValue(SelectedItemProperty, value);
                OnPropertyChanged();
            }
        }

        #endregion

        #region itemssource
        public static readonly BindableProperty ItemssourceProperty =
            BindableProperty.Create(nameof(Itemssource),
                typeof(ICollection),
                typeof(TabView),
                propertyChanged: HandleItemssourceChanged);
        public ICollection Itemssource
        {
            get => (ICollection)GetValue(ItemssourceProperty);
            set
            {
                SetValue(ItemssourceProperty, value);
                OnPropertyChanged();
            }
        }
        #endregion

        #region SelectedItem 
        public static readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create(nameof(SelectedItem),
                typeof(object),
                typeof(TabView),
                BindingMode.TwoWay,
                propertyChanged: HandleSelectedItemChanged);
        public object SelectedItem
        {
            get => GetValue(SelectedItemProperty);
            set
            {
                SetValue(SelectedItemProperty, value);
                OnPropertyChanged();
            }
        }
        #endregion

        #endregion

        #region ctor
        public TabView()
        {
            this.RowSpacing = 0;
            _tabs = new List<TabItem>();

            //create main element instances
            _tabGrid = new Grid
            {
                Margin = 0,
                ColumnSpacing = 0,
            };
            _mainView = new ContentView
            {
                Margin = 0
            };
        }
        #endregion

        #region Tab Position
        private static void HandleTabPositionChanged(object bindable, object oldValue, object newValue)
        {
            if (bindable is not TabView tv) { return; }//wrong object
            tv.UpdateTabPosition();
        }
        private void UpdateTabPosition()
        {
            Children.Clear();
            CreateTabGridRows();
            PopulateControl();
        }
        private void CreateTabGridRows()
        {
            RowDefinitions.Clear();
            RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, TabPosition == ETabPosition.Top ? GridUnitType.Auto : GridUnitType.Star) });
            RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, TabPosition == ETabPosition.Bottom ? GridUnitType.Auto : GridUnitType.Star) });
        }
        private void PopulateControl()
        {
            Children.Add((TabPosition == ETabPosition.Top ? _tabGrid : (View)_mainView), 0, 0);
            Children.Add((TabPosition == ETabPosition.Bottom ? _tabGrid : (View)_mainView), 0, 1);
        }
        #endregion

        #region Itemssource
        private static void HandleItemssourceChanged(object bindable, object oldValue, object newValue)
        {
            if (bindable is not TabView tv) { return; }//wrong object

            tv.CreateNewTabs();
        }
        private void CreateNewTabs()
        {
            if (ContentTemplateSelector is null) { return; }
            if (TabTemplate is null) { return; }
            if (Itemssource is null || Itemssource.Count == 0) { return; }

            var itemsCollection = new object[Itemssource.Count];
            Itemssource.CopyTo(itemsCollection, 0);

            for (int i = 0; i < itemsCollection.Length; i++)
            {
                var item = itemsCollection[i];
                _tabGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

                #region tab Content
                var tabContentTemplate = ContentTemplateSelector.SelectTemplate(SelectedItem, this);
                var tabContent = tabContentTemplate.CreateContent();
                if (tabContent is not View view)
                {
                    throw new NotSupportedException($"Template of type {tabContent.GetType()} is not supported");
                }
                view.BindingContext = item;
                var tabCv = new ContentView
                {
                    Content = view
                };
                #endregion

                #region tab item
                var tabItemContent = TabTemplate.CreateContent();
                if (tabItemContent is not View tabView)
                {
                    throw new NotSupportedException($"Template of type {tabItemContent.GetType()} is not supported");
                }
                tabView.BindingContext = item;
                var tabItemCv = new ContentView
                {
                    Content = tabView,
                };
                var tap = new TapGestureRecognizer();
                tap.Tapped += HandleTabTap;
                tabItemCv.GestureRecognizers.Add(tap);
                #endregion

                #region compose
                var tv = new TabItem
                {
                    Index = i,
                    Item = item,
                    Content = tabCv,
                    Tab = tabItemCv
                };

                _tabGrid.Children.Add(tv.Tab, i, 0);
                _tabs.Add(tv);
                #endregion

            }
            SelectedItem = itemsCollection.First();
        }

        private void HandleTabTap(object sender, EventArgs args)
        {
            if (sender is not ContentView cv) { return; }
            SelectedItem = cv.Content.BindingContext;
        }
        #endregion

        #region Select Tab
        private static void HandleSelectedItemChanged(object bindable, object oldValue, object newValue)
        {
            if (bindable is not TabView tv) { return; }//wrong object

            if (oldValue is ITabItem oldTabItem)
            {
                oldTabItem.IsSelected = false;
                oldTabItem.Disappearing();
            }

            tv.SetTabContent();

            if (newValue is ITabItem newTabItem)
            {
                newTabItem.IsSelected = true;
                newTabItem.Appearing();
            }

        }
        private void SetTabContent()
        {
            var tabItem = _tabs.FirstOrDefault(t => t.Item == SelectedItem);
            if (tabItem is null) { return; }
            _mainView.Content = tabItem.Content;

        }
        #endregion

    }

}
