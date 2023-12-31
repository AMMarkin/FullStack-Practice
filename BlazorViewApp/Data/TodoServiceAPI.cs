﻿using NuGet.Protocol;
using System.Text.Json;

namespace BlazorViewApp.Data
{
    public class TodoServiceAPI : ITodoService
    {
        private readonly HttpClient _httpClient;
        private readonly string APIURL = "https://localhost:44391/api/TodoItems/";

        public TodoServiceAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddTodoItem(TodoItem item)
        {
            await _httpClient.PostAsync(APIURL, JsonContent.Create<TodoItem>(item));
        }

        public async Task DeleteTodoItem(long id)
        {
            await _httpClient.DeleteAsync(APIURL+$"{id}");
        }

        public async Task EditTodoItem(long id, TodoItem item)
        {
            await _httpClient.PutAsJsonAsync<TodoItem>(APIURL + $"{id}", item);
        }

        public async Task<IEnumerable<TodoItem>> GetTodoList()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TodoItem>>(APIURL);
        }
    }
}
