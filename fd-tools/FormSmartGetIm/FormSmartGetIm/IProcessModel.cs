using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SansTech.Net.Http;

namespace FormSmartGetIm
{
    interface IProcessModel
    {
        string Perform(string url);
    }

    public class PostParamsModel : IProcessModel
    {
        public string Perform(string url)
        {
            throw new NotImplementedException();
        }
    }

    public class ProcessController
    { 
        public static ProcessArgs[] processes ={  new ProcessArgs("chronos.to", "PostParamsModel"),
                                    new ProcessArgs("mylink.com", "PostParamsModel")
                                 };

        public string Do(string url)
        {
            string domain = UrlHelper.GetDomain(url);

            foreach (ProcessArgs args in processes)
            {
                if (args.Domain == domain)
                {
                    IProcessModel model = (IProcessModel) System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(args.Model);
                    string content = model.Perform(url);
                    return content;
                }
            }

            return string.Empty;
        }
    }

    public class ProcessArgs
    {
        public string Domain;
        public string Model;

        public ProcessArgs(string domain, string model)
        {
            Domain = domain;
            Model = model;
        }
    }

}
