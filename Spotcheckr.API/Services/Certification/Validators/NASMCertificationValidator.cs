using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using HtmlAgilityPack;
using System.Linq;

namespace Spotcheckr.API.Services.Validators
{
	public class NASMCertificationValidator : ICertificationValidator
	{
		private readonly Uri BaseValidationUrl = new("https://www.nasm.org/resources/validate-credentials");
		private readonly IRestClient RestClient;

		public NASMCertificationValidator(IRestClient restClient)
		{
			RestClient = restClient;
		}

		public async Task<IEnumerable<CertificationValidationResponse>> Validate(CertificationValidationSearchCriteria searchCriteria)
		{
			var responses = new List<CertificationValidationResponse>();
			var web = new HtmlWeb();
			var doc = await web.LoadFromWebAsync(BaseValidationUrl.AbsoluteUri);
			var __EVENTTARGET = "ctl00$MainContent$C001$ctl00$ctl00$btnSearchByCertId";
			var __VIEWSTATE = doc.DocumentNode.SelectSingleNode("//*[@id=\"__VIEWSTATE\"]").Attributes["value"].Value;
			var __EVENTVALIDATION = doc.DocumentNode.SelectSingleNode("//*[@id=\"__EVENTVALIDATION\"]").Attributes["value"].Value;
			var __CERTIFICATEPARAMETER = "ctl00$MainContent$C001$ctl00$ctl00$txtCertId";

			RestClient.BaseUrl = BaseValidationUrl;
			var request = new RestRequest(Method.POST);
			request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
			request.AddParameter(nameof(__EVENTTARGET), __EVENTTARGET);
			request.AddParameter(nameof(__VIEWSTATE), __VIEWSTATE);
			request.AddParameter(nameof(__EVENTVALIDATION), __EVENTVALIDATION);
			request.AddParameter(__CERTIFICATEPARAMETER, searchCriteria.CertificationId);

			var response = await RestClient.ExecuteAsync(request);

			var htmlDoc = new HtmlDocument();
			htmlDoc.LoadHtml(response.Content);
			var certificateNodes = htmlDoc.DocumentNode.SelectNodes("//tr[@class='RowStyle']|//tr[@class='AlternateRowStyle']");

			foreach (var node in certificateNodes)
			{
				var dataNodes = node.ChildNodes.Where(dataNode => dataNode.Name == "td").ToArray();
				var fullName = dataNodes[0].InnerText;
				var certificateId = dataNodes[2].InnerText;
				var expiration = dataNodes[3].InnerText;
				var isExpirationDateParsed = DateTime.TryParse(expiration, out var expirationDate);
				responses.Add(new CertificationValidationResponse
				{
					FullName = fullName,
					CertificationNumber = certificateId,
					ExpirationDate = isExpirationDateParsed ? expirationDate : null
				});
			}

			return responses;
		}
	}
}
