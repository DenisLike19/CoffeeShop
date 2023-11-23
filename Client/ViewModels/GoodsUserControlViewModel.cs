using Client.Models;
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
    public class GoodsUserControlViewModel : ViewModelBase
    {
        private Good _selectedGood;
        public Good SelectedGood
        {
            get => _selectedGood;
            set => this.RaiseAndSetIfChanged(ref _selectedGood, value);
        }

        private HttpClient client = new HttpClient();
        private ObservableCollection<Good> _goods;
        public ObservableCollection<Good> Goods
        {
            get => _goods;
            set => this.RaiseAndSetIfChanged(ref _goods, value);
        }

        private string _message;
        public string Message
        {
            get => _message;
            set => this.RaiseAndSetIfChanged(ref _message, value);
        }

        public GoodsUserControlViewModel()
        {
            client.BaseAddress = new Uri("http://localhost:5068");
            Update();
        }

        public async Task Update()
        {
            var response = await client.GetAsync("/goods");
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
            Goods = JsonSerializer.Deserialize<ObservableCollection<Good>>(content);
            Message = "";
        }

        public async Task Delete()
        {
            if (SelectedGood == null) return;
            var response = await client.DeleteAsync($"/goods/{SelectedGood.GoodId}");
            if (!response.IsSuccessStatusCode)
            {
                Message = "Ошибка удаления со стороны сервера";
                return;
            }
            Goods.Remove(SelectedGood);
            SelectedGood = null;
            Message = "";
        }

        public async Task Add()
        {
            var good = new Good();
            var response = await client.PostAsJsonAsync($"/goods", good);
            if (!response.IsSuccessStatusCode)
            {
                Message = "Ошибка добавления со стороны сервера";
                return;
            }
            var content = await response.Content.ReadFromJsonAsync<Good>();
            if (content == null)
            {
                Message = "При добавлении сервер отправил пустой ответ";
                return;
            }
            good = content;
            Goods.Add(good);
            SelectedGood = good;
        }

        public async Task Edit()
        {
            var response = await client.PutAsJsonAsync($"/goods", SelectedGood);
            if (!response.IsSuccessStatusCode)
            {
                Message = "Ошибка изменения со стороны сервера";
                return;
            }
            var content = await response.Content.ReadFromJsonAsync<Good>();
            if (content == null)
            {
                Message = "При изменении сервер отправил пустой ответ";
                return;
            }
            SelectedGood = content;
        }
    }
}