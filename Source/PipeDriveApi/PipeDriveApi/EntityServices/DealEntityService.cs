﻿using PipeDriveApi.Enums;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeDriveApi.EntityServices
{
    public class DealEntityService<TDeal> : PagingEntityService<TDeal>
        where TDeal : Deal, new()
    {
        public DealEntityService(IPipeDriveClient client) : base(client, "deals")
        {
        }

        public async Task<IReadOnlyCollection<DealProduct>> ListsProductsAttachedToDeal(int dealId)
        {
            var request = new RestRequest(_Resource + "/{dealId}/products", Method.GET);
            request.AddUrlSegment("dealId", dealId.ToString());

            var response = await _client.ExecuteRequestAsync<List<DealProduct>>(request);
            return response.AsReadOnly();
        }
    }
}
