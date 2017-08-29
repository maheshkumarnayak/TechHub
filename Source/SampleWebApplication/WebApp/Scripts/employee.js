$(document).ready(function () {
    $('body').delegate("#btnsearch", 'click', onSearch);
    $('body').delegate(".sorting", 'click', onSort);
    var parent = this;
    var employees = [];
    var recordinPage = 10;
    var searchType = 2;
    var sortType = 0;
    var searchvalue = '';
    var sortOrder = true;
    var lastSortType = 0;
    var lastPageclick = 1;
    var lastTotalRecord=0;

    searchvalue = $('#searchValue').val();
    searchType = $('#searchby').val();

    getEmployees(lastPageclick, recordinPage, searchType, searchvalue, sortType, sortOrder,true);

    function onSearch() {
        searchvalue = $('#searchValue').val();
        searchType = $('#searchby').val();
        sortOrder = true;
        sortType = 0;
        lastPageclick = 1;
        getEmployees(lastPageclick, recordinPage, searchType, searchvalue, sortType, sortOrder,true);
    }

    function onSort() {
        var sortType = $(this).attr('sortType');
        lastPageclick = 1;
        if (lastSortType == sortType) {
            sortOrder = !sortOrder;
        } else {
            sortOrder = true;
        }
        lastSortType = sortType;
        searchvalue = $('#searchValue').val();
        searchType = $('#searchby').val();
        getEmployees(lastPageclick, recordinPage, searchType, searchvalue, sortType, sortOrder, false);
    }

    function onPageClick(pagenumber) {
        getEmployees(pagenumber, recordinPage, searchType, searchvalue, sortType, sortOrder,false);
    }

    function getEmployees(pagenumber, recordinPage, searchType, searchvalue, sortType, sortOrder,ispagerefresh) {
        $.ajax({
            url: "api/Employee?PageNumber=" + pagenumber + "&RecordInPage=" + recordinPage + "&Searchtype=" + searchType + "&Searchvalue=" + searchvalue + "&SortType=" + sortType + "&SortOrder=" + sortOrder,
            success: function (res) {
                if (ispagerefresh && res.TotalRecord != lastTotalRecord) {
                    refreshPageInfo(res);
                }
                onSuccess(res);
                lastTotalRecord = res.TotalRecord;
            },
            error: function (obj) {
                alert('some error');
            }
        });
    };

    function refreshPageInfo(res)
    {
        $('#pagination').twbsPagination('destroy');
        $('#pagination').twbsPagination({
            totalPages: res.TotalRecord / res.RecordInPage < 1 ? 1 : Math.round(res.TotalRecord / res.RecordInPage),
            visiblePages: 5,
            next: 'Next',
            prev: 'Prev',
            onPageClick: function (event, page) {
                onPageClick(page);
            }
        });
    }

    function onSuccess(res) {
        $('table#emptable tbody').html("");
        for (var i = 0 ; i < res.Employees.length; i++) {
            $('table#emptable tbody').append('<tr><td>' + res.Employees[i].Name + '</td><td>' + res.Employees[i].EmpType + '</td><td>' + res.Employees[i].EmpDesignation + '</td></tr>')
        };
    }
    
});


