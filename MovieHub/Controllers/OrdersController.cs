﻿using Microsoft.AspNetCore.Mvc;
using MovieHub.Data;
using MovieHub.Models;
using MovieHub.ViewModels;

namespace MovieHub.Controllers;

public class OrdersController : Controller
{
    private readonly ApplicationDbContext _context;
    public OrdersController(ApplicationDbContext context)
    {
        _context = context;
    }
    // GET

    public async Task<ActionResult<OrderViewModel>> Index(Showtime showtime)
    {
        OrderViewModel orderViewModel = new OrderViewModel();
        
        orderViewModel.showtime = showtime;
        orderViewModel.Tickettypes = GetAllTicketTypes();
        orderViewModel.Movie = GetMovie(showtime.Id);
        
        
        return View(orderViewModel);
    }
    
    public IQueryable<Tickettype>? GetAllTicketTypes()
    {
        return _context.Set<Tickettype>();
    }
    
    public IQueryable<Movie>? GetMovie(int id)
    {
        return _context.Movie
            .Where(m => m.Id.Equals(id));
    }

}