using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PuppeteerSharp;

namespace Spotcheckr.API.Services.Validators
{
	public class NASMCertificationValidator : ICertificationValidator
	{
		private readonly Uri BaseValidationUrl = new("https://www.nasm.org/resources/validate-credentials");
		private readonly string CertificationIdInputSelector = "#MainContent_C001_ctl00_ctl00_txtCertId";
		private readonly string SearchByCertInputSelector = "#MainContent_C001_ctl00_ctl00_btnSearchByCertId";
		private readonly string ResultsContainerSelector = "#MainContent_C001_ctl00_ctl00_gvCertResults";
		private readonly string IndividualResultContainerSelector = "#MainContent_C001_ctl00_ctl00_gvCertResults tr";
		private readonly string IndividualResultDataContainerSelector = "td";

		public async Task<IEnumerable<CertificationValidationResponse>> Validate(CertificationValidationSearchCriteria searchCriteria)
		{
			await new BrowserFetcher().DownloadAsync(BrowserFetcher.DefaultRevision);
			var browser = await Puppeteer.LaunchAsync(new LaunchOptions
			{
				Headless = true,
				Args = new[] { "--single-process",
							   "--enable-automation",
							   "--no-sandbox",
							   "--no-zygote"}
			});
			var validationResponses = new List<CertificationValidationResponse>();

			try
			{
				var page = await browser.NewPageAsync();
				await page.GoToAsync(BaseValidationUrl.AbsoluteUri);

				if (!string.IsNullOrWhiteSpace(searchCriteria.CertificationId))
				{
					var certificateInput = await page.QuerySelectorAsync(CertificationIdInputSelector);
					await certificateInput.TypeAsync(searchCriteria.CertificationId);
					await page.ClickAsync(SearchByCertInputSelector);
				}
				else
				{
					throw new InvalidOperationException("No search criteria provided. First name and last name, or certificate number, must be provided.");
				}


				await page.WaitForSelectorAsync(ResultsContainerSelector);

				var certificationResultsTable = await page.QuerySelectorAsync(ResultsContainerSelector);
				if (certificationResultsTable != null)
				{
					var results = await page.QuerySelectorAllAsync(IndividualResultContainerSelector);

					for (var i = 1; i < results.Length; i++)
					{
						var result = results[i];
						var dataCells = await result.QuerySelectorAllAsync(IndividualResultDataContainerSelector);
						var certificationValidationResponse = new CertificationValidationResponse();

						for (var j = 0; j < dataCells.Length; j++)
						{
							var value = await (await dataCells[j].GetPropertyAsync("innerHTML")).JsonValueAsync<string>();
							if (j == 0)
							{
								certificationValidationResponse.FullName = value;
							}
							else if (j == 2)
							{
								certificationValidationResponse.CertificationNumber = value;
							}
							else if (j == 3)
							{
								var parsedExpirationDate = DateTime.TryParse(value, out var expirationDate);
								if (parsedExpirationDate)
								{
									certificationValidationResponse.ExpirationDate = expirationDate;
								}
							}
						}
						validationResponses.Add(certificationValidationResponse);
					}
				}
			}
			finally
			{
				await browser.CloseAsync();
			}

			return validationResponses;
		}
	}
}
