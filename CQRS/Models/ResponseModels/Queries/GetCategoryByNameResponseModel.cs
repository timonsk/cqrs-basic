﻿using System;

namespace CQRS.Models.ResponseModels.Queries
{
    public class GetCategoryByNameResponseModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid UserId { get; set; }
    }
}
