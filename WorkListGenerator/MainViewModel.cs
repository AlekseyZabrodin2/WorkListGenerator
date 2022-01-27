using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media.Animation;
using MySqlConnector;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;
using SD=System.Data;
using Prism.Mvvm;
using WorkListGenerator.Model;
using WorkListGenerator.Model.Data;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace WorkListGenerator
{
    public class MainViewModel : BindableBase

    {
        public MainViewModel()
        {

        }


        public MySqlConnection myConnection;
        public MySqlCommand mySqlCommand;
        public MySqlDataReader dataReader;
        private MySqlDataAdapter adapter;
        private DataTable tablet;
        public string connect = "Server=localhost;DataBase=worklistgenerator;Uid=root;pwd=root;";
        public SD.DataSet dataSet;
        private string _updateText;
        

        //почитать про Pomelo
        public class WorkListDataBase : DbContext
        {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseMySql(connectionString: @"server=localhost;database=BookStoreDb2;uid=root;password=;",
                    new MySqlServerVersion(new Version(10, 4, 17)));
            }

            public DbSet<WorkList> WorkLists { get; set; }
            
        }

      






public string UpdateText
        {
            get
            {
                return _updateText;
            }
            set
            {
                SetProperty(ref _updateText, value);
            }
        }


        private DelegateCommand connectDB;
        public ICommand ConnectDB => connectDB = new DelegateCommand(PerformConnectDB);

        private void PerformConnectDB()
        {
            try
            {
                myConnection = new MySqlConnection(connect);

                myConnection.Open();

                UpdateText = $"DB connect";
                
            }
            catch (Exception e)
            {
                UpdateText = "DB not connect";
            }
            

        }

       
        
        private DelegateCommand selectDb;
        public ICommand SelectDb => selectDb = new DelegateCommand(PerformRequest);

        private void PerformRequest()
        {
            try
            {
                //var scriptRequest = "INSERT INTO `worklistgenerator`.`worklisttest` (`Id`, `LastName`, `Name`) VALUES ('7', 'Michal2', 'John');";
                
               // var scriptSelect = "INSERT INTO `worklisttest` (`Id`, `LastName`, `Name`) VALUES ('12', 'Kortyn', 'Kurtara');";
                myConnection = new MySqlConnection(connect);

                myConnection.Open();

                //adapter = new MySqlDataAdapter(scriptRequest, connect);

                WorkList work = new WorkList {Id = 35, LastName = "Grinch", Name = "Jora"};
                
                adapter = new MySqlDataAdapter( );

                
               
                mySqlCommand = new MySqlCommand("INSERT INTO `worklisttest` (`Id`, `LastName`, `Name`) VALUES ('20', 'Kortyn', 'Kurtara'),('21', 'Kortyn', 'Kurtara')", myConnection);

                dataReader = mySqlCommand.ExecuteReader();

                //tablet = new DataTable();

                //adapter.Fill(tablet);

                ////string result = command.ExecuteScalar().ToString(); 

                while (dataReader.Read())
                {
                    UpdateText = dataReader[0].ToString();
                }

               dataReader.Close();


                //SD.DataTable table = new DataTable();
                //msData.Fill(table);

                //UpdateText = $"{msData}";


                myConnection.Close();



            }
            catch (Exception e)
            {
                UpdateText = "Patient in Base";
            }
            
        }
    }
}
