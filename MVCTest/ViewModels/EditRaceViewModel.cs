using MVCTest.Data.Enum;
using MVCTest.Models;

namespace MVCTest.ViewModels
{
        public class EditRaceViewModel
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string? Image { get; set; }
            public string? URL { get; set; }
            public int AddressId { get; set; }
            public Address Address { get; set; }
            public RaceCategory RaceCategory { get; set; }
        }
    }