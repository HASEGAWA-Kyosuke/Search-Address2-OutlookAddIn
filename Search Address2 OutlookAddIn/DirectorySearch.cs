using System;
using System.Collections.Generic;
using System.DirectoryServices;

namespace Search_Address2_OutlookAddIn {
    internal class Connection {
        private DirectorySearcher dirSearcher;

        internal Connection(string url) {
            var dirEntry = new DirectoryEntry(url, null, null, AuthenticationTypes.Anonymous);
            try {
                var dummy = dirEntry.NativeObject;
            } catch (Exception e) {
                throw new Exception("Server connection errror", e);
            }
            dirSearcher = new DirectorySearcher(dirEntry);
        }

        internal List<List<string>> Search(string query, string[] fields, int maxRecords) {
            dirSearcher.Filter = query;
            foreach (string field in fields) {
                dirSearcher.PropertiesToLoad.Add(field);
            }
            dirSearcher.SizeLimit = maxRecords;

            var resultList = new List<List<string>>();
            try {
                SearchResultCollection resultCollection = dirSearcher.FindAll();
                if (resultCollection == null || resultCollection.Count == 0) {
                    return null;
                }
                foreach (SearchResult aResult in resultCollection) {
                    if (aResult == null) {
                        continue;
                    }
                    var result = new List<string>();
                    foreach (string field in fields) {
                        if (aResult.Properties[field].Count > 0) {
                            result.Add((string)aResult.Properties[field][0]);
                        }
                    }
                    if (result.Count == fields.Length) {
                        resultList.Add(result);
                    }
                }
            } catch (Exception) {
                return null;
            }
            return resultList.Count == 0 ? null : resultList;
        }
    }
}
