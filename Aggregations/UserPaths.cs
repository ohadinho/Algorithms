using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Union of n arrays with x elements. Output common members contained in at least 2 arrays. Explain the complexity of the algorithm used.

//We have a digested server log with username, visited page and timestamp. Create a processing algorithm that will output the most visited page/areas in such a way that will match partial path as well.
//i.e.
//{
//    { user: "user1", page="/home" },
//    { user: "user1", page="/home/account" },
//    { user: "user1", page="/home/account/profile" },
//    { user: "user1", page="/home/account/login" },
//    { user: "user2", page="/about" },
//    { user: "user2", page="/about/contact" },
//    { user: "user2", page="/home" }
//}

//the output
//user1
//     - home/account
//     - home
//user2
//     - /about
namespace Aggregations
{
    public class Path
    {
        public string UserID { get; set; }
        public string PathValue { get; set; }
    }

    public class Paths
    {
        // Key - Path, Value - Number of times appeared
        public Dictionary<string,int> paths = new Dictionary<string,int>();
    }

    public class UserPaths
    {
        List<Path> paths;

        public UserPaths()
        {
            this.paths = new List<Path>();
            this.paths.Add(new Path() { UserID = "1", PathValue = "/home" });
            this.paths.Add(new Path() { UserID = "1", PathValue = "/home/account" });
            this.paths.Add(new Path() { UserID = "1", PathValue = "/home/account/profile" });
            this.paths.Add(new Path() { UserID = "2", PathValue = "/about" });
            this.paths.Add(new Path() { UserID = "2", PathValue = "/about/contact" });
            this.paths.Add(new Path() { UserID = "2", PathValue = "/home" });
        }

        public void SetBasePaths()
        {
            // Key - UserID, Value - Paths
            Dictionary<string, Paths> basePaths = new Dictionary<string, Paths>();

            // This loop adds each user the relevant parts of paths (number of times each part appeared)
            // For instance:
            // 1 
            // home 3           
            // account 2
            // profile 1
            
            // 2
            // about 2
            // contact 1
            // home 1            
            foreach (Path p in this.paths)
            {
                if (!basePaths.ContainsKey(p.UserID)) 
                    basePaths.Add(p.UserID,new Paths());

                StringBuilder concatPathSb = new StringBuilder();
                string[] splittedPathArr = p.PathValue.Split('/');
                
                // For each part of the path
                // For instance: /home/account
                // Running for on: 1. home, 2. account
                foreach (string strPath in splittedPathArr)
                {
                    if (String.IsNullOrEmpty(strPath))
                        continue;

                    // For instance: home --> /home
                    concatPathSb.Append("/" + strPath);
                    string concatPathStr = concatPathSb.ToString();

                    // If paths dictionary of current user doesn't have this path yet
                    // For example: User '1' doesn't have 'account' in his paths dictionary
                    if (!basePaths[p.UserID].paths.ContainsKey(concatPathStr))
                        basePaths[p.UserID].paths.Add(concatPathStr, 0);

                    basePaths[p.UserID].paths[concatPathStr]++;
                }
            }

            foreach (KeyValuePair<string,Paths> sp in basePaths)
            {
                Console.WriteLine("UserID: " + sp.Key);

                foreach (KeyValuePair<string, int> p in sp.Value.paths)
                {
                    if (p.Value <= 1)
                        continue;

                    Console.Write("Path: " + p.Key + ", ");
                    Console.Write("Number of Times: " + p.Value);
                    Console.WriteLine();
                }

                Console.WriteLine();
            }
        }
    }
}
