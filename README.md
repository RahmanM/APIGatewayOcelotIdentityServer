# Sample API Gateway using Ocelot and Identity Server

- Ocelot as API gateway
- Identity server as authentication / authorisation server

# Features
## 1- API authentication using Client Id and Client Secret

To test API:
- Call https://localhost:5001/connect/token
- Request POST body should contain:

grant_type = client_credentials
client_id = m2m.client
client_secret = 511536EF-F270-4058-80CA-1C89C192F69A
scope = apiQuery

- Once token is received then pass the token as Bearer Token using the Postman Authorisation


## 2- Interactive login using the MVC client

- Run the MVC client and Identity Server
- If user is not logged in it will automatically redirect to Identity Server
- Once logged in, the MVC page will be redirected
