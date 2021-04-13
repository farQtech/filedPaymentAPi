# filedPaymentAPi

To test this project, clone into your local machine and run with visual studio or dotnet core cli.

once the project is up and running make you should see this on your browser

![Screenshot](images/home.png)

Once you see above screen you can make a post request to `https://localhost:44352/api/Payment/ProcessPayment` with payload similar to 

```
{
	"CreditCardNumber": "5105105105105100",
	"CardHolder": "Peter Pan",
	"ExpirationDate": "2025-04-07T00:00:00.000Z",
	"SecurityCode": "fha",
	"Amount": 21.3
}

```
