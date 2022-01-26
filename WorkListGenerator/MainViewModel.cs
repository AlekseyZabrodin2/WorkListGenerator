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
using SD=System.Data;
using Prism.Mvvm;
using WorkListGenerator.Model;
using WorkListGenerator.Model.Data;

namespace WorkListGenerator
{
    public class MainViewModel : BindableBase

    {
        public MainViewModel()
        {

        }



        public MySqlConnection myConnection;
        public MySqlCommand MySqlCommand;
        private MySqlDataAdapter adapter;
        private DataTable tablet;
        public string connect = "Server=localhost;DataBase=worklistgenerator;Uid=root;pwd=root;";
        //public string connect = "Server=localhost;DataBase=worklistgenerator;Uid=root;pwd=root;";
        public SD.DataSet dataSet;
        private string _updateText;




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

        private DelegateCommand request;
        public ICommand Request => request = new DelegateCommand(PerformRequest);

        private void PerformRequest()
        {
            try
            {
                //var scriptRequest = "INSERT INTO `worklistgenerator`.`worklisttest` (`Id`, `LastName`, `Name`) VALUES ('7', 'Michal2', 'John');";
                
                var scriptRequest = "SELECT LastName FROM worklisttest WHERE Name='John' AND Id=4";
                myConnection = new MySqlConnection(connect);

                myConnection.Open();

                //adapter = new MySqlDataAdapter(scriptRequest, connect);

                MySqlCommand command = new MySqlCommand(scriptRequest, myConnection);

                MySqlDataReader reader = command.ExecuteReader();

                //tablet = new DataTable();

                //adapter.Fill(tablet);

                ////string result = command.ExecuteScalar().ToString();

                while (reader.Read())
                {
                    UpdateText = reader[0].ToString();
                }

               reader.Close();
                

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
