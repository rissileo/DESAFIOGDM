using Microsoft.AspNetCore.Mvc;

namespace gdm.bff_service.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using gdm.bff_service.Models;
    using gdm.bff_service.Services;
    using System;
    using System.Collections.Generic;

    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet("filter")]
        public IActionResult GetReservationsByDate([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var reservations = _reservationService.GetReservationsByDate(startDate, endDate);
            return Ok(reservations);
        }

        [HttpGet("monthly-revenue")]
        public IActionResult GetMonthlyRevenue([FromQuery] int year, [FromQuery] int month)
        {
            var revenue = _reservationService.GetMonthlyRevenue(year, month);
            return Ok(new { Year = year, Month = month, Revenue = revenue });
        }
    }

}
