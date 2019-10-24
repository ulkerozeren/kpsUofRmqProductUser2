using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using kpsUowRmqTest.Data.Models;
using ServiceReference1;

namespace kpsUowRmqTest.Kps
{
    public class KpsServiceAdapter : IKpsService
    {
        public async Task<bool> Validate(User user)
        {
            BasicHttpsBinding binding = new BasicHttpsBinding();
            EndpointAddress address = new EndpointAddress("https://tckimlik.nvi.gov.tr/Service/KPSPublic.asmx?WSDL");

            KPSPublicSoapClient client = new KPSPublicSoapClient(binding, address);
            var response=await client.TCKimlikNoDogrulaAsync(user.TCKN, user.Name.ToUpper(), user.Surname.ToUpper(), user.Year);
            bool result = response.Body.TCKimlikNoDogrulaResult;
            return result;
        }
    }
}
