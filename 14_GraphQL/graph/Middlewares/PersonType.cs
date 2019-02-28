using System.IO;
using System.Threading.Tasks;
using graph.interfaces;
using graph.Models;
using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;

namespace graph.Middlewares
{
    public class PersonType : ObjectGraphType<Person>
    {
        public PersonType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Email);
            //Field(ListGraphType<PersonType>("Parents"));
        }
    }

    public class PersonQuery : ObjectGraphType
    {
        public PersonQuery(IPersonRepository personRepository)
        {
            Field<PersonType>("person",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return personRepository.GetById(id);
                });

            Field<PersonType>("persons",
                resolve: context => personRepository.GetAll());
        }
    }

    public class PersonGraphQLMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IPersonRepository _personRepository;

        public PersonGraphQLMiddleware(RequestDelegate next,
            IPersonRepository personRepository)
        {
            _next = next;
            _personRepository = personRepository;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.StartsWithSegments("/graphql"))
            {
                using (var stream = new StreamReader(httpContext.Request.Body))
                {
                    var query = await stream.ReadToEndAsync();
                    if (!string.IsNullOrWhiteSpace(query))
                    {
                        var schema = new Schema { Query = new PersonQuery(_personRepository) };
                        var result = await new DocumentExecuter()
                            .ExecuteAsync(options =>
                            {
                                options.Schema = schema;
                                options.Query = query;
                            });
                        await WriteResultAsync(httpContext, result);
                    }
                }
            }
            else
            {
                _next?.Invoke(httpContext);
            }
        }

        private async Task WriteResultAsync(HttpContext httpContext, ExecutionResult executionResult)
        {
            var json = new DocumentWriter(indent: true).Write(executionResult);
            httpContext.Response.StatusCode = 200;
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync(json);

        }
    }
}
