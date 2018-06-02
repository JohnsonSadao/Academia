using ProjetoPatricia.Infra.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectPatricia.Domain.Features.Rooms
{
    public class Room : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Accents { get; set; }

        public virtual void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                throw new RoomEmptyNameException();
            if (Accents < 1)
                throw new RoomInvalidAccentsNumberException();
        }
    }
}
