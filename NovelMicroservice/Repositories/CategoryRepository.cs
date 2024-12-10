﻿namespace NovelMicroservice.Repositories;
using Microsoft.EntityFrameworkCore;
using NovelMicroservice.Data;
using NovelMicroservice.Models;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task UpdateCategoryImageAsync(int categoryID, string imageUrl)
    {
        var category = await _context.Categories.FindAsync(categoryID);
        if (category != null)
        {
            category.ImageUrl = imageUrl;
            await _context.SaveChangesAsync();
        }
    }
    public async Task<IEnumerable<Category>> GetAllCategories()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category> GetCategoryById(int id)
    {
        return await _context.Categories.FindAsync(id);
    }
    public async Task<Category> GetCategoryByNameAsync(string name)
    {
        return await _context.Categories.FirstOrDefaultAsync(c => c.Name == name);
    }
    public async Task AddCategory(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCategory(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category != null)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
