﻿using System.Collections.Generic;
using System.IO;
using Vuighe.Model;
using Vuighe.Model.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Vuighe.Api.Extensions;

namespace Vuighe.Api.Configurations.Systems
{
    public class AppInitializer : IWebHostInitializer
    {
        private readonly UserManager<Account> _userManager;
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;

        public AppInitializer(
            IConfiguration configuration,
            AppDbContext context,
            UserManager<Account> userManager)
        {
            _configuration = configuration;
            _context = context;
            _userManager = userManager;
        }

        public async Task InitAsync()
        {
            await _context.Database.MigrateAsync();
            await InitAccount();
            await InitCategory();
            await InitFilm();
            await InitCollection();
            await InitTag();
        }

        private string CreatePath(string jsonFile)
        {
            return "Configurations/Initializes/" + jsonFile;
        }

        private async Task InitAccount()
        {
            var account = _configuration.GetSection("DefaultAdmin").Get<Account>();
            if (account is null)
            {
                return;
            }
            account.UserName = account.Email;
            account.IsActive = true;
            if (await _userManager.FindByEmailAsync(account.Email) != null)
            {
                return;
            }
            await _userManager.CreateAsync(account, _configuration["DefaultAdmin:Password"]);
        }

        private async Task InitCategory()
        {
            if (!await _context.Categories.AnyAsync())
            {
                var input = File.ReadAllText(CreatePath("default-category.json"));
                var categories = JsonConvert.DeserializeObject<List<Category>>(input);
                _context.Categories.AddRange(categories);
                await _context.SaveChangesAsync();
            }
        }

        private async Task InitFilm()
        {
            if (!await _context.Films.AnyAsync())
            {
                var input = File.ReadAllText(CreatePath("default-film.json"));
                var films = JsonConvert.DeserializeObject<List<Film>>(input);
                _context.Films.AddRange(films);
                await _context.SaveChangesAsync();
            }
        }

        private async Task InitCollection()
        {
            if (!await _context.Collections.AnyAsync())
            {
                var input = File.ReadAllText(CreatePath("default-collection.json"));
                var collections = JsonConvert.DeserializeObject<List<Collection>>(input);
                _context.Collections.AddRange(collections);
                await _context.SaveChangesAsync();
            }
        }

        private async Task InitTag()
        {
            if (!await _context.Tags.AnyAsync())
            {
                var input = File.ReadAllText(CreatePath("default-tag.json"));
                var tags = JsonConvert.DeserializeObject<List<Tag>>(input);
                _context.Tags.AddRange(tags);
                await _context.SaveChangesAsync();
            }
        }
    }
}