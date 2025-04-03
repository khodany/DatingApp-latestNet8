using System;
using System.Text.Json;

namespace API.Helpers;

public static class HttpExtensions
{
    public static void AddPaginationHeader<T>(this HttpResponse response, PagedList<T> data){
        var PaginationHeader = new PaginationHeader(data.CurrentPage, data.PageSize, data.TotalCount, data.TotalPage);

        var jsonOptions = new JsonSerializerOptions{PropertyNamingPolicy =JsonNamingPolicy.CamelCase};
        response.Headers.Append("Pagination", JsonSerializer.Serialize(PaginationHeader,jsonOptions));
        response.Headers.Append("Access-Control-Expose-Headers","Pagination");


    }

}
