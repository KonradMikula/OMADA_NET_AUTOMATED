using System.Collections.Generic;

namespace OMADA_NET_AUTOMATED.Resources
{
    public static class Form
    {
        //FormsWebsite
        public static List<string> uriList = new List<string>()
            {
                "https://go.omada.net/l/581103/2019-10-31/3tnj9d",
                "https://go.omada.net/l/581103/2019-10-02/3tbq6g",
                "https://go.omada.net/l/581103/2020-09-01/46yxp3",
                "https://go.omada.net/l/581103/2019-02-28/3qhx6h",
                "https://go.omada.net/l/581103/2020-06-30/44dsgx",
                "https://go.omada.net/l/581103/2018-09-20/3kx4dn",
                "https://go.omada.net/l/581103/2019-05-01/3rjpcq",
                "https://go.omada.net/l/581103/2019-12-02/3tzs1n",
                "https://go.omada.net/l/581103/2019-05-14/3rpq4q",
                "https://go.omada.net/l/581103/2019-04-01/3r21c3",
                "https://go.omada.net/l/581103/2019-05-03/3rkrt8",
                "https://go.omada.net/l/581103/2018-09-21/3kzbdq",
                "https://go.omada.net/l/581103/2018-09-21/3kz9zj",
                "https://go.omada.net/l/581103/2019-05-03/3rkrrn",
                "https://go.omada.net/l/581103/2018-09-21/3kzbdz",
                "https://go.omada.net/l/581103/2019-05-01/3rjpcj",
                "https://go.omada.net/l/581103/2019-05-03/3rkrqz",
                "https://go.omada.net/l/581103/2018-08-31/3k5pnx"

            };

        public static string submitButton = $"//p[@class='submit']";
        public static string errorElement = $"//p[@class='error no-label']";
        public static string textXPath = $"//*[@class='text']";
        public static string selecyXPath = $"//Select";
        public static string yesXPath = $"//*[text()='Yes']";
    }
}
