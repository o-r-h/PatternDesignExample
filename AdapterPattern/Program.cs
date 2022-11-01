// See https://aka.ms/new-console-template for more information
using AdapterPattern;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

Adaptee adaptee = new Adaptee();
string OnlyStringLike = "E";
ITarget target = new Adapter(adaptee, OnlyStringLike);

Console.WriteLine("Adaptee interface is a object."); 
Console.WriteLine("Client need a filter string");

Console.WriteLine(target.GetRequest());


//Based on https://refactoring.guru/es/design-patterns/adapter/csharp/example#example-0--Program-cs
// The Target defines the domain-specific interface used by the client code.
public interface ITarget
{
    string GetRequest();
}

// The Adaptee contains some useful behavior, but its interface is
// incompatible with the existing client code. The Adaptee needs some
// adaptation before the client code can use it.
class Adaptee
{
    public ThirdPartyApi GetSpecificRequest()
    {
        ThirdPartyApi thirdPartyApi = new ThirdPartyApi();  

        return thirdPartyApi;
    }
}

// The Adapter makes the Adaptee's interface compatible with the Target's
// interface.
class Adapter : ITarget
{
    public string filter;
    private readonly Adaptee _adaptee;
    public Adapter(Adaptee adaptee, string filter)
	{
		this._adaptee = adaptee;
		this.filter = filter;
	}

	public string GetRequest()
    {
        ThirdPartyApi thirdPartyApi = new ThirdPartyApi();
        thirdPartyApi = this._adaptee.GetSpecificRequest();
        string result = "";
        foreach (var item in thirdPartyApi.values.Where(x=>x.Contains(filter)))
		{
            result = result + item.ToString()+ " - ";
		}
        return $"Adapter Result : {result.Remove( result.Length-3)}";
    }
}


