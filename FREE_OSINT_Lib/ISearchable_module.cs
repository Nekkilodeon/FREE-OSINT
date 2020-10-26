using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace FREE_OSINT_Lib
{
    public interface ISearchable_module
    {
        SearchResult Search(String query, List<Object> extras);
    }
}
