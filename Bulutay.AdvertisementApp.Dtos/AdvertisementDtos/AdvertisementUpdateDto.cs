﻿using Bulutay.AdvertisementApp.Dtos.Interfaces;

namespace Bulutay.AdvertisementApp.Dtos
{
    public class AdvertisementUpdateDto : IUpdateDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public bool Status { get; set; }
        public string? Description { get; set; }
    }
}
