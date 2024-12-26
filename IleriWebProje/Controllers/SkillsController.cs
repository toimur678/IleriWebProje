﻿using IleriWebProje.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IleriWebProje.Controllers
{
    public class SkillsController : Controller
    {
        private readonly AppDbContext _context;
        public SkillsController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allSkills = await _context.Skills.ToListAsync();
            return View(allSkills);
        }
    }
}