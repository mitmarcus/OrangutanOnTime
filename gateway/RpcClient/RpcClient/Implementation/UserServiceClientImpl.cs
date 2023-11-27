﻿using Grpc.Net.Client;
using RpcClient.RpcClient.Interface;

namespace RpcClient.RpcClient.Implementation;

public class UserServiceClientImpl : IUserServiceClient
{
    private readonly UserService.UserServiceClient _client;
    public UserServiceClientImpl()
    {
        var channel = GrpcChannel.ForAddress(ServiceConfig.UserServiceUrl);
        _client = new UserService.UserServiceClient(channel);
    }

    
    public async Task<User> GetUserByIdAsync(long id)
    {
        var  response = await _client.GetUserAsync(new GetUserByIdRequest()
        {
            Id = id
        });
        return response;
    }
}