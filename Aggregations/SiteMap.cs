using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//input
//log = [
//  { 'user': 'A', 'page': 1},
//  { 'user': 'B', 'page': 5},
//  { 'user': 'A', 'page': 2},
//  { 'user': 'A', 'page': 1},
//  { 'user': 'B', 'page': 2},
//  { 'user': 'C', 'page': 7},
//  { 'user': 'C', 'page': 3},
//  { 'user': 'A', 'page': 3},
//  { 'user': 'C', 'page': 1},
//]

//please implement
//discover_site_map(log)

//discover_site_map returns a representation of the links between pages, using whatever data structure you think is suitable:
//1 -> 2, 3
//2 -> 1
//3 -> 1
//5 -> 2
//7 -> 3   
namespace Aggregations
{
    class Trace
    {
        public string UserID { get; set; }
        public int Page { get; set; }

        public Trace(string userID, int page)
        {
            this.UserID = userID;
            this.Page = page;
        }
    }

    class SiteMap
    {
        private List<Trace> traces = new List<Trace>();

        public SiteMap()
        {
            traces.Add(new Trace("A", 1));
            traces.Add(new Trace("B", 5));
            traces.Add(new Trace("A", 2));
            traces.Add(new Trace("A", 1));
            traces.Add(new Trace("B", 2));
            traces.Add(new Trace("C", 7));
            traces.Add(new Trace("C", 3));
            traces.Add(new Trace("A", 3));
            traces.Add(new Trace("C", 1));
        }

        public void SetSiteMap()
        {
            // Key - UserID
            // Value - List of pages he step on (by page order) (User Route)
            Dictionary<string, List<int>> userPagesDic = new Dictionary<string,List<int>>();

            // Aggregating a route for each user
            // In this example:
            // A 1,2,1,3
            // B 5,2
            // C 7,3,1
            foreach (Trace t in traces)
            {
                if (!userPagesDic.ContainsKey(t.UserID))
                    userPagesDic.Add(t.UserID, new List<int>());

                userPagesDic[t.UserID].Add(t.Page);
            }

            // Key - Page
            // Value - List of links in page
            Dictionary<int, List<int>> siteMapDic = new Dictionary<int, List<int>>();

            // There is no meaning for the userID
            // This loop will create:
            // 1 2,3
            // 2 1
            // 3 1
            // 5 2
            // 7 3
            foreach (List<int> userPages in userPagesDic.Values)
            {
                for (int i = 1; i < userPages.Count; i++)
                {
                    if (!siteMapDic.ContainsKey(userPages[i - 1]))
                        siteMapDic.Add(userPages[i - 1], new List<int>());

                    siteMapDic[userPages[i - 1]].Add(userPages[i]);
                }
            }
        }
    }
}
