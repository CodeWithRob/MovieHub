﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieHub.Models;

namespace MovieHub.ViewModels;

public class OrderViewModel
{
    public Showtime? Showtime { get; set; }
    public List<Tickettype>? Tickettypes { get; set; }
    public List<CateringPackage>? CateringPackages { get; set; }
    public Movie? Movie { get; set; }
    public Payment? Payment { get; set; }
    public List<Showtime>? StartDates { get; set; }
    public List<SelectListItem>? ShowList { get; set; }
    public List<MovieRuntime>? MovieRuntimes { get; set; }
    public List<MoviePegi>? MoviePegis { get; set; }

}