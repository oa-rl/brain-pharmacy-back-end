﻿namespace API.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string LastName { get; set; } = "";
        public string NIT { get; set; } = "C/F";
        public string Email { get; set; } = "";
        public string Address { get; set; } = "";
        public string Phone1 { get; set; } = "";
        public string Phone2 { get; set; } = "";
    }
}
