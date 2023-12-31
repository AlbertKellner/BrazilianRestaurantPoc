﻿namespace Playground.Application.Features.TableReservation.Query.GetById.Models
{
    public static class GetByIdTableReservationQueryExtensions
    {
        public static string ToWarning(this GetByIdTableReservationQuery input)
        {
            return $@"{nameof(input.Id)}:{input.Id}|{nameof(input.FormattedErrosList)}:{input.FormattedErrosList()}";
        }

        public static string ToInformation(this GetByIdTableReservationQuery input)
        {
            return $@"{nameof(input.Id)}:{input.Id}";
        }
    }
}
