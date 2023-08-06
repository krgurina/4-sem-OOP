using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
using testik4_5.Models;
using System.Globalization;
using System.Windows.Resources;


namespace testik4_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int count { get; set; } = 0;
        public static ProductsRepository Sneakers { get; set; } = new ProductsRepository();
        private ObservableCollection<Products> filter = new ObservableCollection<Products>();
        private ObservableCollection<Products> deleted = new ObservableCollection<Products>();
        public static List<ObservableCollection<Products>> story { get; set; } = new List<ObservableCollection<Products>>();

        public List<string> Langs = new List<string>() { "ru-RU", "en-US" };
        public MainWindow()
        {
            InitializeComponent();

            Sneakers.OutputData();
            Sneakers.OutputFilter();
            sneakerList.ItemsSource = Sneakers.GetSneakers();
            Filter.ItemsSource = Sneakers.GetFilter();
            story.Add(new ObservableCollection<Products>(Sneakers.GetSneakers()));
            InitLangsBox();

            List<string> styles = new List<string> { "Light", "Dark" };
            StyleBox.SelectionChanged += ThemeChange;
            StyleBox.ItemsSource = styles;
            StyleBox.SelectedItem = "Dark";


        }

        // 7 лаба 
        // определение событие
        public static readonly RoutedEvent ClickEvent;

        static MainWindow()
        {
            // регистрация маршрутизированного события
            MainWindow.ClickEvent = EventManager.RegisterRoutedEvent("Click",
                RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MainWindow));
            //................................
        }
        // обертка над событием
        public event RoutedEventHandler Click
        {
            add
            {
                // добавление обработчика
                base.AddHandler(MainWindow.ClickEvent, value);
            }
            remove
            {
                // удаление обработчика
                base.RemoveHandler(MainWindow.ClickEvent, value);
            }
        }

        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            string style = StyleBox.SelectedItem as string;
            // определяем путь к файлу ресурсов
            var uri = new Uri("Resources/" + style + "Theme" + ".xaml", UriKind.Relative);
            // загружаем словарь ресурсов
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            // очищаем коллекцию ресурсов приложения
            Application.Current.Resources.Clear();
            // добавляем загруженный словарь ресурсов
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
        private void InitLangsBox()
        {
            LanguageComboBox.ItemsSource = Langs;
        }
        private void SetCursor()
        {

            Cursor customCursor = new Cursor("F:\\labs\\testik4-5\\testik4-5\\img\\arrow.cur");
            this.Cursor = customCursor;
        }
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {

            var newWindow = new AddingWindow();
            newWindow.Owner = this;
            newWindow.Show();
        }
        private void MainWindow_Loaded(object sender, EventArgs e)
        {
            SetCursor();
        }
        private void Filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            filter = new ObservableCollection<Products>();
            foreach (var item in Sneakers.GetSneakers())
            {
                var sneak = Filter.SelectedItem.ToString();
                if (sneak == item.Company)
                {
                    filter.Add(item);
                }

            }

            sneakerList.ItemsSource = filter;
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Text_From.Text = "";
            Text_To.Text = "";
            sneakerList.ItemsSource = Sneakers.GetSneakers();
        }

        private void Change_button_click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = (Products)sneakerList.SelectedItem;
                var newWindow = new ChangeWindow(selectedItem.Id);
                newWindow.Owner = this;
                newWindow.Show();
            }
            catch (Exception er)
            {
                MessageBox.Show("Выберите элемент, который хотите изменить.");
            }
        }

        private void Delete_button_click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = (Products)sneakerList.SelectedItem;
                Sneakers.DeleteSneaker(selectedItem.Id);
                deleted.Add(selectedItem);

                story.Add(new ObservableCollection<Products>(Sneakers.GetSneakers()));
                count++;
            }
            catch (Exception er)
            {
                MessageBox.Show("Выберите элемент, который хотите удалить.");

            }

        }

        private void Search_button_click(object sender, RoutedEventArgs e)
        {
            string searchString = SearchField.Text;
            Regex regex = new Regex(searchString, RegexOptions.IgnoreCase);
            var filter = new List<Products>();
            foreach (var phone in Sneakers.GetSneakers())
            {
                if (regex.IsMatch(phone.Title)|| regex.IsMatch(phone.Company))
                    filter.Add(phone);
            }
            sneakerList.ItemsSource = filter;

        }
        public void PriceFilter()
        {
            var list = new List<Products>();
            decimal from, to;
            try
            {
                if (Text_To.Text == "" && Text_From.Text == "")
                {
                    sneakerList.ItemsSource = Sneakers.GetSneakers();

                }
                else
                {
                    foreach (var item in Sneakers.GetSneakers())
                    {

                        if (Text_To.Text == "")
                        {
                            to = Decimal.MaxValue;
                            if (item.Price >= Convert.ToDecimal(Text_From.Text) && item.Price <= Convert.ToDecimal(to))
                            {
                                list.Add(item);
                            }
                        }
                        else if (Text_From.Text == "")
                        {
                            from = -1;
                            if (item.Price >= Convert.ToDecimal(from) && item.Price <= Convert.ToDecimal(Text_To.Text))
                            {
                                list.Add(item);
                            }
                        }

                        else if (item.Price >= Convert.ToDecimal(Text_From.Text) && item.Price <= Convert.ToDecimal(Text_To.Text))
                        {
                            list.Add(item);
                        }

                    }
                    sneakerList.ItemsSource = list;

                }
            }
            catch (Exception er)
            {

            }

        }
        private void Block_from_changed(object sender, TextChangedEventArgs e)
        {
            PriceFilter();
        }

        private void Block_to_changed(object sender, TextChangedEventArgs e)
        {
            PriceFilter();
        }
        private void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            App.SetLanguageDictionary(this, LanguageComboBox.SelectedItem.ToString());
        }














        public void UndoCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            sneakerList.ItemsSource = story[--count];
            
            if (deleted.Count>0)
            Sneakers.AddItem(deleted[0]);
        }

        private void RedoCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            sneakerList.ItemsSource = story[++count];

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        //7 лаба
        private void Control_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //textBlock1.Text = string.Empty;
            textBlock1.Text = textBlock1.Text + "sender: " + sender.ToString() + "\n";
            textBlock1.Text = textBlock1.Text + "source: " + e.Source.ToString() + "\n\n";
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            textBlock1.Text = string.Empty;

        }

        private void Control_MouseEnter(object sender, MouseEventArgs e)
        {
            textBlock1.Text = string.Empty;

            textBlock1.Text = textBlock1.Text + "sender: " + sender.ToString() + "\n";
            textBlock1.Text = textBlock1.Text + "source: " + e.Source.ToString() + "\n\n";
        }

        private void Exit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter("log.txt", true))
            {
                writer.WriteLine("Выход из приложения: " + DateTime.Now.ToShortDateString() + " " +
                DateTime.Now.ToLongTimeString());
                writer.Flush();
            }

            this.Close();
        }

        private void RoutedUICommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (unvisibleTxtB.Visibility == Visibility.Visible)
            {
                unvisibleTxtB.Visibility = Visibility.Hidden;
            }
            else
            {
                unvisibleTxtB.Visibility = Visibility.Visible;
            }
        }
    }
}
