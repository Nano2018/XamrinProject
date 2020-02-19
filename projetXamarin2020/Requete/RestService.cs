﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using TD.Api.Dtos;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Common.Api.Dtos;
using System.Diagnostics;

namespace projetXamarin2020.Requete
{
    class RestService
    {
        private readonly string url = "https://td-api.julienmialon.com/";

        HttpClient client;
        public List<PlaceItemSummary> Items { get; private set; }
        public RestService()
        {
            client = new HttpClient();
        }

        public async Task<List<PlaceItemSummary>> RefreshDataAsync()
        {
            List<PlaceItemSummary> list = new List<PlaceItemSummary>();
            var uri = new Uri(url + "places");

            try
            {
                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    list = JsonConvert.DeserializeObject<Response<List<PlaceItemSummary>>>(content).Data;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return await Task.FromResult(list);
        }

        public async Task<PlaceItem> FindPlaceItemById(int Id)
        {
            PlaceItem item = new PlaceItem();
            var uri = new Uri(url + "places/" + Id);

            try
            {
                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    item = JsonConvert.DeserializeObject<Response<PlaceItem>>(content).Data;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return await Task.FromResult(item);
        }
       
        public async Task<bool> Add_comment(int Id, CreateCommentRequest commentItem)
        {
            string commentJson = JsonConvert.SerializeObject(commentItem);
            string sContentType = "application/json";
            var sUrl = url + "places/" + Id + "/comments";
            var oTaskPostAsync = await client.PostAsync(sUrl, new StringContent(commentJson, Encoding.UTF8, sContentType));

            return await Task.FromResult(oTaskPostAsync.IsSuccessStatusCode);
        }

        public async Task<LoginResult> Connexion(LoginRequest login)
        {
            LoginResult loginResult = new LoginResult();

            string authJson = JsonConvert.SerializeObject(login);
            string sContentType = "application/json";
            var sUrl = url + "auth/login";
            var oTaskPostAsync = await client.PostAsync(sUrl, new StringContent(authJson, Encoding.UTF8, sContentType));

            if (oTaskPostAsync.IsSuccessStatusCode)
            {
                var content = await oTaskPostAsync.Content.ReadAsStringAsync();
                loginResult = JsonConvert.DeserializeObject<Response<LoginResult>>(content).Data;
            }

            return await Task.FromResult(loginResult);
        }

        public async Task<LoginResult> Inscription(RegisterRequest register)
        {
            LoginResult loginResult = new LoginResult();

            string registerJson = JsonConvert.SerializeObject(register);
            string sContentType = "application/json";
            var sUrl = url + "auth/register";
            var oTaskPostAsync = await client.PostAsync(sUrl, new StringContent(registerJson, Encoding.UTF8, sContentType));

            if (oTaskPostAsync.IsSuccessStatusCode)
            {
                var content = await oTaskPostAsync.Content.ReadAsStringAsync();
                loginResult = JsonConvert.DeserializeObject<Response<LoginResult>>(content).Data;
            }

            return await Task.FromResult(loginResult);
        }

    }
}
