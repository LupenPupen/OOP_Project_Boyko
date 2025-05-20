using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Course_Project_Boyko.Interfaces;
using Course_Project_Boyko.Users;
using Course_Project_Boyko.TransportRelated;

namespace Course_Project_Boyko.Data
{
    /// <summary>
    /// DataStore отвечает только за хранение коллекций и загрузку/сохранение данных через IDataProvider.
    /// Вся бизнес-логика вынесена в отдельные сервисы (например, UserService).
    /// </summary>
    public static class DataStore
    {
        // Внедряемый провайдер данных (по умолчанию — файловый)
        public static IDataProvider DataProvider { get; set; } = new FileDataProvider(
            "C:\\Users\\Admin\\source\\repos\\Course_Project_Boyko\\OOP_Project_Boyko\\JsonData\\users.json",
            "C:\\Users\\Admin\\source\\repos\\Course_Project_Boyko\\OOP_Project_Boyko\\JsonData\\transports.json",
            "C:\\Users\\Admin\\source\\repos\\Course_Project_Boyko\\OOP_Project_Boyko\\JsonData\\rentals.json"
        );

        public static ObservableCollection<BaseUser> Users { get; set; } = new ObservableCollection<BaseUser>();
        public static ObservableCollection<Transport> Transports { get; set; } = new ObservableCollection<Transport>();
        public static ObservableCollection<Rental> Rentals { get; set; } = new ObservableCollection<Rental>();

        public static event EventHandler DataLoaded;
        public static event EventHandler DataSaved;

        /// <summary>
        /// Загружает данные из провайдера и гарантирует наличие администратора.
        /// </summary>
        public static void LoadData()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Сохраняет все коллекции через провайдер.
        /// </summary>
        public static void SaveData()
        {
            throw new NotImplementedException();
        }

        private static void OnDataLoaded()
        {
            throw new NotImplementedException();
        }

        private static void OnDataSaved()
        {
            throw new NotImplementedException();
        }
    }
}