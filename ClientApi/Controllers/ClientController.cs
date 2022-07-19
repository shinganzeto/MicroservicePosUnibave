using System.Text;
using ClientApi.DTO;
using ClientApi.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace ClientApi.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;
    private readonly ConnectionFactory _factory;
    private const string QUEUE_NAME = "client";

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
        _factory = new ConnectionFactory
        {
            HostName = "rabbitmq", //caso usar em localhost altera HostName para localhost
            Port = 5672
        };

        _factory.UserName = "guest";
        _factory.Password = "guest";
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientDTO>>> Get()
    {
        var clientDto = await _clientService.GetClients();
        if (clientDto is null)
            return NotFound("Cliente não encontrado");

        return Ok(clientDto);
    }

    [HttpGet("{id:int}", Name = "GetClient")]
    public async Task<ActionResult<ClientDTO>> Get(int id)
    {
        var clientDto = await _clientService.GetClientById(id);
        if (clientDto is null)
            return NotFound("Cliente não encontrado");

        return Ok(clientDto);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ClientDTO clientDto)
    {
        if (clientDto is null)
            return BadRequest("Dado inválido");

        await _clientService.AddClient(clientDto);

        using (var connection = _factory.CreateConnection())
        {
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(
                    queue: QUEUE_NAME,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);
                
                var jsonClient = JsonConvert.SerializeObject(clientDto);
                var byteClient = Encoding.UTF8.GetBytes(jsonClient);

                channel.BasicPublish(exchange: "",
                                     routingKey: QUEUE_NAME,
                                     basicProperties: null,
                                     body: byteClient);
            }
        };


        return new CreatedAtRouteResult("GetClient", new { id = clientDto.Id }, clientDto);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody] ClientDTO clientDto)
    {
        if (id != clientDto.Id)
            return BadRequest();
        if (clientDto is null)
            return BadRequest();

        await _clientService.UpdateClient(clientDto);

        return Ok(clientDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ClientDTO>> Delete(int id)
    {
        var clientDto = await _clientService.GetClientById(id);
        if (clientDto is null)
            return NotFound("Cliente não encontrado");
        
        await _clientService.DeleteClient(id);

        return Ok(clientDto);
    }

}
