# WebApi
an example of a restufl web api

* AppName (the REST service)
* AppName.Application (application interfaces and services – used to aggregate interactions across business objects (domain objects))
* AppName.ServiceModel (plain POCO DTOs for messaging (serialization))
* AppName.Domain (actual business objects)
* AppName.Infrastructure (infrastructure services and repos for interacting with databases and webservices…)

If the domain is [anemic](https://en.wikipedia.org/wiki/Anemic_domain_model), omit the service modeal and publish the domain objects to the nuget server for messaging.  Otherwise, the service model will be what gets packaged up and published to the nuget server.

##Tools Used
* [NLog](http://nlog-project.org/)
* [Automapper](http://automapper.org/)
* [Castle Windsor](https://github.com/castleproject/Windsor/)
* [Microsoft.Owin.Cors](http://www.nuget.org/packages/Microsoft.Owin.Cors/)

##Tokens (need to be replaced)
* __ServerErrorDbConnectionString__
* __ClientErrorDbConnectionString__
* __MyConnectionString__
* __serviceEndpointUrl__

##Notes
* if you're creating a repository that connects to a database and create/update/delete operations are gonig to be used, inherit RestfulApi.Infrastructure.Repositories.Repository and use a UnitOfWork
