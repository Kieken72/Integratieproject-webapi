# Integratieproject-webapi

## Api Endpoints

### http://leisurebooker.azurewebsites.net/api

* [City](#city)
* [Company](#company)

### City

| URI | Controller | VERB | Role | Test |
| --- | --- | --- | --- | --- |
| [/cities](http://leisurebooker.azurewebsites.net/api/cities) | CityController | GET |  | :white_check_mark: |
| [/cities/{id}](http://leisurebooker.azurewebsites.net/api/cities/1) | CityController | GET |  | :white_check_mark: |
| [/cities/by-postal/{postalcode}](http://leisurebooker.azurewebsites.net/api/cities/by-postal/2000) | CityController | GET |  | :white_check_mark: |

### Company

| URI | Controller | VERB | Role | Test |
| --- | --- | --- | --- | --- |
| [/companies](http://leisurebooker.azurewebsites.net/api/companies) | CompanyController | GET | ADMIN | :white_check_mark: |
| [/company/{id}](http://leisurebooker.azurewebsites.net/api/companies/1) | CompanyController | GET |  | :white_check_mark: |