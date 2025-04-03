using System;

namespace API.Helpers;

public class PaginationHeader(int currentPage, int itemsPerPage, int totalItems, int totalPages)
{
    public int CurrentPage {set;get;} =currentPage;
    public int ItemsPerPage {set;get;} =itemsPerPage;

    public int TotalItems {set;get;} =totalItems;

    public int TotalPages {set;get;} =totalPages;


}
