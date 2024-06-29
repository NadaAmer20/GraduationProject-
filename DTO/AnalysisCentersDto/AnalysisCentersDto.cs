using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using GraduationProject.DTO.Images;

namespace GraduationProject.DTO.AnalysisCentersDto
{
    public class AnalysisCentersDto
    { 
        public int id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string DescriptionOfPlace { get; set; }
        public string? LinkOfPlace { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime StartWork { get; set; }
        public DateTime EndWork { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<ImagesDto> Images { get; set; }

        public int? averageRate { get; set; }


    }
}
