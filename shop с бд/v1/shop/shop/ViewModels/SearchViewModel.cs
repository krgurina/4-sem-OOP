using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shop.Models;
using shop.Database;
using System.Collections.ObjectModel;
using shop.Views;
using System.Data.SqlClient;
using System.Data;

namespace shop.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        //public ObservableCollection<Product> LstProduct { get; set; } = new ObservableCollection<PRODUCTS>();

        //public ObservableCollection<Product> products = new ObservableCollection<Product>();
        //public ObservableCollection<PRODUCTS> products { get; set; }
        //public ObservableCollection<Product> product { get; set; }
        SearchView SearchView { get; set; } = new SearchView();
//        public ObservableCollection<Product> products { get; set; } = new ObservableCollection<PRODUCTS>();



        public SearchViewModel()
        {

           // products = new ObservableCollection<PRODUCTS>(ShopDbContext.db.PRODUCTS);

            SearchView.testik.Text = "gjfjnmvkfk";

            //для вывода в таблице работает
            //SearchView.productList.ItemsSource = ShopDbContext.db.PRODUCTS.ToList();



            // для заполнения из бд( из другого курсача)
            //using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            //{
            //    if (ShopDbContext.db == null)
            //    {
            //        throw new Exception("Error");
            //    }
            //    else
            //    {

            //        SqlCommand query = new SqlCommand("SELECT * from PRODUCT ", conn);
            //        conn.Open();
            //        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
            //        DataTable dataTable = new DataTable();
            //        sqlDataAdapter.Fill(dataTable);

            //        foreach (DataRow row in dataTable.Rows)
            //        {
            //            PRODUCTS p = new PRODUCTS();
            //            p.ID = (int)row["ID"];
            //            p.TITLE = row["TITLE"].ToString();
            //            p.PRICE = (float)row["PRISE"];
            //            p.PTING= (int)row["PTING"];
            //            p.CATEGORY = row["CATEGORY"].ToString();
            //            p.DISCRIPTION = row["DISCRIPTION"].ToString();
            //            //p.photo_1 = row["photo_1"].ToString();
            //            //p.photo_2 = row["photo_2"].ToString();
            //            //p.photo_3 = row["photo_3"].ToString();

            //            LstProduct.Add(p);
            //        }

            //    }
            //}
           // SearchView.productList.ItemsSource = LstProduct;

            

        }

    }
}
