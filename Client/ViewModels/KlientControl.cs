using Client.Models;
using CoffeeShop.Models;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    public class KlientViewModel : ViewModelBase
    {
        private Models.Klient _selectedKlient;
        public Models.Klient SelectedKlient
        {
            get => _selectedKlient;
            set => this.RaiseAndSetIfChanged(ref _selectedKlient, value);
        }
        private HttpClient client = new HttpClient();
        private ObservableCollection<Models.Klient> _Klients;
        public ObservableCollection<Models.Klient> Klients
        {
            get => _klients;
            set => this.RaiseAndSetIfChanged(ref _klients, value);
        }

        private string _message;
        public string Message
        {
            get => _message;
            set => this.RaiseAndSetIfChanged(ref _message, value);
        }

        public KlientViewModel()
        {
            client.BaseAddress = new Uri("http://localhost:5068");
            Update();
        }

        public async Task Update()
        {
            var response = await client.GetAsync("/klients");
            if (!response.IsSuccessStatusCode)
            {
                Message = $"Ошибка сервера {response.StatusCode}";
                return;
            }
            var content = await response.Content.ReadAsStringAsync();
            if (content == null)
            {
                Message = "Пустой ответ от сервера";
                return;
            }
            Klients = JsonSerializer.Deserialize<ObservableCollection<Klient>>(content);
            Message = "";
        }

        public async Task Delete()
        {
            if (SelectedKlient == null) return;
            var response = await client.DeleteAsync($"/klients/{SelectedKlient.id}");
            if (!response.IsSuccessStatusCode)
            {
                Message = "Ошибка удаления со стороны сервера";
                return;
            }
            Klients.Remove(SelectedKlient);
            SelectedKlient = null;
            Message = "";
        }

        public async Task Add()
        {
            var klient = new Klient();
            var response = await client.PostAsJsonAsync($"/klients", klient);
            if (!response.IsSuccessStatusCode)
            {
                Message = "Ошибка добавления со стороны сервера";
                return;
            }
            var content = await response.Content.ReadFromJsonAsync<Klient>();
            if (content == null)
            {
                Message = "При добавлении сервер отправил пустой ответ";
                return;
            }
            klient = content;
            Klients.Add(klient);
            SelectedKlient = klient;
        }

        public async Task Edit()
        {
            var response = await client.PutAsJsonAsync($"/klients", SelectedKlient);
            if (!response.IsSuccessStatusCode)
            {
                Message = "Ошибка изменения со стороны сервера";
                return;
            }
            var content = await response.Content.ReadFromJsonAsync<Klient>();
            if (content == null)
            {
                Message = "При изменении сервер отправил пустой ответ";
                return;
            }
            SelectedKlient = content;
        }
    }
}