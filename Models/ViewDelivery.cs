﻿using System;
using System.Collections.Generic;

namespace gasolina_asp.net_core_web_api.Models
{
    public partial class ViewDelivery
    {
        public decimal DeliveryId { get; set; }
        public decimal? EmployeeNumber { get; set; }
        public int? VehiclesId { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? TravelDate { get; set; }
        public int? Amount { get; set; }
        public string? TravelReason { get; set; }
        public bool? Status { get; set; }
        public short? AssignmentFuelId { get; set; }
        public string? Period { get; set; }
        public int? TypeDriver { get; set; }
        public string? Ficha { get; set; }
        public int? Model { get; set; }
        public decimal? Year { get; set; }
        public string? VehiclePlate { get; set; }
        public string? Chassis { get; set; }
        public string? NameBrand { get; set; }
        public string? ModelName { get; set; }
        public decimal? FuelTicketId { get; set; }
        public decimal DetailId { get; set; }
        public string? FullName { get; set; }
        public int? Sequential { get; set; }
        public string? BarCode { get; set; }
        public int? AmountTicket { get; set; }
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
    }
}
