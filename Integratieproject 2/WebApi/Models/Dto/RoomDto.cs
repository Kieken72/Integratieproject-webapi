using System.Collections.Generic;

namespace WebApi.Models.Dto
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int BranchId { get; set; }
        public ICollection<SpaceDto> Spaces { get; set; }
    }
}