using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;


namespace oop8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        SqlConnection _connection;       // для создания канала связи между программой и источником данных 
        SqlCommand _command;
        SqlDataAdapter _adapter1;        // для заполнения DataSet (образ бд) и обновления БД 
        SqlDataAdapter _adapter2;
        DataTable _dataDiscTable;             // таблица бд
        DataTable _dataLectTable;

        string createTables()
        {
            return "use Lab8; " +
                "create table Lectors ( " +
                    "ID int primary key " +
                    "Name nvarchar(20), " +
                    "SSurname nvarchar(20), " +
                    "Patronomyc nvarchar(20), " +
                    "BIRTHDAY date not null, " +
                    "COURSE int check(COURSE between 1 and 5) not null, " +
                    "SEX nchar(1) check(SEX in ('м', 'ж')) not null, " +
                    "AVGSCORE float check(AVGSCORE between 4 and 10) not null, " +
                    "FOTO varbinary(max) default null" +
                ") " +
                "create table[Address]( " +
                    "ID int primary key identity(1,1), " +
                    "StudentID int foreign key references[Student](ID), " +
                    "Town nvarchar(20) not null, " +
                    "[Index] int check([Index] between 100000 and 999999) not null, " +
                    "Street nvarchar(30) not null, " +
                    "House int check(House between 1 and 1000) not null, " +
                    "Flat int check(Flat between 1 and 2000) null" +
               ")";
        }
        string createDB()
        {
            return "use master create database University";
        }

        public Stack<DataTable> back { get; set; }
        public Stack<DataTable> forward { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _connection = new SqlConnection(connectionString);
                _connection.Open();

                //создание бд
                //SqlCommand myCommand1 = new SqlCommand(createDB(), _connection);
                //SqlCommand myCommand2 = new SqlCommand(createTables(), _connection);
                //myCommand1.ExecuteNonQuery();
                //myCommand2.ExecuteNonQuery();

                string sqlExpression = "SELECT * FROM Disciplines";
                _dataDiscTable = new DataTable();
                _command = new SqlCommand(sqlExpression, _connection);
                _adapter1 = new SqlDataAdapter(_command);
                _adapter1.Fill(_dataDiscTable);
                dataGridDisc.ItemsSource = _dataDiscTable.DefaultView; //для редактирования

                string sqlExpression2 = "SELECT * FROM Lectors";
                _dataLectTable = new DataTable();
                _command = new SqlCommand(sqlExpression2, _connection);
                _adapter2 = new SqlDataAdapter(_command);
                _adapter2.Fill(_dataLectTable);
                dataGridLect.ItemsSource = _dataLectTable.DefaultView;

                //история действий
                back = new Stack<DataTable>();
                back.Push(_dataDiscTable);
                forward = new Stack<DataTable>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        private void UpdateDB()
        {
            SqlCommandBuilder comandbuilder = new SqlCommandBuilder(_adapter1);  // автоматич генер-т команды, кот позволяют согласовать
            SqlCommandBuilder comandbuilder2 = new SqlCommandBuilder(_adapter2); // изменения, вносимые в объект dataset, со связанной БД
            _adapter1.Update(_dataDiscTable); //обновляем значения в БД
            _adapter2.Update(_dataLectTable);
            MessageBox.Show("Информация в базе данных обновлена");

            back.Push(_dataDiscTable);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateDB();
        }

        private void AddPhoto_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridLect.SelectedItem != null)
            {
                var selected = (DataRowView)dataGridLect.SelectedItem;
                Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
                if (openFileDlg.ShowDialog() == true)
                    selected.Row[7] = openFileDlg.FileName;
            }
            else
            {
                MessageBox.Show("Необходимо выделить строку с нужным лектором для добавления ему фото");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridDisc.SelectedItems != null)
            {
                for (int i = 0; i < dataGridDisc.SelectedItems.Count; i++)
                {
                    DataRowView datarowView = (DataRowView)dataGridDisc.SelectedItems[i];
                    if (datarowView != null)
                    {
                        DataRow dataRow = (DataRow)datarowView.Row;
                        dataRow.Delete();
                    }
                }
            }
            if (dataGridLect.SelectedItems != null)
            {
                for (int i = 0; i < dataGridLect.SelectedItems.Count; i++)
                {
                    DataRowView datarowView = (DataRowView)dataGridLect.SelectedItems[i];
                    if (datarowView != null)
                    {
                        DataRow dataRow = (DataRow)datarowView.Row;
                        dataRow.Delete();
                    }
                }
            }
            
            UpdateDB();
        }

        private void Proc_Click(object sender, RoutedEventArgs e)
        {
            string proc1 = @"CREATE PROCEDURE [dbo].[sp_GetLectors5]
                                AS
                                    SELECT * FROM Lectors 
                                GO";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(proc1, connection);
                command.ExecuteNonQuery();
            }
            MessageBox.Show("Хранимые процедуры добавлены в базу данных.");


            //string sqlExpression = "SELECT * FROM Lectors";
            //SqlTransaction tran = null;

            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    SqlCommand command = new SqlCommand(sqlExpression, connection);
            //    command.CommandType = System.Data.CommandType.StoredProcedure;

            //    tran = connection.BeginTransaction();
            //    command.Transaction = tran;

            //    command.ExecuteNonQuery(); ////  //выполн запрос и возвр кол-во задейств в инстр строк

            //    tran.Commit(); //фиксирует транзакцию бд

            //    Window_Loaded(new object(), new RoutedEventArgs());
            //}
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            //DataRow row = ds.Tables[0].NewRow(); // добавляем новую строку в DataTable
            //ds.Tables[0].Rows.Add(row);
            try
            {
                _connection = new SqlConnection(connectionString);
                _connection.Open();

                string sqlExpression = "INSERT INTO Disciplines (Name, Semester, Course, NumOfLectures, NumOfLabs, TypeOfControl, LectorID) " +
                                        "VALUES (@name, @semester, @course, @numLectures, @numLabs, @typeControl, @lectorID)";

                var selectedItem = dataGridDisc.SelectedItem as DataRowView;

                _command = new SqlCommand(sqlExpression, _connection);
                _command.Parameters.AddWithValue("@name", selectedItem["Name"].ToString());
                _command.Parameters.AddWithValue("@semester", selectedItem["Semester"].ToString());
                _command.Parameters.AddWithValue("@course", selectedItem["Course"].ToString());
                _command.Parameters.AddWithValue("@numLectures", selectedItem["NumOfLectures"].ToString());
                _command.Parameters.AddWithValue("@numLabs", selectedItem["NumOfLabs"].ToString());
                _command.Parameters.AddWithValue("@typeControl", selectedItem["TypeOfControl"].ToString());
                _command.Parameters.AddWithValue("@lectorID", selectedItem["LectorID"].ToString());
                _command.ExecuteNonQuery();

                UpdateDB();
                //back.Push(_dataDiscTable);
                MessageBox.Show("Дисциплина успешно добавлена!");

                // Обновляем таблицу Disciplines
                //sqlExpression = "SELECT * FROM Disciplines";
                //_dataDiscTable.Clear();
                //_adapter1 = new SqlDataAdapter(sqlExpression, _connection);
                //_adapter1.Fill(_dataDiscTable);
                //dataGridDisc.ItemsSource = _dataDiscTable.DefaultView;
                
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        private void Add_Lector_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _connection = new SqlConnection(connectionString);
                _connection.Open();

                string sqlExpression = "INSERT INTO Lectors (Name, Surname, Patronomyc, Departament, Auditory, Number, Photo) " +
                                        "VALUES (@name, @surname, @patronomyc, @departament, @auditory, @number, @photo)";

                var selectedItem = dataGridLect.SelectedItem as DataRowView;

                _command = new SqlCommand(sqlExpression, _connection);
                _command.Parameters.AddWithValue("@name", selectedItem["Name"].ToString());
                _command.Parameters.AddWithValue("@surname", selectedItem["Surname"].ToString());
                _command.Parameters.AddWithValue("@patronomyc", selectedItem["Patronomyc"].ToString());
                _command.Parameters.AddWithValue("@departament", selectedItem["Departament"].ToString());
                _command.Parameters.AddWithValue("@auditory", selectedItem["Auditory"].ToString());
                _command.Parameters.AddWithValue("@number", selectedItem["Number"].ToString());
                _command.Parameters.AddWithValue("@photo", selectedItem["Photo"].ToString());
                _command.ExecuteNonQuery();

                //UpdateDB();
                MessageBox.Show("Лектор успешно добавлен!");

                // Обновляем таблицу Lectors
                sqlExpression = "SELECT * FROM Lectors";
                _dataLectTable.Clear();
                _adapter2 = new SqlDataAdapter(sqlExpression, _connection);
                _adapter2.Fill(_dataLectTable);
                dataGridLect.ItemsSource = _dataLectTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

   

        private void Change_Buttont(object sender, RoutedEventArgs e)
        {
            dataGridLect.IsReadOnly = false;
            dataGridLect.IsReadOnly = false;
        }

        private void back_Button(object sender, RoutedEventArgs e)
        {
           

            //if (back.Count == 0)
            //    backDtn.IsEnabled = false;
            //else
            //{
            //    _dataDiscTable = back.Pop();
            //    UpdateDB();
            //}


            //if (back.Count > 0)
            //{
            //    forward.Push(_dataDiscTable);
            //    forward.Push(_dataLectTable);
            //    _dataLectTable = back.Pop();
            //    _dataDiscTable = back.Pop();
            //    dataGridDisc.ItemsSource = _dataDiscTable.DefaultView;
            //    dataGridLect.ItemsSource = _dataLectTable.DefaultView;
            //    UpdateDB();
            //}

            //_adapter1.Update(back.Pop()); //обновляем значения в БД
        }

        private void forward_Button(object sender, RoutedEventArgs e)
        {
            //if (forward.Count > 0)
            //{
            //    back.Push(_dataDiscTable);
            //    back.Push(_dataLectTable);
            //    _dataLectTable = forward.Pop();
            //    _dataDiscTable = forward.Pop();
            //    dataGridDisc.ItemsSource = _dataDiscTable.DefaultView;
            //    dataGridLect.ItemsSource = _dataLectTable.DefaultView;
            //    UpdateDB();
            //}
        }

        //не работает
        private void Image_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Image image = (Image)sender;
            PhotoViewer photoViewer = new PhotoViewer(image.Source)
            {
                Owner = this
            };
            photoViewer.Show();
        }

        private void Transact_Buttont(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                SqlCommand command = connection.CreateCommand();
                command.Transaction = transaction;

                try
                {
                    command.CommandText = "INSERT INTO Lectors (Name, Surname)  VALUES('Tim1', 'Tim1')";
                   // command.Parameters.AddWithValue("@name", "name");

                    command.ExecuteNonQuery();
                    //command.Parameters.AddWithValue("@surname", "surname");

                    command.CommandText = "INSERT INTO Lectors (Name, Surname)  VALUES('Tim2', 'Tim2')";
                    command.ExecuteNonQuery();

                    // подтверждаем транзакцию
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    // если ошибка, откатываем назад все изменения
                    transaction.Rollback();
                }
            }
            MessageBox.Show("Транзакция выполнена");

        }
    }
}