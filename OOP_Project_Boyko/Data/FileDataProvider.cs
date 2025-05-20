using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using OOP_Project_Boyko.Interfaces;
using OOP_Project_Boyko.Users;
using OOP_Project_Boyko.TransportRelated;

namespace OOP_Project_Boyko.Data
{
    public class FileDataProvider(string usersFile, string transportsFile, string rentalsFile) : IDataProvider
    {
        private readonly string usersFile = usersFile;
        private readonly string transportsFile = transportsFile;
        private readonly string rentalsFile = rentalsFile;

        public ObservableCollection<BaseUser> LoadUsers()
        {
            if (!File.Exists(usersFile))
                return [];

            var json = File.ReadAllText(usersFile);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
            };
            return JsonSerializer.Deserialize<ObservableCollection<BaseUser>>(json, options)
                   ?? [];
        }

        public void SaveUsers(ObservableCollection<BaseUser> users)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
            };
            var json = JsonSerializer.Serialize(users, options);
            File.WriteAllText(usersFile, json);
        }

        public ObservableCollection<Transport> LoadTransports()
        {
            if (!File.Exists(transportsFile))
                return [];

            var json = File.ReadAllText(transportsFile);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
            };
            return JsonSerializer.Deserialize<ObservableCollection<Transport>>(json, options)
                   ?? [];
        }

        public void SaveTransports(ObservableCollection<Transport> transports)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
            };
            var json = JsonSerializer.Serialize(transports, options);
            File.WriteAllText(transportsFile, json);
        }

        public ObservableCollection<Rental> LoadRentals()
        {
            if (!File.Exists(rentalsFile))
                return [];

            var json = File.ReadAllText(rentalsFile);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
            };
            return JsonSerializer.Deserialize<ObservableCollection<Rental>>(json, options)
                   ?? [];
        }

        public void SaveRentals(ObservableCollection<Rental> rentals)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters = { new System.Text.Json.Serialization.JsonStringEnumConverter() }
            };
            var json = JsonSerializer.Serialize(rentals, options);
            File.WriteAllText(rentalsFile, json);
        }
    }
}
