using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.SqlClient;
using Oliva.GenX.DataTier.Entities;

namespace Oliva.GenX.DataTier.Comp
{
    public static class LinkManager
    {
        public static List<GrabList> GenerateGrabLinks(string pattern, string referer, int start, int end, int pad)
        {
            List<GrabList> links = new List<GrabList>();

            for (int i = start; i <= end; i++)
            { 
                links.Add(new GrabList(pattern.Replace("[i]", i.ToString().PadLeft(pad)), referer));
            }

            MassageLinks(pattern, links);
            return links;
        }

        public static List<GrabList> GenerateGrabLinks(string pattern, string referer, 
            int startx, int endx, int padx, 
            int starty, int endy, int pady)
        {
            List<GrabList> links = new List<GrabList>();

            for (int i = startx; i <= endx; i++)
            {
                string newPattern = pattern.Replace("[i]", i.ToString().PadLeft(padx));
                for(int j = starty; j <= endy; j++)
                {
                    links.Add(new GrabList(newPattern.Replace("[j]", j.ToString().PadLeft(pady)), referer));
                }
            }

            MassageLinks(pattern, links);
            return links;
        }

        private static List<GrabList> MassageLinks(string pattern, List<GrabList> generatedLinks)
        {
            string searchPattern = pattern.Replace("[i]", "%");
            searchPattern = searchPattern.Replace("[j]", "%");

            using (GenXModelDataContext context = new GenXModelDataContext())
            {
                var searchLinks = from c in context.GrabLists
                                  where SqlMethods.Like(c.url, searchPattern)
                                  orderby c.url
                                  select c;

                // if no results are returned for the pattern we donot need to message
                if (searchLinks.Count() <= 0) return generatedLinks;

                // else for each of the generated link find the DB values and assign to generated link
                var mergedLinks = generatedLinks.Union(searchLinks).ToList();
                return mergedLinks;

            }
        }

    }
}
