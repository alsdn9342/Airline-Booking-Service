using System;
using System.Collections.Generic;
using System.Text;

namespace Midterm_MinWooPark
{
    class ListShare
    {
        public static List<String> DataList { get; set; } = new List<String>();
    }

    class ListUse
    {
        public void AddData()
        {
            ListShare.DataList.Add("content ...");
        }

    }
}
